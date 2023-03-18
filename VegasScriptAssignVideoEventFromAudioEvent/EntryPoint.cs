using ScriptPortal.Vegas;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Duration;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;
using VegasScriptHelper.Structs;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

namespace VegasScriptAssignVideoEventFromAudioEvent
{
    public class EntryPoint: IEntryPoint
    {
        private static SettingDialog settingDialog = null;
        private Assigner assigner = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);
            assigner = new Assigner(helper);

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

            if(targetVideoTrack == null) {
                targetVideoTrack = helper.Project.SearchVideoTrack(helper.Config[Names.WdJimaku.Track.Name]);
            }

            string videoTrackKey = targetVideoTrack != null ? helper.Track.GetKey(targetVideoTrack) : videoKeyList[0];

            AudioTrack targetAudioTrack = helper.Project.SelectedAudioTrack(false);

            if (targetAudioTrack == null)
            {
                targetAudioTrack = helper.Project.SearchAudioTrack(helper.Config[Names.WdAudio.Track.Name]);
            }

            string audioTrackKey = targetAudioTrack != null ? helper.Track.GetKey(targetAudioTrack) : audioKeyList[0];

            try
            {
                if(settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.VoiceTrackNameDataSource = audioKeyList;
                settingDialog.VoiceTrackName = audioTrackKey;
                settingDialog.JimakuTrackNameDataSource = videoKeyList;
                settingDialog.JimakuTrackName = videoTrackKey;
                settingDialog.JimakuMargin = helper.Config[Names.WdJimaku.Margin];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                VideoTrack videoTrack = videoKeyValuePairs[settingDialog.JimakuTrackName];
                AudioTrack audioTrack = audioKeyValuePairs[settingDialog.VoiceTrackName];
                double margin = settingDialog.JimakuMargin;

                using(new UndoBlock("ビデオイベントの長さをオーディオイベントに合わせる"))
                {
                    AssignDurationInfo info = new AssignDurationInfo()
                    {
                        VideoTrack = videoTrack,
                        AudioTrack = audioTrack,
                        Margin = margin
                    };
                    assigner.Exec(info);
                }

                helper.Config[Names.WdAudio.Track.Name] = audioTrack.Name;
                helper.Config[Names.WdJimaku.Track.Name] = videoTrack.Name;
                helper.Config[Names.WdJimaku.Margin] = margin;
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
