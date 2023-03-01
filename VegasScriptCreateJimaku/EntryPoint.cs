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
    public partial class EntryPoint : IEntryPoint
    {
        private static SettingDialog settingDialog;

        KeyListManager keyListManager;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("CreateJimaku"))
            {
                // ヘルパクラスのオブジェクト生成は必須
                VegasHelper helper = VegasHelper.Instance(vegas);

                Dictionary<string, List<Track>> trackGroupingKeyValue = new Dictionary<string, List<Track>>();

                try
                {
                    JimakuParams jimakuParams = new JimakuParams();
                    List<AudioTrack> audioTracks = helper.AllAudioTracks.ToList();
                    List<VideoTrack> videoTracks = helper.AllVideoTracks.ToList();
                    List<Media> mediaList = helper.GetProjectVideoMediaList();
                    List<MediaBin> mediaBinList = helper.GetMediaBinList();
                    Flags flags = new Flags();

                    if (mediaList.Count == 0)
                    {
                        MessageBox.Show("対象のビデオメディアが存在していません。");
                        return;
                    }

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

                    flags.Behavior = (PrefixBehaviorType)helper.Settings["PrefixBehavior"];
                    flags.IsRemoveActorAttr = helper.Settings["RemoveActorAttribute"];
                    flags.IsCreateOneEventCheck = helper.Settings["CreateOneEventCheck"];

                    BasicTrackStructs trackStructs = new BasicTrackStructs
                    {
                        Tachie = new BasicTrackStruct
                        {
                            IsCreate = helper.Settings["UseTachie"],
                            Info = new TrackInfo<VideoTrack>
                            {
                                Name = helper.Settings["TachieTrackName"],
                                Tracks = new Dictionary<string, VideoTrack>(),
                                Names = new List<string>()
                            }
                        },
                        BG = new BasicTrackStruct
                        {
                            IsCreate = helper.Settings["UseBG"],
                            Info = new TrackInfo<VideoTrack>
                            {
                                Name = helper.Settings["BGTrackName"],
                                Tracks = new Dictionary<string, VideoTrack>(),
                                Names = new List<string>()
                            }
                        }
                    };

                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    SetToDialog(helper, ref keyListManager, ref trackStructs, ref flags);

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // 今後の拡張のため、事前に字幕ファイルを読み込んでおく
                    ReadJimaku(ref jimakuParams, settingDialog);

                    int jimakuLinesCount = helper.CountJimakuLines(jimakuParams.JimakuLines);

                    InsertAudioInfo insertAudioInfo =settingDialog.CreateAudioInfo();
                    insertAudioInfo.JimakuLines = jimakuParams.JimakuLines;

                    int audioFileCount = helper.CountAudioFiles(insertAudioInfo);

                    Debug.WriteLine(string.Format("[Audio]:{0} [Line]:{1}", audioFileCount, jimakuLinesCount));

                    if (audioFileCount != jimakuLinesCount)
                    {
                        MessageBox.Show("セリフ音声ファイルの数と字幕の行数が違います");
                        return;
                    }

                    flags.Behavior = settingDialog.PrefixBehavior;
                    flags.IsRemoveActorAttr = settingDialog.IsRemoveActorAttr;
                    flags.IsCreateOneEventCheck = settingDialog.IsCreateOneEventCheck;

                    settingDialog.GetTachieInfo(ref trackStructs.Tachie);
                    settingDialog.GetBGInfo(ref trackStructs.BG);

                    jimakuParams.IsCreateActorTrack = (flags.Behavior == PrefixBehaviorType.NewEvent);
                    jimakuParams.IsDeletePrefix = (flags.Behavior != PrefixBehaviorType.Remain);

                    List<Track> groupTracks = new List<Track>();

                    // 背景トラック作成
                    if (trackStructs.BG.IsCreate)
                    {
                        trackStructs.BG.Info.Track = helper.CreateVideoTrack(trackStructs.BG.Info.Name);
                        groupTracks.Add(trackStructs.BG.Info.Track);
                    }

                    // オーディオファイル流し込み
                    InsertAudioFile(helper, ref insertAudioInfo, settingDialog, ref keyListManager);

                    // 立ち絵トラック作成(後ろ)
                    CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.Back, ref groupTracks);

                    // 字幕背景挿入処理
                    // こっちを先にしないと字幕が隠れる
                    BackgroundInfo jimakuBGInfo = CreateBackgroundInfo(helper, settingDialog.JimakuBGInfo, ref keyListManager);

                    BackgroundInfo actorBGInfo = CreateBackgroundInfo(helper, settingDialog.ActorBGInfo, ref keyListManager);

                    InsertBackground(helper, ref jimakuBGInfo, ref actorBGInfo, ref insertAudioInfo, flags.IsCreateOneEventCheck, jimakuParams.IsCreateActorTrack, ref groupTracks);

                    // 立ち絵トラック作成(字幕の後ろ)
                    CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.JimakuBack, ref groupTracks);

                    // 字幕挿入処理
                    SetTextInfo(ref jimakuParams.Jimaku, helper, settingDialog.JimakuTrackInfo, ref groupTracks, ref keyListManager);
                    // 声優名挿入処理
                    if (jimakuParams.IsCreateActorTrack)
                    {
                        SetTextInfo(ref jimakuParams.Actor, helper, settingDialog.ActorTrackInfo, ref groupTracks, ref keyListManager);
                        jimakuParams.isRemoveActorAttr = flags.IsRemoveActorAttr;
                    }
                    InsertJimaku(ref jimakuParams, helper, settingDialog, ref insertAudioInfo);

                    groupTracks.Add(insertAudioInfo.Track.Track);

                    // 立ち絵トラック作成(字幕の前)
                    CreateTachieTrack(helper, ref trackStructs.Tachie, TachieType.Front, ref groupTracks);

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
                            ref flags,
                            ref trackStructs.Tachie,
                            trackGroupingKeyValue);
                    }

                    // 設定した設定を保存
                    SaveSetting(
                        helper,
                        ref insertAudioInfo,
                        ref jimakuParams,
                        ref jimakuBGInfo,
                        ref actorBGInfo,
                        ref flags,
                        ref trackStructs);
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

                foreach (string actorName in trackGroupingKeyValue.Keys)
                {
                    helper.AddTrackGroup(trackGroupingKeyValue[actorName], actorName != "" ? actorName : "(声優名なし)");
                }
            }
        }
    }
}
