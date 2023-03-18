using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private static SettingDialog settingDialog;
        private VegasScriptHelper.ExtProc.Jimaku.Counter j_counter;
        private VegasScriptHelper.ExtProc.Audio.Counter a_counter;

        KeyListManager keyListManager;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("CreateJimaku"))
            {
                // ヘルパクラスのオブジェクト生成は必須
                VegasHelper helper = VegasHelper.Instance(vegas);
                j_counter = new VegasScriptHelper.ExtProc.Jimaku.Counter(helper);
                a_counter = new VegasScriptHelper.ExtProc.Audio.Counter(helper);

                Dictionary<string, List<Track>> trackGroupingKeyValue = new Dictionary<string, List<Track>>();

                JimakuParams jimakuParams = new JimakuParams();
                List<AudioTrack> audioTracks = helper.Project.AllAudioTracks.ToList();
                List<VideoTrack> videoTracks = helper.Project.AllVideoTracks.ToList();
                List<Media> mediaList = helper.Media.GetAllVideoList();
                List<MediaBin> mediaBinList = helper.MediaBin.GetList();
                Flags flags = new Flags();
                HypheInfo hypheInfo = CreateHypheInfo(helper);

                // ダイアログに必要な情報の前準備(オーディオ)
                keyListManager.SetupAudio(helper, audioTracks);
                // ダイアログに必要な情報の前準備(ビデオ)
                keyListManager.SetupVideo(helper, videoTracks);
                // ダイアログに必要な情報の前準備(メディアジェネレータ)
                keyListManager.SetupPlugin(helper);
                // ダイアログに必要な情報の前準備(メディア)
                keyListManager.SetupMedia(helper, mediaList);
                // ダイアログに必要な情報の前準備(メディアビン)
                keyListManager.SetupMediaBin(helper, mediaBinList);

                LoadFlagsSetting(helper, ref flags);

                BasicTrackStructs trackStructs = BasicTrackStructs.Create(helper.Config);

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                SetFromInfoToDialog(helper, ref keyListManager, ref trackStructs, ref flags, ref hypheInfo);

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                // 今後の拡張のため、事前に字幕ファイルを読み込んでおく
                ReadJimaku(ref jimakuParams, settingDialog);

                int jimakuLinesCount = j_counter.Get(jimakuParams.JimakuLines);

                InsertAudioInfo insertAudioInfo =settingDialog.AudioInfo;
                insertAudioInfo.JimakuLines = jimakuParams.JimakuLines;

                int audioFileCount = a_counter.Get(insertAudioInfo);

                Debug.WriteLine(string.Format("[Audio]:{0} [Line]:{1}", audioFileCount, jimakuLinesCount));

                if (audioFileCount != jimakuLinesCount)
                {
                    MessageBox.Show("セリフ音声ファイルの数と字幕の行数が違います");
                    return;
                }

                LoadFromDialogToInfo(ref jimakuParams, ref trackStructs, ref flags, ref hypheInfo);

                List<Track> groupTracks = new List<Track>();

                // BGMトラック作成
                if (trackStructs.BGM.IsCreate)
                {
                    trackStructs.BGM.Info.Track = helper.Project.AddAudioTrack(trackStructs.BGM.Info.Name);
                    groupTracks.Add(trackStructs.BGM.Info.Track);
                }

                // オーディオトラック作成
                InsertAudioFile(helper, ref insertAudioInfo, settingDialog, ref keyListManager);
                groupTracks.Add(insertAudioInfo.Track.Track);

                // 背景トラック作成
                if (trackStructs.BG.IsCreate)
                {
                    trackStructs.BG.Info.Track = helper.Project.AddVideoTrack(trackStructs.BG.Info.Name);
                    groupTracks.Add(trackStructs.BG.Info.Track);
                }

                // 立ち絵トラック作成(後ろ)
                CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.Back, ref groupTracks);

                // 字幕背景挿入処理
                // こっちを先にしないと字幕が隠れる
                BackgroundInfo jimakuBGInfo = CreateBackgroundInfo(helper, settingDialog.JimakuBGInfo, ref keyListManager);
                BackgroundInfo actorBGInfo = CreateBackgroundInfo(helper, settingDialog.ActorBGInfo, ref keyListManager);

                InsertBackground(helper, ref jimakuBGInfo, ref actorBGInfo, ref insertAudioInfo, flags.IsCreateOneEventCheck, jimakuParams.IsCreateActorTrack, ref groupTracks);

                // 立ち絵トラック作成(字幕の後ろ)
                CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.JimakuBack, ref groupTracks);

                // 字幕トラック作成
                SetTextInfo(ref jimakuParams.Jimaku, helper, settingDialog.JimakuTrackInfo, ref groupTracks, ref keyListManager);

                // 声優名トラック作成
                if (jimakuParams.IsCreateActorTrack)
                {
                    SetTextInfo(ref jimakuParams.Actor, helper, settingDialog.ActorTrackInfo, ref groupTracks, ref keyListManager);
                    jimakuParams.isRemoveActorAttr = flags.IsRemoveActorAttr;
                }
                InsertJimaku(ref jimakuParams, helper, settingDialog, ref insertAudioInfo);

                // 禁則処理
                if (hypheInfo.IsUse)
                {
                    Hyphenation(helper, ref jimakuParams, hypheInfo);
                }

                // 立ち絵トラック作成(字幕の前)
                CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.Front, ref groupTracks);

                // 各種トラックの振り分け
                if (flags.IsDivideTracks)
                {
                    // グループ作成
                    trackGroupingKeyValue["メイン"] = groupTracks;

                    DivideTracks(
                        helper,
                        ref insertAudioInfo,
                        ref jimakuParams,
                        ref jimakuBGInfo,
                        ref actorBGInfo,
                        ref flags,
                        ref trackStructs.Tachie,
                        trackGroupingKeyValue);

                    // 前景トラック作成
                    // メイングループの対象外にする
                    if (trackStructs.FG.IsCreate)
                    {
                        trackStructs.FG.Info.Track = helper.Project.AddVideoTrack(trackStructs.FG.Info.Name);
                    }
                }
                else
                {
                    // 前景トラック作成
                    // メイングループに入れる
                    if (trackStructs.FG.IsCreate)
                    {
                        trackStructs.FG.Info.Track = helper.Project.AddVideoTrack(trackStructs.FG.Info.Name);
                        groupTracks.Add(trackStructs.FG.Info.Track);
                    }

                    // グループ作成
                    trackGroupingKeyValue["メイン"] = groupTracks;
                }

                foreach (string actorName in trackGroupingKeyValue.Keys)
                {
                    helper.Project.AddTrackGroup(
                        trackGroupingKeyValue[actorName],
                        actorName != "" ? actorName : "(声優名なし)",
                        flags.IsCollapseTrackGroup);
                }

                // 設定した設定を保存
                SaveSetting(
                    helper,
                    ref insertAudioInfo,
                    ref jimakuParams,
                    ref jimakuBGInfo,
                    ref actorBGInfo,
                    ref flags,
                    ref trackStructs,
                    ref hypheInfo);
            }
        }
    }
}
