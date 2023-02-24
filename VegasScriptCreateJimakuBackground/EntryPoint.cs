using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateJimakuBackground
{
    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("CreateJimakuBackground"))
            {
                try
                {
                    // ヘルパクラスのオブジェクト生成は必須
                    VegasHelper helper = VegasHelper.Instance(vegas);

                    // ダイアログに必要な情報の前準備(オーディオ)
                    List<AudioTrack> audioTracks = helper.AllAudioTracks.ToList();

                    List<VideoTrack> videoTracks = helper.AllVideoTracks.ToList();

                    List<Media> mediaList = helper.GetProjectVideoMediaList();

                    if (audioTracks.Count == 0)
                    {
                        MessageBox.Show("オーディオトラックが存在していません。");
                        return;
                    }

                    if (mediaList.Count == 0)
                    {
                        MessageBox.Show("対象のビデオメディアが存在していません。");
                        return;
                    }

                    Dictionary<string, AudioTrack> audioKeyValuePairs = helper.GetAudioKeyValuePairs(audioTracks);
                    List<string> audioKeyList = audioKeyValuePairs.Keys.ToList();

                    AudioTrack selectedAudioTrack = helper.SelectedAudioTrack(false);

                    string firstAudioTrackKey = selectedAudioTrack != null ? helper.GetTrackKey(selectedAudioTrack) : audioKeyList.First();

                    // ダイアログに必要な情報の前準備(ビデオ)
                    Dictionary<string, VideoTrack> videoKeyValuePairs = helper.GetVideoKeyValuePairs(videoTracks);
                    List<string> videoKeyList = videoKeyValuePairs.Keys.ToList();

                    VideoTrack selectedVideoTrack = helper.SelectedVideoTrack(false);

                    string firstVideoTrackKey = selectedVideoTrack != null ? helper.GetTrackKey(selectedVideoTrack) : videoKeyList.Count > 0 ? videoKeyList.First() : "";

                    // ダイアログに必要な情報の前準備(メディア)
                    Dictionary<string, Media> mediaKeyValuePairs = helper.GetProjectMediaKeyValuePairs(mediaList);
                    List<string> mediaKeyList = mediaKeyValuePairs.Keys.ToList();

                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    settingDialog.AudioTrackBoxDataSource = audioKeyList;
                    settingDialog.AudioTrackName = firstAudioTrackKey;
                    settingDialog.VideoTrackBoxDataSource = videoKeyList;
                    settingDialog.VideoTrackName = firstVideoTrackKey;
                    settingDialog.TargetMediaBoxDataSource = mediaKeyList;
                    settingDialog.TargetMediaName = mediaKeyList.First();

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    AudioTrack audioTrack = audioKeyValuePairs[settingDialog.AudioTrackName];
                    string videoTrackName = settingDialog.VideoTrackName;
                    VideoTrack videoTrack = videoKeyValuePairs.ContainsKey(videoTrackName) ? videoKeyValuePairs[videoTrackName] : helper.CreateVideoTrack(videoTrackName);
                    Media targetMedia = mediaKeyValuePairs[settingDialog.TargetMediaName];

                    if(settingDialog.IscreateOneEventCheck)
                    {
                        helper.CreateFullSizeVideoEventWithAudioTrack(videoTrack, audioTrack, targetMedia, settingDialog.EventMargin);
                    }
                    else
                    {
                        helper.CreateVideoEventWithAudioTrack(videoTrack, audioTrack, targetMedia, settingDialog.EventMargin);
                    }
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
    }
}
