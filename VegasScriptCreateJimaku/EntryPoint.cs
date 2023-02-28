using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using static VegasScriptCreateJimaku.EntryPoint;
using System.Xml.Linq;

namespace VegasScriptCreateJimaku
{
    public enum TachieType
    {
        Front = 0,
        JimakuBack = 1,
        Back = 2
    }

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

    public struct BasicTrackStruct
    {
        public bool IsCreate;
        public TrackInfo<VideoTrack> Info;
    }

    public struct TrackByActorStruct
    {
        public static readonly string[] TachieTypePostfixs = new string[] { "前", "字幕後ろ", "後ろ" };

        public string Name;
        public AudioTrack Audio;
        public VideoTrack Jimaku;
        public VideoTrack Actor;
        public VideoTrack JimakuBG;
        public VideoTrack ActorBG;
        public Dictionary<string, VideoTrack> Tachie;

        public void CreateAudioTrack(VegasHelper helper, in InsertAudioInfo info, ref List<Track> groupTracks)
        {
            Audio = helper.CreateAudioTrack(GetTrackName(info.Track.Name));
        }

        public void CreateJimakuTrack(VegasHelper helper, in JimakuParams info, ref List<Track> groupTracks)
        {
            Jimaku = helper.CreateVideoTrack(GetTrackName(info.Jimaku.Track.Name));
            groupTracks.Add(Jimaku);
        }

        public void CreateActorTrack(VegasHelper helper, in JimakuParams info, ref List<Track> groupTracks)
        {
            if (!info.IsCreateActorTrack) { return; }

            Actor = helper.CreateVideoTrack(GetTrackName(info.Actor.Track.Name));
            groupTracks.Add(Actor);
        }

        public void CreateTachieTrack(VegasHelper helper, TachieType type, in BasicTrackStruct track, ref List<Track> groupTracks)
        {
            if (!track.IsCreate) { return; }

            string tachieType = TachieTypePostfixs[(int)type];
            Tachie[tachieType] = helper.CreateVideoTrack(GetTrackName(track.Info.Name));
            groupTracks.Add(Tachie[tachieType]);
        }

        public void CreateJimakuBGTrack(VegasHelper helper, in BackgroundInfo info, ref List<Track> groupTracks)
        {
            if (!info.IsCreate) { return; }

            JimakuBG = helper.CreateVideoTrack(GetTrackName(info.Track.Name));
            groupTracks.Add(JimakuBG);
        }

        public void CreateActorBGTrack(VegasHelper helper, in BackgroundInfo info, ref List<Track> groupTracks)
        {
            if (!info.IsCreate) { return; }

            ActorBG = helper.CreateVideoTrack(GetTrackName(info.Track.Name));
            groupTracks.Add(ActorBG);
        }

        public string GetTrackName(string orgTrackName)
        {
            return Name == "" ?  orgTrackName : string.Format("{0}_{1}", orgTrackName, Name);
        }

        public string GetTrackName(string orgTrackName, TachieType type)
        {
            return Name == "" ? orgTrackName : string.Format("{0}_{1}_{2}", orgTrackName, TachieTypePostfixs[(int)type], Name);
        }
    }

    public class EntryPoint : IEntryPoint
    {
        private static SettingDialog settingDialog;

        Dictionary<string, AudioTrack> audioTKV;
        Dictionary<string, VideoTrack> videoTKV;
        Dictionary<string, Media> mKV;
        Dictionary<string, MediaBin> mbKV;

        public void FromVegas(Vegas vegas)
        {
            Dictionary<string, List<Track>> trackGroupingKeyValue = new Dictionary<string, List<Track>>();

            // ヘルパクラスのオブジェクト生成は必須
            VegasHelper helper = VegasHelper.Instance(vegas);

            using (var block = new UndoBlock("CreateJimaku"))
            {
                try
                {

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
                    bool isRemoveActorAttr = helper.Settings["RemoveActorAttribute"];
                    bool isCreateOneEventCheck = helper.Settings["CreateOneEventCheck"];

                    BasicTrackStruct tachieTrack = new BasicTrackStruct
                    {
                        IsCreate = helper.Settings["UseTachie"],
                        Info = new TrackInfo<VideoTrack>
                        {
                            Name = helper.Settings["TachieTrackName"],
                            Tracks = new Dictionary<string, VideoTrack>(),
                            Names = new List<string>()
                        }
                    };

                    BasicTrackStruct bgTrack = new BasicTrackStruct
                    {
                        IsCreate = helper.Settings["UseBG"],
                        Info = new TrackInfo<VideoTrack>
                        {
                            Name = helper.Settings["BGTrackName"],
                            Tracks = new Dictionary<string, VideoTrack>(),
                            Names = new List<string>()
                        }
                    };

                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    settingDialog.SetAudioTrackInfo(helper, klAudio, klAudioMBin);

                    settingDialog.JimakuFilePath = helper.Settings["JimakuFilePath"];
                    settingDialog.PrefixBehavior = prefixBehavior;
                    settingDialog.IsRemoveActorAttr = isRemoveActorAttr;

                    settingDialog.SetJimakuTrackInfo(helper, klJimaku, klJimakuPlugin, klJimakuMBin);

                    settingDialog.SetActorTrackInfo(helper, klActor, klActorPlugin, klActorMBin);

                    settingDialog.SetJimakuColorInfo(helper);

                    settingDialog.SetActorColorInfo(helper);

                    settingDialog.SetJimakuBackgroundInfo(helper, klJimakuBG, klJimakuBGMedia, klJimakuBGMBin);

                    settingDialog.SetActorBackgroundInfo(helper, klActorBG, klActorBGMedia, klActorMBin);

                    settingDialog.SetTachieInfo(tachieTrack);

                    settingDialog.SetBGInfo(bgTrack);

                    settingDialog.IsCreateOneEventCheck = isCreateOneEventCheck;

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // 今後の拡張のため、事前に字幕ファイルを読み込んでおく
                    ReadJimaku(ref jimakuParams, settingDialog);

                    int jimakuLinesCount = helper.CountJimakuLines(jimakuParams.JimakuLines);

                    InsertAudioInfo insertAudioInfo = CreateAudioInfo(settingDialog);
                    insertAudioInfo.JimakuLines = jimakuParams.JimakuLines;

                    int audioFileCount = helper.CountAudioFiles(insertAudioInfo);

                    Debug.WriteLine(string.Format("[Audio]:{0} [Line]:{1}", audioFileCount, jimakuLinesCount));

                    if (audioFileCount != jimakuLinesCount)
                    {
                        MessageBox.Show("セリフ音声ファイルの数と字幕の行数が違います");
                        return;
                    }

                    prefixBehavior = settingDialog.PrefixBehavior;
                    isRemoveActorAttr = settingDialog.IsRemoveActorAttr;
                    isCreateOneEventCheck = settingDialog.IsCreateOneEventCheck;

                    settingDialog.GetTachieInfo(ref tachieTrack);
                    settingDialog.GetBGInfo(ref bgTrack);

                    jimakuParams.IsCreateActorTrack = (prefixBehavior == PrefixBehaviorType.NewEvent);
                    jimakuParams.IsDeletePrefix = (prefixBehavior != PrefixBehaviorType.Remain);

                    List<Track> groupTracks = new List<Track>();

                    // 背景トラック作成
                    if (bgTrack.IsCreate)
                    {
                        bgTrack.Info.Track = helper.CreateVideoTrack(bgTrack.Info.Name);
                        groupTracks.Add(bgTrack.Info.Track);
                    }

                    // オーディオファイル流し込み
                    InsertAudioFile(helper, ref insertAudioInfo, settingDialog);

                    // 立ち絵トラック作成(後ろ)
                    CreateTachieTrack(helper, ref tachieTrack, TachieType.Back, ref groupTracks);

                    // 字幕背景挿入処理
                    // こっちを先にしないと字幕が隠れる
                    BackgroundInfo jimakuBGInfo = CreateBackgroundInfo(helper, settingDialog.JimakuBGInfo);

                    BackgroundInfo actorBGInfo = CreateBackgroundInfo(helper, settingDialog.ActorBGInfo);

                    InsertBackground(helper, ref jimakuBGInfo, ref actorBGInfo, ref insertAudioInfo, isCreateOneEventCheck, jimakuParams.IsCreateActorTrack, ref groupTracks);

                    // 立ち絵トラック作成(字幕の後ろ)
                    CreateTachieTrack(helper, ref tachieTrack, TachieType.JimakuBack, ref groupTracks);

                    // 字幕挿入処理
                    SetTextInfo(ref jimakuParams.Jimaku, helper, settingDialog.JimakuTrackInfo, ref groupTracks);
                    // 声優名挿入処理
                    if (jimakuParams.IsCreateActorTrack)
                    {
                        SetTextInfo(ref jimakuParams.Actor, helper, settingDialog.ActorTrackInfo, ref groupTracks);
                        jimakuParams.isRemoveActorAttr = isRemoveActorAttr;
                    }
                    InsertJimaku(ref jimakuParams, helper, settingDialog, ref insertAudioInfo);

                    groupTracks.Add(insertAudioInfo.Track.Track);

                    // 立ち絵トラック作成(字幕の前)
                    CreateTachieTrack(helper, ref tachieTrack, TachieType.Front, ref groupTracks);

                    // グループ作成

                    trackGroupingKeyValue["メイン"] = groupTracks;

                    // 各種トラックの振り分け
                    if (settingDialog.DivideTracks)
                    {
                        DivideTracks(
                            helper,
                            ref insertAudioInfo,
                            ref jimakuParams,
                            ref jimakuBGInfo,
                            ref actorBGInfo,
                            isCreateOneEventCheck,
                            ref tachieTrack,
                            trackGroupingKeyValue);
                    }

                    // 設定した設定を保存
                    SaveSetting(
                        helper,
                        ref insertAudioInfo,
                        ref jimakuParams,
                        ref jimakuBGInfo,
                        ref actorBGInfo,
                        prefixBehavior,
                        isCreateOneEventCheck,
                        isRemoveActorAttr,
                        ref tachieTrack,
                        ref bgTrack);
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

            using (var block = new UndoBlock("GroupJimakuTracks"))
            {
                foreach (string actorName in trackGroupingKeyValue.Keys)
                {
                    helper.AddTrackGroup(trackGroupingKeyValue[actorName], actorName != "" ? actorName : "(声優名なし)");
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

            List<string> actorLines = new List<string>();
            foreach(var line in jimakuParams.JimakuLines)
            {
                int prefixSeparatorPos = line.IndexOf(":");

                string actorName = (prefixSeparatorPos == -1) ? "" : line.Substring(0, prefixSeparatorPos);

                actorLines.Add(actorName);
            }
            jimakuParams.ActorLines = actorLines.ToArray();
            jimakuParams.ActorSets = new HashSet<string>(actorLines);
        }

        private InsertAudioInfo CreateAudioInfo(SettingDialog dialog)
        {
            return new InsertAudioInfo()
            {
                Folder = dialog.AudioFileFolder,
                Interval = dialog.AudioInterval,
                IsRecursive = dialog.IsRecursive,
                IsInsertFromStartPosition = dialog.IsInsertFromStartPosition,
                StandardSilenceTime = dialog.StandardSilenceTime
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
            ref InsertAudioInfo audioInfo
            )
        {
            jimaku.JimakuColor = CreateColorInfo(dialog.UseJimakuDefaultSettings,
                dialog.JimakuColor, dialog.JimakuOutlineColor, dialog.JimakuOutlineWidth);

            jimaku.ActorColor = CreateColorInfo(dialog.UseActorDefaultSettings,
                dialog.ActorColor, dialog.ActorOutlineColor, dialog.ActorOutlineWidth);

            helper.InsertJimaku(jimaku, audioInfo.Track.Track);
        }

        private void SetTextInfo(
            ref TextTrackInfo info,
            VegasHelper helper,
            DialogTrackInfo trackInfo,
            ref List<Track> trackGroupList)
        {
            info.Track.Name = trackInfo.trackName;
            info.Track.Track = GetVideoTrack(helper, info.Track.Name, videoTKV);
            trackGroupList.Add(info.Track.Track);

            info.PresetName = trackInfo.presetName;
            info.MediaBin = CreateMediaBinInfo(helper, trackInfo.useMediaBin, trackInfo.mediaBinName);
        }

        private void InsertBackground(
            VegasHelper helper,
            ref BackgroundInfo jimakuBGInfo,
            ref BackgroundInfo actorBGInfo,
            ref InsertAudioInfo audioInfo,
            bool isCreateOne,
            bool isCreateActorTrack,
            ref List<Track> trackGroupList)
        {

            // 声優名を後ろに描画
            if (isCreateActorTrack) {
                helper.InsertBackground(actorBGInfo, audioInfo.Track.Track, isCreateOne);
                trackGroupList.Add(actorBGInfo.Track.Track);
            }

            helper.InsertBackground(jimakuBGInfo, audioInfo.Track.Track, isCreateOne);
            trackGroupList.Add(jimakuBGInfo.Track.Track);

            // ２つのトラックで１つのイベントを作った場合はイベントグループ作成
            if (!isCreateOne || !isCreateActorTrack) { return; }

            helper.AddTrackEventGroup(new TrackEvent[]
            {
                jimakuBGInfo.Track.Track.Events[0],
                actorBGInfo.Track.Track.Events[0]
            });
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

        private string GetTachiePostscript(TachieType type)
        {
            return TrackByActorStruct.TachieTypePostfixs[(int)type];
        }

        private string GetTachieTrackName(string name, TachieType type)
        {
            return string.Format("{0}_{1}", name, GetTachiePostscript(type));
        }

        private void CreateTachieTrack(VegasHelper helper, ref BasicTrackStruct tachieTrack, TachieType type, ref List<Track> groupTracks)
        {
            if (!tachieTrack.IsCreate) { return; }

            string name = GetTachieTrackName(tachieTrack.Info.Name, type);
            tachieTrack.Info.Names.Add(name);
            tachieTrack.Info.Tracks[name] = helper.CreateVideoTrack(name);
            groupTracks.Add(tachieTrack.Info.Tracks[name]);
        }

        private void DivideTracks(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            bool isCreateOne,
            ref BasicTrackStruct tachieTrack,
            Dictionary<string, List<Track>> trackGroupingKeyValue)
        {
            Dictionary<string, TrackByActorStruct> tracksByActor = new Dictionary<string, TrackByActorStruct>();

            // 振り分けるトラックを作成
            // 立ち絵は作るだけ
            foreach (var actorName in jimakuParams.ActorSets.ToArray())
            {
                List<Track> groupTracks = new List<Track>();

                TrackByActorStruct actorStruct = new TrackByActorStruct()
                {
                    Name = actorName,
                    Tachie = new Dictionary<string, VideoTrack>()
                };

                actorStruct.CreateAudioTrack(helper, audioInfo, ref groupTracks);

                actorStruct.CreateTachieTrack(helper, TachieType.Back, tachieTrack, ref groupTracks);

                if (!isCreateOne)
                {
                    actorStruct.CreateJimakuBGTrack(helper, jimakuBG, ref groupTracks);
                    if (jimakuParams.IsCreateActorTrack) { actorStruct.CreateActorBGTrack(helper, actorBG, ref groupTracks); }
                }

                actorStruct.CreateTachieTrack(helper, TachieType.JimakuBack, tachieTrack, ref groupTracks);

                actorStruct.CreateJimakuTrack(helper, jimakuParams, ref groupTracks);

                if (jimakuParams.IsCreateActorTrack){ actorStruct.CreateActorTrack(helper, jimakuParams, ref groupTracks); }

                actorStruct.CreateTachieTrack(helper, TachieType.Front, tachieTrack, ref groupTracks);

                tracksByActor[actorName] = actorStruct;

                trackGroupingKeyValue[actorName] = groupTracks;
            }

            foreach (string actorName in jimakuParams.ActorLines)
            {
                TrackByActorStruct actorStruct = tracksByActor[actorName];
                List<TrackEvent> trackEvents = new List<TrackEvent>();

                trackEvents.Add(DivideAudioEvent(audioInfo.Track.Track, actorStruct.Audio));

                if (!isCreateOne)
                {
                    if (jimakuBG.IsCreate) { trackEvents.Add(DivideVideoEvent(jimakuBG.Track.Track, actorStruct.JimakuBG)); }
                    if (jimakuParams.IsCreateActorTrack && actorBG.IsCreate) { trackEvents.Add(DivideVideoEvent(actorBG.Track.Track, actorStruct.ActorBG)); }
                }

                trackEvents.Add(DivideVideoEvent(jimakuParams.Jimaku.Track.Track, actorStruct.Jimaku));
                if (jimakuParams.IsCreateActorTrack) { trackEvents.Add(DivideVideoEvent(jimakuParams.Actor.Track.Track, actorStruct.Actor)); }

                helper.AddTrackEventGroup(trackEvents.ToArray());
            }
        }

        private AudioEvent DivideAudioEvent(AudioTrack src, AudioTrack dst)
        {
            AudioEvent srcEvent = (AudioEvent)src.Events.First();
            AudioEvent dstEvent = dst.AddAudioEvent(srcEvent.Start, srcEvent.Length);
            dstEvent.Name = srcEvent.Name;
            foreach(var take in srcEvent.Takes)
            {
                dstEvent.AddTake(take.MediaStream);
            }
            src.Events.Remove(srcEvent);
            return dstEvent;
        }

        private VideoEvent DivideVideoEvent(VideoTrack src, VideoTrack dst)
        {
            VideoEvent srcEvent = (VideoEvent)src.Events.First();
            VideoEvent dstEvent = dst.AddVideoEvent(srcEvent.Start, srcEvent.Length);
            dstEvent.Name = srcEvent.Name;
            foreach (var take in srcEvent.Takes)
            {
                dstEvent.AddTake(take.MediaStream);
            }
            src.Events.Remove(srcEvent);
            return dstEvent;
        }

        private void SaveSetting(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            PrefixBehaviorType behavior,
            bool isCreateOne,
            bool isRemoveActorAttr,
            ref BasicTrackStruct tachieTrack,
            ref BasicTrackStruct bgTrack)
        {
            SetAudioSetting(helper, audioInfo);

            helper.Settings["JimakuFilePath"] = jimakuParams.JimakuFilePath;

            helper.Settings["PrefixBehavior"] = (int)behavior;

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

            helper.Settings["UseTachie"] = tachieTrack.IsCreate;
            helper.Settings["TachieTrackName"] = tachieTrack.Info.Name;
            helper.Settings["UseBG"] = bgTrack.IsCreate;
            helper.Settings["BGTrackName"] = bgTrack.Info.Name;

            helper.Settings.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Settings["AudioFileFolder"] = info.Folder;
            helper.Settings["AudioTrackName"] = info.Track.Name;
            helper.Settings["AudioInsertInterval"] = info.Interval;
            helper.Settings["IsAudioFolderRecursive"] = info.IsRecursive;
            helper.Settings["IsInsertFromStartPosition"] = info.IsInsertFromStartPosition;
            helper.Settings["StandardSilenceTime"] = info.StandardSilenceTime;
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
