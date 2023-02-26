using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public struct DialogBGInfo
    {
        public bool createBG;
        public string trackName;
        public string mediaName;
        public double margin;
        public bool useMediaBin;
        public string mediaBinName;
    }

    public struct DialogTrackInfo
    {
        public string trackName;
        public string presetName;
        public bool useMediaBin;
        public string mediaBinName;
    }

    public class KeyListInfo
    {
        private readonly List<string> _Keys;
        private readonly string _SettingName;
        private readonly string _FirstKey;

        public List<string> Keys
        {
            get { return _Keys; }
        }

        public string SettingName
        {
            get { return _SettingName; }
        }

        public string FirstKey
        {
            get { return _FirstKey; }
        }

        public KeyListInfo(VegasHelper helper, List<string> keys, string settingName)
        {
            _Keys = keys;
            _SettingName = settingName;
            _FirstKey = GetFirstKey(_Keys, helper.Settings[_SettingName]);
        }

        public static KeyListInfo Instance<T>(VegasHelper helper, Dictionary<string, T> dict, string settingName)
        {
            return new KeyListInfo(helper, dict.Keys.ToList(), settingName);
        }

        private static string GetFirstKey(List<string> list, string name)
        {
            if (name.Length > 0) { return name; }
            if (list.Count > 0) { return list.First(); }
            return "";
        }
    }

    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog;

        Dictionary<string, AudioTrack> audioTKV;
        Dictionary<string, VideoTrack> videoTKV;
        Dictionary<string, Media> mKV;
        Dictionary<string, MediaBin> mbKV;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("CreateJimaku"))
            {
                try
                {
                    // ヘルパクラスのオブジェクト生成は必須
                    VegasHelper helper = VegasHelper.Instance(vegas);

                    JimakuParams jimakuParams = new JimakuParams();

                    List<AudioTrack> audioTracks = helper.AllAudioTracks.ToList();
                    List<VideoTrack> videoTracks = helper.AllVideoTracks.ToList();
                    List<Media> mediaList = helper.GetProjectVideoMediaList();
                    List<MediaBin> mediaBinList = helper.GetMediaBinList();

                    if (mediaList.Count == 0)
                    {
                        MessageBox.Show("対象のビデオメディアが存在していません。");
                        return;
                    }

                    // ダイアログに必要な情報の前準備(オーディオ)
                    audioTKV = helper.GetAudioKeyValuePairs(audioTracks);
                    KeyListInfo klAudio = CreateTrackKL(helper, audioTKV, "Audio");

                    // ダイアログに必要な情報の前準備(ビデオ)
                    videoTKV = helper.GetVideoKeyValuePairs(videoTracks);
                    KeyListInfo klJimaku = CreateTrackKL(helper, videoTKV, "Jimaku");
                    KeyListInfo klActor = CreateTrackKL(helper, videoTKV, "Actor");
                    KeyListInfo klJimakuBG = CreateTrackKL(helper, videoTKV, "JimakuBG");
                    KeyListInfo klActorBG = CreateTrackKL(helper, videoTKV, "ActorBG");

                    // ダイアログに必要な情報の前準備(メディアジェネレータ)
                    KeyListInfo klJimakuPlugin = CreatePluginKL(helper, "Jimaku");
                    KeyListInfo klActorPlugin = CreatePluginKL(helper, "Actor");

                    // ダイアログに必要な情報の前準備(メディア)
                    mKV = helper.GetProjectMediaKeyValuePairs(mediaList);
                    KeyListInfo klJimakuBGMedia = CreateMediaKL(helper, mKV, "JimakuBG");
                    KeyListInfo klActorBGMedia = CreateMediaKL(helper, mKV, "ActorBG");

                    // ダイアログに必要な情報の前準備(メディアビン)
                    mbKV = helper.GetMediaBinKeyValuePairs(mediaBinList);
                    KeyListInfo klAudioMBin = CreateMediaBinKL(helper, mbKV, "Audio");
                    KeyListInfo klJimakuMBin = CreateMediaBinKL(helper, mbKV, "Jimaku");
                    KeyListInfo klActorMBin = CreateMediaBinKL(helper, mbKV, "Actor");
                    KeyListInfo klJimakuBGMBin = CreateMediaBinKL(helper, mbKV, "JimakuBG");
                    KeyListInfo klActorBGMBin = CreateMediaBinKL(helper, mbKV, "ActorBG");

                    PrefixBehaviorType prefixBehavior = (PrefixBehaviorType)helper.Settings["PrefixBehavior"];
                    bool isSetGroupEvent = helper.Settings["IsGroupSerifuJimakuEvent"];
                    bool isRemoveActorAttr = helper.Settings["RemoveActorAttribute"];
                    bool isCreateOneEventCheck = helper.Settings["CreateOneEventCheck"];

                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    settingDialog.SetAudioTrack(helper, klAudio, klAudioMBin);

                    settingDialog.JimakuFilePath = helper.Settings["JimakuFilePath"];
                    settingDialog.PrefixBehavior = prefixBehavior;
                    settingDialog.IsEventGroupCheck = isSetGroupEvent;
                    settingDialog.IsRemoveActorAttr = isRemoveActorAttr;

                    settingDialog.SetJimakuTrack(helper, klJimaku, klJimakuPlugin, klJimakuMBin);

                    settingDialog.SetActorTrack(helper, klActor, klActorPlugin, klActorMBin);

                    settingDialog.SetJimakuColorInfo(helper);

                    settingDialog.SetActorColorInfo(helper);

                    settingDialog.SetJimakuBackground(helper, klJimakuBG, klJimakuBGMedia, klJimakuBGMBin);

                    settingDialog.SetActorBackground(helper, klActorBG, klActorBGMedia, klActorMBin);

                    settingDialog.IsCreateOneEventCheck = isCreateOneEventCheck;

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // 今後の拡張のため、事前に字幕ファイルを読み込んでおく
                    ReadJimaku(ref jimakuParams, settingDialog);

                    InsertAudioInfo insertAudioInfo = CreateAudioInfo(settingDialog);

                    int audioFileCount = helper.CountAudioFiles(insertAudioInfo);

                    Debug.WriteLine(string.Format("[Audio]:{0} [Line]:{1}", audioFileCount, jimakuParams.JimakuLines.Length));

                    if (audioFileCount != jimakuParams.JimakuLines.Length)
                    {
                        MessageBox.Show("セリフ音声ファイルの数と字幕の行数が違います");
                        return;
                    }

                    prefixBehavior = settingDialog.PrefixBehavior;
                    isSetGroupEvent = settingDialog.IsEventGroupCheck;
                    isRemoveActorAttr = settingDialog.IsRemoveActorAttr;
                    isCreateOneEventCheck = settingDialog.IsCreateOneEventCheck;

                    // オーディオファイル流し込み
                    InsertAudioFile(helper, ref insertAudioInfo, settingDialog);

                    // 字幕背景挿入処理
                    // こっちを先にしないと字幕が隠れる
                    BackgroundInfo jimakuBGInfo = CreateBackgroundInfo(helper, settingDialog.JimakuBGInfo);

                    BackgroundInfo actorBGInfo = CreateBackgroundInfo(helper, settingDialog.ActorBGInfo);

                    InsertBackground(helper, ref jimakuBGInfo, ref actorBGInfo, ref insertAudioInfo, isCreateOneEventCheck);

                    // 字幕挿入処理
                    SetTextInfo(ref jimakuParams.Jimaku, helper, settingDialog.JimakuTrackInfo);

                    jimakuParams.IsCreateActorTrack = (prefixBehavior == PrefixBehaviorType.NewEvent);
                    jimakuParams.IsDeletePrefix = (prefixBehavior != PrefixBehaviorType.Remain);

                    if (jimakuParams.IsCreateActorTrack)
                    {
                        SetTextInfo(ref jimakuParams.Actor, helper, settingDialog.ActorTrackInfo);
                        jimakuParams.isRemoveActorAttr = isRemoveActorAttr;
                    }

                    InsertJimaku(ref jimakuParams, helper, settingDialog, ref insertAudioInfo, isSetGroupEvent);

                    // 設定した設定を保存
                    SaveSetting(
                        helper,
                        ref insertAudioInfo,
                        ref jimakuParams,
                        ref jimakuBGInfo,
                        ref actorBGInfo,
                        prefixBehavior,
                        isSetGroupEvent,
                        isCreateOneEventCheck,
                        isRemoveActorAttr);
                }
                catch (Exception ex)
                {
                    string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                    Debug.WriteLine("---[Exception In Helper]---");
                    Debug.WriteLine(errMessage);
                    Debug.WriteLine("---------------------------");
                    MessageBox.Show(errMessage);
                    throw ex;
                }
            }
        }

        private KeyListInfo CreateTrackKL<T>(VegasHelper helper, Dictionary<string, T> kv, string namePrefix)
        {
            return KeyListInfo.Instance(helper, kv, namePrefix + "TrackName");
        }

        private KeyListInfo CreatePluginKL(VegasHelper helper, string namePrefix)
        {
            return new KeyListInfo(helper, helper.GetTitlePluginPresetNames(), namePrefix + "PresetName");
        }

        private KeyListInfo CreateMediaKL<T>(VegasHelper helper, Dictionary<string, T> kv, string namePrefix)
        {
            return KeyListInfo.Instance(helper, kv, namePrefix + "MediaName");
        }

        private KeyListInfo CreateMediaBinKL<T>(VegasHelper helper, Dictionary<string, T> kv, string namePrefix)
        {
            return KeyListInfo.Instance(helper, kv, namePrefix + "MediaBinName");
        }

        private VideoTrack GetVideoTrack(VegasHelper helper, string name, Dictionary<string, VideoTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateVideoTrack(name);
        }

        private AudioTrack GetAudioTrack(VegasHelper helper, string name, Dictionary<string, AudioTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateAudioTrack(name);
        }

        private MediaBin GetMediaBin(VegasHelper helper, string name, Dictionary<string, MediaBin> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateMediaBin(name, false);
        }

        private void ReadJimaku(ref JimakuParams jimakuParams, SettingDialog dialog)
        {
            jimakuParams.JimakuFilePath = dialog.JimakuFilePath;

            using (var jimakuFile = new StreamReader(jimakuParams.JimakuFilePath))
            {
                jimakuParams.JimakuLines = jimakuFile.ReadToEnd().Split(new char[] { '\n' }).Select(s => s.Replace("\r", "")).Where(s => s.Length > 0).ToArray();
            }
        }

        private InsertAudioInfo CreateAudioInfo(SettingDialog dialog)
        {
            return new InsertAudioInfo()
            {
                Folder = dialog.AudioFileFolder,
                Interval = dialog.AudioInterval,
                IsRecursive = dialog.IsRecursive,
                IsInsertFromStartPosition = dialog.IsInsertFromStartPosition
            };
        }

        private void InsertAudioFile(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            SettingDialog dialog
            )
        {
            audioInfo.Track.Name = dialog.AudioTrackName;
            audioInfo.Track.Track = GetAudioTrack(helper, audioInfo.Track.Name, audioTKV);

            audioInfo.MediaBin = CreateMediaBinInfo(helper, dialog.UseAudioMediaBin, dialog.AudioMediaBinName);

            helper.InseretAudioInTrack(ref audioInfo);
        }

        private void InsertJimaku(
            ref JimakuParams jimaku,
            VegasHelper helper,
            SettingDialog dialog,
            ref InsertAudioInfo audioInfo,
            bool isGrouping
            )
        {
            jimaku.JimakuColor = CreateColorInfo(dialog.UseJimakuDefaultSettings,
                dialog.JimakuColor, dialog.JimakuOutlineColor, dialog.JimakuOutlineWidth);

            jimaku.ActorColor = CreateColorInfo(dialog.UseActorDefaultSettings,
                dialog.ActorColor, dialog.ActorOutlineColor, dialog.ActorOutlineWidth);

            helper.InsertJimaku(jimaku, audioInfo.Track.Track, isGrouping);
        }

        private void SetTextInfo(
            ref TextTrackInfo info,
            VegasHelper helper,
            DialogTrackInfo trackInfo)
        {
            info.Track.Name = trackInfo.trackName;
            info.Track.Track = GetVideoTrack(helper, info.Track.Name, videoTKV);

            info.PresetName = trackInfo.presetName;
            info.MediaBin = CreateMediaBinInfo(helper, trackInfo.useMediaBin, trackInfo.mediaBinName);
        }

        private void InsertBackground(
            VegasHelper helper,
            ref BackgroundInfo jimakuBGInfo,
            ref BackgroundInfo actorBGInfo,
            ref InsertAudioInfo audioInfo,
            bool isCreateOne)
        {

            // 声優名を後ろに描画
            helper.InsertBackground(actorBGInfo, audioInfo.Track.Track, isCreateOne);

            helper.InsertBackground(jimakuBGInfo, audioInfo.Track.Track, isCreateOne);
        }

        private ColorInfo CreateColorInfo(bool isUse, Color textColor, Color outlineColor, double outlineWidth)
        {
            ColorInfo info = new ColorInfo()
            {
                IsUse = isUse,
                OutlineWidth = outlineWidth
            };

            if (!info.IsUse) { return info; }

            info.TextColor = textColor;
            info.OutlineColor = outlineColor;

            return info;
        }

        private MediaBinInfo CreateMediaBinInfo(VegasHelper helper, bool isUse, string name)
        {
            MediaBinInfo info = new MediaBinInfo()
            {
                IsUse = isUse
            };

            if (!info.IsUse) { return info; }

            info.Name = name;
            info.Bin = GetMediaBin(helper, name, mbKV);

            return info;
        }

        private BackgroundInfo CreateBackgroundInfo(VegasHelper helper, DialogBGInfo bgInfo)
        {
            BackgroundInfo info = new BackgroundInfo()
            {
                IsCreate = bgInfo.createBG
            };

            if (!info.IsCreate) { return info; }

            info.Track.Name = bgInfo.trackName;
            info.Track.Track = GetVideoTrack(helper, info.Track.Name, videoTKV);
            info.Media.Name = bgInfo.mediaName;
            info.Media.Media = mKV[info.Media.Name];
            info.Margin = bgInfo.margin;
            info.MediaBin = CreateMediaBinInfo(helper, bgInfo.useMediaBin, bgInfo.mediaBinName);

            return info;
        }

        private void SaveSetting(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            PrefixBehaviorType behavior,
            bool isGrouping,
            bool isCreateOne,
            bool isRemoveActorAttr)
        {
            SetAudioSetting(helper, audioInfo);

            helper.Settings["JimakuFilePath"] = jimakuParams.JimakuFilePath;

            helper.Settings["PrefixBehavior"] = (int)behavior;

            helper.Settings["IsGroupSerifuJimakuEvent"] = isGrouping;

            helper.Settings["RemoveActorAttribute"] = isRemoveActorAttr;

            SetVideoTrackSetting(helper, "Jimaku", jimakuParams.Jimaku);
            SetVideoTrackSetting(helper, "Actor", jimakuParams.Actor);

            SetColorSetting(helper, "Jimaku", jimakuParams.JimakuColor);
            SetColorSetting(helper, "Actor", jimakuParams.ActorColor);

            SetBackgroundSetting(helper, "Jimaku", jimakuBG);
            SetBackgroundSetting(helper, "Actor", actorBG);

            SetMediaBinSetting(helper, "Audio", audioInfo.MediaBin);
            SetMediaBinSetting(helper, "Jimaku", jimakuParams.Jimaku.MediaBin);
            SetMediaBinSetting(helper, "Actor", jimakuParams.Actor.MediaBin);
            SetMediaBinSetting(helper, "JimakuBG", jimakuBG.MediaBin);
            SetMediaBinSetting(helper, "ActorBG", actorBG.MediaBin);

            helper.Settings["CreateOneEventCheck"] = isCreateOne;

            helper.Settings.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Settings["AudioFileFolder"] = info.Folder;
            helper.Settings["AudioTrackName"] = info.Track.Name;
            helper.Settings["AudioInsertInterval"] = info.Interval;
            helper.Settings["IsAudioFolderRecursive"] = info.IsRecursive;
            helper.Settings["IsInsertFromStartPosition"] = info.IsInsertFromStartPosition;
        }

        private void SetVideoTrackSetting(VegasHelper helper, string target, in TextTrackInfo info)
        {
            helper.Settings[target + "TrackName"] = info.Track.Name;
            helper.Settings[target + "PresetName"] = info.PresetName;
            helper.Settings[target + "Margin"] = info.Margin;
        }

        private void SetColorSetting(VegasHelper helper, string target, in ColorInfo info)
        {
            helper.Settings["Use" + target + "ColorSetting"] = info.IsUse;
            helper.Settings[target + "OutlineWidth"] = info.OutlineWidth;

            if (!info.IsUse) { return; }

            helper.Settings[target + "Color"] = info.TextColor;
            helper.Settings[target + "OutlineColor"] = info.OutlineColor;
        }

        private void SetMediaBinSetting(VegasHelper helper, string target, in MediaBinInfo info) {
            helper.Settings["Use" + target + "MediaBin"] = info.IsUse;

            if (!info.IsUse) { return; }

            helper.Settings[target + "MediaBinName"] = info.Name;
        }

        private void SetBackgroundSetting(VegasHelper helper, string target, in BackgroundInfo info)
        {
            helper.Settings["Create" + target + "BG"] = info.IsCreate;

            if (!info.IsCreate) { return; }

            helper.Settings[target + "BGMediaName"] = info.Media.Name;
            helper.Settings[target + "BGMargin"] = info.Margin;
        }
    }
}
