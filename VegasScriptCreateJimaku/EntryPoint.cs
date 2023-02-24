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
    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog;

        private List<AudioTrack> audioTracks;
        private List<VideoTrack> videoTracks;
        private List<Media> mediaList;
        private List<MediaBin> mediaBinList;

        private Dictionary<string, AudioTrack> audioKeyValuePairs;
        private List<string> audioKeyList;
        private string firstAudioTrackKey;

        private Dictionary<string, VideoTrack> videoKeyValuePairs;
        private List<string> jimakuKeyList;
        private List<string> actorKeyList;
        private List<string> jimakuBackgroundKeyList;
        private List<string> actorBackgroundKeyList;
        private string firstJimakuTrackKey;
        private string firstActorTrackKey;
        private string firstJimakuBackgroundTrackKey;
        private string firstActorBackgroundTrackKey;

        private List<string> jimakuPluginKeyList;
        private List<string> actorPluginKeyList;
        private string firstJimakuPluginKey;
        private string firstActorPluginKey;

        private Dictionary<string, Media> mediaKeyValuePairs;
        private List<string> jimakuBackgroundMediaKeyList;
        private List<string> actorBackgroundMediaKeyList;
        private string firstJimakuBackgroundMediaKey;
        private string firstActorBackgroundMediaKey;

        private Dictionary<string, MediaBin> mediaBinKeyValuePairs;
        private List<string> audioMediaBinKeyList;
        private List<string> jimakuMediaBinKeyList;
        private List<string> actorMediaBinKeyList;
        private List<string> jimakuBackgroundMediaBinKeyList;
        private List<string> actorBackgroundMediaBinKeyList;
        private string firstAudioMediaBinKey;
        private string firstJimakuMediaBinTrackKey;
        private string firstActorMediaBinKey;
        private string firstJimakuBackgroundMediaBinKey;
        private string firstActorBackgroundMediaBinKey;

        private InsertAudioInfo insertAudioInfo;

        private PrefixBehaviorType prefixBehavior;

        private JimakuParams jimakuParams;

        private bool isGroupSerifuJimakuEvent;

        private BackgroundInfo JimakuBackgroundInfo;

        private BackgroundInfo ActorBackgroundInfo;

        private MediaBinInfo jimakuBackgroundMediaBinInfo;

        private MediaBinInfo actorBackgroundMediaBinInfo;

        private bool isCreateOneEventCheck;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("CreateJimaku"))
            {
                try
                {
                    // ヘルパクラスのオブジェクト生成は必須
                    VegasHelper helper = VegasHelper.Instance(vegas);

                    audioTracks = helper.AllAudioTracks.ToList();
                    videoTracks = helper.AllVideoTracks.ToList();
                    mediaList = helper.GetProjectVideoMediaList();
                    mediaBinList = helper.GetMediaBinList();

                    if (mediaList.Count == 0)
                    {
                        MessageBox.Show("対象のビデオメディアが存在していません。");
                        return;
                    }

                    // ダイアログに必要な情報の前準備(オーディオ)
                    audioKeyValuePairs = helper.GetAudioKeyValuePairs(audioTracks);

                    audioKeyList = audioKeyValuePairs.Keys.ToList();
                    firstAudioTrackKey = GetFirstKey(audioKeyList, helper.Settings["AudioTrackName"]);

                    // ダイアログに必要な情報の前準備(ビデオ)
                    videoKeyValuePairs = helper.GetVideoKeyValuePairs(videoTracks);

                    jimakuKeyList = videoKeyValuePairs.Keys.ToList();
                    firstJimakuTrackKey = GetFirstKey(jimakuKeyList, helper.Settings["JimakuTrackName"]);

                    actorKeyList = videoKeyValuePairs.Keys.ToList();
                    firstActorTrackKey = GetFirstKey(actorKeyList, helper.Settings["ActorTrackName"]);

                    jimakuBackgroundKeyList = videoKeyValuePairs.Keys.ToList();
                    firstJimakuBackgroundTrackKey = GetFirstKey(jimakuBackgroundKeyList, helper.Settings["JimakuBackgroundTrackName"]);

                    actorBackgroundKeyList = videoKeyValuePairs.Keys.ToList();
                    firstActorBackgroundTrackKey = GetFirstKey(actorBackgroundKeyList, helper.Settings["ActorBackgroundTrackName"]);

                    // ダイアログに必要な情報の前準備(メディアジェネレータ)
                    jimakuPluginKeyList = helper.GetTitlePluginPresetNames();
                    firstJimakuPluginKey = GetFirstKey(jimakuPluginKeyList, helper.Settings["JimakuPresetName"]);

                    actorPluginKeyList = helper.GetTitlePluginPresetNames();
                    firstActorPluginKey = GetFirstKey(actorPluginKeyList, helper.Settings["ActorPresetName"]);

                    // ダイアログに必要な情報の前準備(メディア)
                    mediaKeyValuePairs = helper.GetProjectMediaKeyValuePairs(mediaList);

                    jimakuBackgroundMediaKeyList = mediaKeyValuePairs.Keys.ToList();
                    firstJimakuBackgroundMediaKey = GetFirstKey(jimakuBackgroundMediaKeyList, helper.Settings["JimakuBackgroundMediaName"]);

                    actorBackgroundMediaKeyList = mediaKeyValuePairs.Keys.ToList();
                    firstActorBackgroundMediaKey = GetFirstKey(actorBackgroundMediaKeyList, helper.Settings["ActorBackgrondMediaName"]);

                    // ダイアログに必要な情報の前準備(メディアビン)
                    mediaBinKeyValuePairs = helper.GetMediaBinKeyValuePairs(mediaBinList);

                    audioMediaBinKeyList = mediaBinKeyValuePairs.Keys.ToList();
                    firstAudioMediaBinKey = GetFirstKey(audioMediaBinKeyList, helper.Settings["AudioMediaBinName"]);

                    jimakuMediaBinKeyList = mediaBinKeyValuePairs.Keys.ToList();
                    firstJimakuMediaBinTrackKey = GetFirstKey(jimakuMediaBinKeyList, helper.Settings["JimakuMediaBinName"]);

                    actorMediaBinKeyList = mediaBinKeyValuePairs.Keys.ToList();
                    firstActorMediaBinKey = GetFirstKey(actorMediaBinKeyList, helper.Settings["ActorMediaBinName"]);

                    jimakuBackgroundMediaBinKeyList = mediaBinKeyValuePairs.Keys.ToList();
                    firstJimakuBackgroundMediaBinKey = GetFirstKey(jimakuBackgroundMediaBinKeyList, helper.Settings["JimakuBackgroundMediaBinName"]);

                    actorBackgroundMediaBinKeyList = mediaBinKeyValuePairs.Keys.ToList();
                    firstActorBackgroundMediaBinKey = GetFirstKey(actorBackgroundMediaBinKeyList, helper.Settings["ActorBackgroundMediaBinName"]);

                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    SetupSettingDialog(helper);

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // 今後の拡張のため、事前に字幕ファイルを読み込んでおく
                    ReadJimaku();

                    SetAudioInfo();

                    int audioFileCount = helper.CountAudioFiles(insertAudioInfo);

                    Debug.WriteLine(string.Format("[Audio]:{0} [Line]:{1}", audioFileCount, jimakuParams.JimakuLines.Length));

                    if (audioFileCount != jimakuParams.JimakuLines.Length)
                    {
                        MessageBox.Show("セリフ音声ファイルの数と字幕の行数が違います");
                        return;
                    }

                    // オーディオファイル流し込み
                    InsertAudioFile(helper);

                    prefixBehavior = settingDialog.PrefixBehavior;
                    isGroupSerifuJimakuEvent = settingDialog.IsEventGroupCheck;

                    // 字幕背景挿入処理
                    // こっちを先にしないと字幕が隠れる
                    InsertBackground(helper);

                    // 字幕挿入処理
                    InsertJimaku(helper);

                    SaveSetting(helper);

                    MessageBox.Show("処理が完了しました");
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
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateMediaBin(name);
        }

        private string GetFirstKey(List<string> list, string name)
        {
            if (name.Length > 0) { return name; }
            if (list.Count > 0) { return list.First(); }
            return "";
        }

        private void ReadJimaku()
        {
            jimakuParams.JimakuFilePath = settingDialog.JimakuFilePath;

            using (var jimakuFile = new StreamReader(jimakuParams.JimakuFilePath))
            {
                jimakuParams.JimakuLines = jimakuFile.ReadToEnd().Split(new char[] { '\n' }).Select(s => s.Replace("\r", "")).Where(s => s.Length > 0).ToArray();
            }
        }

        private void SetAudioInfo()
        {
            insertAudioInfo.Folder = settingDialog.AudioFileFolder;
            insertAudioInfo.Interval = settingDialog.AudioInterval;
            insertAudioInfo.IsRecursive = settingDialog.IsRecursive;
            insertAudioInfo.IsInsertFromStartPosition = settingDialog.IsInsertFromStartPosition;
        }

        private void InsertAudioFile(VegasHelper helper)
        {
            insertAudioInfo.TrackName = settingDialog.AudioTrackName;
            insertAudioInfo.Track = GetAudioTrack(helper, insertAudioInfo.TrackName, audioKeyValuePairs);

            SetMediaBinInfo(helper, ref insertAudioInfo.MediaBinInfo, settingDialog.UseAudioMediaBin, settingDialog.AudioMediaBinName);

            helper.InseretAudioInTrack(ref insertAudioInfo);
        }

        private void InsertJimaku(VegasHelper helper)
        {
            jimakuParams.JimakuInfo.TrackName = settingDialog.JimakuTrackName;
            jimakuParams.JimakuInfo.Track = GetVideoTrack(helper, jimakuParams.JimakuInfo.TrackName, videoKeyValuePairs);

            jimakuParams.IsCreateActorTrack = (prefixBehavior == PrefixBehaviorType.NewEvent);
            jimakuParams.IsDeletePrefix = (prefixBehavior != PrefixBehaviorType.Remain);

            jimakuParams.JimakuInfo.PresetName = settingDialog.JimakuPresetName;

            SetMediaBinInfo(helper, ref jimakuParams.JimakuInfo.MediaBinInfo,
                settingDialog.UseJimakuMediaBin, settingDialog.JimakuMediaBinName);

            if (jimakuParams.IsCreateActorTrack)
            {
                jimakuParams.ActorInfo.TrackName = settingDialog.ActorTrackName;
                jimakuParams.ActorInfo.Track = GetVideoTrack(helper, jimakuParams.ActorInfo.TrackName, videoKeyValuePairs);

                jimakuParams.ActorInfo.PresetName = settingDialog.ActorPresetName;

                SetMediaBinInfo(helper, ref jimakuParams.ActorInfo.MediaBinInfo,
                    settingDialog.UseActorMediaBin, settingDialog.ActorMediaBinName);
            }

            SetColorInfo(ref jimakuParams.JimakuColorInfo, settingDialog.UseJimakuDefaultSettings,
                settingDialog.JimakuColor, settingDialog.JimakuOutlineColor, settingDialog.JimakuOutlineWidth);

            SetColorInfo(ref jimakuParams.ActorColorInfo, settingDialog.UseActorDefaultSettings,
                settingDialog.ActorColor, settingDialog.ActorOutlineColor, settingDialog.ActorOutlineWidth);

            helper.InsertJimaku(jimakuParams, insertAudioInfo.Track, isGroupSerifuJimakuEvent);
        }

        private void InsertBackground(VegasHelper helper)
        {
            SetBackgroundInfo(helper, ref JimakuBackgroundInfo,
                settingDialog.CreateJimakuBackground,
                settingDialog.JimakuBackgroundTrackName,
                settingDialog.JimakuBackgroundMediaName,
                settingDialog.JimakuBackgroundMargin);

            SetBackgroundInfo(helper, ref ActorBackgroundInfo,
                settingDialog.CreateActorBackground,
                settingDialog.ActorBackgroundTrackName,
                settingDialog.ActorBackgroundMediaName,
                settingDialog.JimakuBackgroundMargin);

            SetMediaBinInfo(helper, ref jimakuBackgroundMediaBinInfo,
                settingDialog.UseJimakuBackgroundMediaBin, settingDialog.JimakuBackgroundMediaBinName);

            SetMediaBinInfo(helper, ref actorBackgroundMediaBinInfo,
                settingDialog.UseActorBackgroundMediaBin, settingDialog.ActorBackgroundMediaBinName);

            isCreateOneEventCheck = settingDialog.IsCreateOneEventCheck;

            helper.InsertBackground(JimakuBackgroundInfo, insertAudioInfo.Track, isCreateOneEventCheck);

            helper.InsertBackground(ActorBackgroundInfo, insertAudioInfo.Track, isCreateOneEventCheck);
        }

        private void SetupSettingDialog(VegasHelper helper)
        {
            settingDialog.SetAudioTrack(helper, audioKeyList, firstAudioTrackKey, audioMediaBinKeyList, firstAudioMediaBinKey);

            settingDialog.JimakuFilePath = helper.Settings["JimakuFilePath"];
            settingDialog.PrefixBehavior = (PrefixBehaviorType)helper.Settings["PrefixBehavior"];
            settingDialog.IsEventGroupCheck = helper.Settings["IsGroupSerifuJimakuEvent"];

            settingDialog.SetJimakuTrack(helper,
                jimakuKeyList, firstJimakuTrackKey,
                jimakuPluginKeyList, firstJimakuPluginKey,
                jimakuMediaBinKeyList, firstJimakuMediaBinTrackKey);

            settingDialog.SetActorTrack(helper,
                actorKeyList, firstActorTrackKey,
                actorPluginKeyList, firstActorPluginKey,
                actorMediaBinKeyList, firstActorMediaBinKey);

            settingDialog.SetJimakuColor(helper);

            settingDialog.SetActorColor(helper);

            settingDialog.SetJimakuBackground(helper,
                jimakuBackgroundKeyList, firstJimakuBackgroundTrackKey,
                jimakuBackgroundMediaKeyList, firstJimakuBackgroundMediaKey,
                jimakuBackgroundMediaBinKeyList, firstJimakuBackgroundMediaBinKey);

            settingDialog.SetActorBackground(helper,
                actorBackgroundKeyList, firstActorBackgroundTrackKey,
                actorBackgroundMediaKeyList, firstActorBackgroundMediaKey,
                actorBackgroundMediaBinKeyList, firstActorBackgroundMediaBinKey);

            settingDialog.IsCreateOneEventCheck = helper.Settings["CreateOneEventCheck"];
        }

        private void SaveSetting(VegasHelper helper)
        {
            SetAudioSetting(helper, insertAudioInfo);

            helper.Settings["JimakuFilePath"] = jimakuParams.JimakuFilePath;

            helper.Settings["PrefixBehavior"] = (int)prefixBehavior;

            helper.Settings["IsGroupSerifuJimakuEvent"] = isGroupSerifuJimakuEvent;

            helper.Settings["JimakuTrackName"] = jimakuParams.JimakuInfo.TrackName;
            helper.Settings["JimakuPresetName"] = jimakuParams.JimakuInfo.PresetName;
            helper.Settings["JimakuMargin"] = jimakuParams.JimakuInfo.Margin;
            helper.Settings["ActorTrackName"] = jimakuParams.ActorInfo.TrackName;
            helper.Settings["ActorPresetName"] = jimakuParams.ActorInfo.PresetName;
            helper.Settings["ActorMargin"] = jimakuParams.ActorInfo.Margin;

            SetColorSetting(helper, "Jimaku", jimakuParams.JimakuColorInfo);

            SetColorSetting(helper, "Actor", jimakuParams.ActorColorInfo);

            SetBackgroundSetting(helper,
                "CreateJimakuBackground",
                "JimakuBackgroundMediaName",
                "JimakuBackgroundMargin",
                JimakuBackgroundInfo);

            SetBackgroundSetting(helper,
                "CreateActorBackground",
                "ActorBackgroundMediaName",
                "ActorBackgroundMargin",
                JimakuBackgroundInfo);

            SetMediaBinSetting(helper, "UseAudioMediaBin", "AudioMediaBinName", insertAudioInfo.MediaBinInfo);

            SetMediaBinSetting(helper, "UseJimakuMediaBin", "JimakuMediaBinName", jimakuParams.JimakuInfo.MediaBinInfo);

            SetMediaBinSetting(helper, "UseActorMediaBin", "ActorMediaBinName", jimakuParams.ActorInfo.MediaBinInfo);

            SetMediaBinSetting(helper, "UseJimakuBackgroundMediaBin", "JimakuBackgroundMediaBinName", jimakuBackgroundMediaBinInfo);

            SetMediaBinSetting(helper, "UseActorBackgroundMediaBin", "ActorBackgroundMediaBinName", actorBackgroundMediaBinInfo);

            helper.Settings["CreateOneEventCheck"] = isCreateOneEventCheck;

            helper.Settings.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Settings["AudioFileFolder"] = info.Folder;
            helper.Settings["AudioTrackName"] = info.TrackName;
            helper.Settings["AudioInsertInterval"] = info.Interval;
            helper.Settings["IsAudioFolderRecursive"] = info.IsRecursive;
            helper.Settings["IsInsertFromStartPosition"] = info.IsInsertFromStartPosition;
        }

        private void SetColorInfo(ref ColorInfo info, bool isUse, Color textColor, Color outlineColor, double outlineWidth)
        {
            info.IsUse = isUse;
            info.OutlineWidth = outlineWidth;

            if (!info.IsUse) { return; }

            info.TextColor = textColor;
            info.OutlineColor = outlineColor;
        }

        private void SetColorSetting(VegasHelper helper, string target, in ColorInfo info)
        {
            helper.Settings["Use" + target + "ColorSetting"] = info.IsUse;

            if (!info.IsUse) { return; }

            helper.Settings[target + "Color"] = info.TextColor;
            helper.Settings[target + "OutlineColor"] = info.OutlineColor;
            helper.Settings[target + "OutlineWidth"] = info.OutlineWidth;
        }

        private void SetMediaBinInfo(VegasHelper helper, ref MediaBinInfo info, bool isUse, string name)
        {
            info.IsUse = isUse;

            if (!info.IsUse) { return; }

            info.Name = name;
            info.Bin = GetMediaBin(helper, name, mediaBinKeyValuePairs);
        }

        private void SetMediaBinSetting(VegasHelper helper, string flagName, string settingName, in MediaBinInfo info) {
            helper.Settings[flagName] = info.IsUse;

            if (!info.IsUse) { return; }

            helper.Settings[settingName] = info.Name;
        }

        private void SetBackgroundInfo(VegasHelper helper, ref BackgroundInfo info, bool IsCreate, string trackName, string mediaName, double margin)
        {
            info.IsCreate = IsCreate;

            if (!info.IsCreate) { return; }

            info.TrackName = trackName;
            info.Track = GetVideoTrack(helper, trackName, videoKeyValuePairs);
            info.MediaName = mediaName;
            info.Media = mediaKeyValuePairs[mediaName];
            info.Margin = margin;
        }

        private void SetBackgroundSetting(VegasHelper helper, string flagName, string mediaName, string marginName, in BackgroundInfo info)
        {
            helper.Settings[flagName] = info.IsCreate;

            if (!info.IsCreate) { return; }

            helper.Settings[mediaName] = info.MediaName;
            helper.Settings[marginName] = info.Margin;
        }
    }
}
