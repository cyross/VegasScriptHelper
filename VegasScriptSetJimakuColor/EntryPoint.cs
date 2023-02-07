using ScriptPortal.Vegas;
using System.Drawing;
using System.Collections.Generic;
using VegasScriptHelper;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System;

namespace VegasScriptSetJimakuColor
{
    public class EntryPoint: IEntryPoint
    {
        private SettingForm settingForm = null;

        public void FromVegas(Vegas vegas)
        {
            try
            {
                VegasHelper helper = VegasHelper.Instance(vegas);

                if (!helper.AllVideoTracks.Any())
                {
                    MessageBox.Show("ビデオトラックがありません");
                    return;
                }

                Dictionary<string, VideoTrack> trackDict = helper.GetVideoKeyValuePairs();
                List<string> trackNames = trackDict.Keys.ToList();

                VideoTrack selected = helper.SelectedVideoTrack(false);

                if (settingForm == null) { settingForm = new SettingForm(); }

                settingForm.TargetVideoTrackDataSource = trackNames;
                settingForm.TargetVideoTrack = selected != null ? helper.GetTrackKey(selected) : trackNames[0];
                settingForm.JimakuColor = VegasScriptSettings.JimakuColor;
                settingForm.OutlineColor = VegasScriptSettings.OutlineColor;
                settingForm.OutlineWidth = VegasScriptSettings.JimakuOutlineWidth;

                if (settingForm.ShowDialog() == DialogResult.Cancel) { return; }

                using (new UndoBlock("字幕の色とアウトラインを指定の色に統一"))
                {
                    helper.SetTextParameterInTrack(
                        trackDict[settingForm.TargetVideoTrack],
                        settingForm.JimakuColor,
                        settingForm.OutlineColor,
                        settingForm.OutlineWidth
                        );
                }

                VegasScriptSettings.JimakuColor = settingForm.JimakuColor;
                VegasScriptSettings.OutlineColor = settingForm.OutlineColor;
                VegasScriptSettings.JimakuOutlineWidth = settingForm.OutlineWidth;
                VegasScriptSettings.Save();
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したトラックにイベントがありません。");
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
