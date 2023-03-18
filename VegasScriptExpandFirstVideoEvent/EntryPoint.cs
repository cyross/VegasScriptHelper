using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Event;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;

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
                Dictionary<string, VideoTrack> videoKeyValuePairs = helper.VideoTrack.KV;
                List<string> videoKeyList = videoKeyValuePairs.Keys.ToList();

                if (!videoKeyList.Any())
                {
                    MessageBox.Show("ビデオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Dictionary<string, AudioTrack> audioKeyValuePairs = helper.AudioTrack.KV;
                List<string> audioKeyList = audioKeyValuePairs.Keys.ToList();

                if (!audioKeyList.Any())
                {
                    MessageBox.Show("オーディオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                VideoTrack targetVideoTrack = helper.Project.SelectedVideoTrack(false);

                if (targetVideoTrack == null)
                {
                    targetVideoTrack = helper.Project.SearchVideoTrack(helper.Config[Names.WdJimaku.Track.Name]);
                }

                string videoTrackKey = targetVideoTrack != null ? helper.Track.GetKey(targetVideoTrack) : videoKeyList[0];

                AudioTrack targetAudioTrack = helper.Project.SelectedAudioTrack(false);

                if (targetAudioTrack == null)
                {
                    targetAudioTrack = helper.Project.SearchAudioTrack(helper.Config[Names.WdAudio.Track.Name]);
                }

                string audioTrackKey = targetAudioTrack != null ? helper.Track.GetKey(targetAudioTrack) : audioKeyList[0];

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.VideoTrackNameDataSource = videoKeyList;
                settingDialog.VideoTrackName = videoTrackKey;
                settingDialog.AudioTrackNameDataSource = audioKeyList;
                settingDialog.AudioTrackName = audioTrackKey;
                settingDialog.ExpandMargin = helper.Config[Names.WdVideo.Expand.Event.Margin];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                double margin = settingDialog.ExpandMargin;
                VideoTrack videoTrack = videoKeyValuePairs[settingDialog.VideoTrackName];
                AudioTrack audioTrack = audioKeyValuePairs[settingDialog.AudioTrackName];

                using(new UndoBlock("ビデオトラックの最初のイベントの長さをオーディオトラックに合わせる"))
                {
                    Expander expander = new Expander(helper);
                    expander.Exec(videoTrack, audioTrack, margin);
                }

                helper.Config[Names.WdAudio.Track.Name] = audioTrack.Name;
                helper.Config[Names.WdJimaku.Track.Name] = videoTrack.Name;
                helper.Config[Names.WdVideo.Expand.Event.Margin] = margin;
                helper.Config.Save();
            }
            catch (VHTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VHNoneEventsException)
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
