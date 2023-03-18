using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;
using VegasScriptHelper.ExtProc.Event;

namespace VegasScriptApplySerifuColor
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;
        private ColorApplier applier = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);
            applier = new ColorApplier(helper);

            List<VideoTrack> videoTracks = helper.Project.AllVideoTracks.ToList();

            if (videoTracks.Count == 0)
            {
                MessageBox.Show("ビデオトラックがありません。");
                return;
            }

            VideoTrack selectedVideoTrack = helper.Project.SelectedVideoTrack(false);

            Dictionary<string, VideoTrack> keyValuePairs = helper.VideoTrack.GetKV(videoTracks);
            List<string> keyList = keyValuePairs.Keys.ToList();

            try
            {
                if(settingDialog == null){ settingDialog = new SettingDialog(); }

                settingDialog.JimakuTrackDataSource = keyList;
                settingDialog.JimakuTrackName = selectedVideoTrack != null ? helper.Track.GetKey(selectedVideoTrack) : keyList.First();
                settingDialog.OutlineWidth = helper.Config[Names.WdJimaku.Outline.Width];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                TrackEvents events = helper.VideoTrack.Events(keyValuePairs[settingDialog.JimakuTrackName]);

                using (new UndoBlock("字幕に色を適応"))
                {
                    applier.Exec(events, settingDialog.OutlineWidth, settingDialog.RemovePrefix);
                }

                helper.Config[Names.WdJimaku.Outline.Width] = settingDialog.OutlineWidth;
                helper.Config.Save();
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
