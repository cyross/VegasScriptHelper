using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptApplySerifuColor
{
    public class EntryPoint: IEntryPoint
    {
        private SettingForm settingForm = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            List<VideoTrack> videoTracks = helper.AllVideoTracks.ToList();

            if (videoTracks.Count == 0)
            {
                MessageBox.Show("ビデオトラックがありません。");
                return;
            }

            VideoTrack selectedVideoTrack = helper.SelectedVideoTrack(false);

            Dictionary<string, VideoTrack> keyValuePairs = helper.GetVideoKeyValuePairs(videoTracks);
            List<string> keyList = keyValuePairs.Keys.ToList();

            try
            {
                if(settingForm == null){ settingForm = new SettingForm(); }

                settingForm.JimakuTrackDataSource = keyList;
                settingForm.JimakuTrackName = selectedVideoTrack != null ? helper.GetTrackKey(selectedVideoTrack) : keyList.First();
                settingForm.OutlineWidth = VegasScriptSettings.JimakuOutlineWidth;

                if (settingForm.ShowDialog() == DialogResult.Cancel) { return; }

                TrackEvents events = helper.GetVideoEvents(keyValuePairs[settingForm.JimakuTrackName]);

                using (new UndoBlock("字幕に色を適応"))
                {
                    helper.ApplyTextColorByActor(events, settingForm.OutlineWidth, settingForm.RemovePrefix);
                }
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
