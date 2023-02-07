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
        private SettingDialog settingDialog = null;

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
                if(settingDialog == null){ settingDialog = new SettingDialog(); }

                settingDialog.JimakuTrackDataSource = keyList;
                settingDialog.JimakuTrackName = selectedVideoTrack != null ? helper.GetTrackKey(selectedVideoTrack) : keyList.First();
                settingDialog.OutlineWidth = VegasScriptSettings.JimakuOutlineWidth;

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                TrackEvents events = helper.GetVideoEvents(keyValuePairs[settingDialog.JimakuTrackName]);

                using (new UndoBlock("字幕に色を適応"))
                {
                    helper.ApplyTextColorByActor(events, settingDialog.OutlineWidth, settingDialog.RemovePrefix);
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
