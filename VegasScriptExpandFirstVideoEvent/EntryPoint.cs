using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptExpandFirstVideoEvent
{
    public class EntryPoint: IEntryPoint
    {
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            try
            {
                VegasHelper helper = VegasHelper.Instance(vegas);

                // コンボボックッスの既定値の優先度:
                // 1)選択したトラック
                // 2)指定の名前のトラック
                // 3)最初のトラック
                Dictionary<string, VideoTrack> videoKeyValuePairs = helper.GetVideoKeyValuePairs();
                List<string> videoKeyList = videoKeyValuePairs.Keys.ToList();

                if (!videoKeyList.Any())
                {
                    MessageBox.Show("ビデオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Dictionary<string, AudioTrack> audioKeyValuePairs = helper.GetAudioKeyValuePairs();
                List<string> audioKeyList = audioKeyValuePairs.Keys.ToList();

                if (!audioKeyList.Any())
                {
                    MessageBox.Show("オーディオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                VideoTrack targetVideoTrack = helper.SelectedVideoTrack(false);

                if (targetVideoTrack == null)
                {
                    targetVideoTrack = helper.SearchVideoTrackByName(helper.Settings[SN.WdJimaku.Track.Name]);
                }

                string videoTrackKey = targetVideoTrack != null ? helper.GetTrackKey(targetVideoTrack) : videoKeyList[0];

                AudioTrack targetAudioTrack = helper.SelectedAudioTrack(false);

                if (targetAudioTrack == null)
                {
                    targetAudioTrack = helper.SearchAudioTrackByName(helper.Settings[SN.WdAudio.Track.Name]);
                }

                string audioTrackKey = targetAudioTrack != null ? helper.GetTrackKey(targetAudioTrack) : audioKeyList[0];

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.VideoTrackNameDataSource = videoKeyList;
                settingDialog.VideoTrackName = videoTrackKey;
                settingDialog.AudioTrackNameDataSource = audioKeyList;
                settingDialog.AudioTrackName = audioTrackKey;
                settingDialog.ExpandMargin = helper.Settings[SN.WdVideo.Expand.Event.Margin];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                double margin = settingDialog.ExpandMargin;
                VideoTrack videoTrack = videoKeyValuePairs[settingDialog.VideoTrackName];
                AudioTrack audioTrack = audioKeyValuePairs[settingDialog.AudioTrackName];

                using(new UndoBlock("ビデオトラックの最初のイベントの長さをオーディオトラックに合わせる"))
                {
                    helper.ExpandFirstVideoEvent(videoTrack, audioTrack, margin);
                }

                helper.Settings[SN.WdAudio.Track.Name] = audioTrack.Name;
                helper.Settings[SN.WdJimaku.Track.Name] = videoTrack.Name;
                helper.Settings[SN.WdVideo.Expand.Event.Margin] = margin;
                helper.Settings.Save();
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
            catch (Exception ex)
            {
                string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                Debug.WriteLine("---[Exception In Helper]---");
                Debug.WriteLine(errMessage);
                Debug.WriteLine("---------------------------");
                MessageBox.Show(
                    errMessage,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw ex;
            }
        }
    }
}
