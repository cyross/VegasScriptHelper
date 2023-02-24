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
        private SettingDialog settingDialog = null;

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

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.TargetVideoTrackDataSource = trackNames;
                settingDialog.TargetVideoTrack = selected != null ? helper.GetTrackKey(selected) : trackNames[0];
                settingDialog.JimakuColor = helper.Settings["JimakuColor"];
                settingDialog.OutlineColor = helper.Settings["JimakuOutlineColor"];
                settingDialog.OutlineWidth = helper.Settings["JimakuOutlineWidth"];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                using (new UndoBlock("字幕の色とアウトラインを指定の色に統一"))
                {
                    helper.SetTextColor(
                        trackDict[settingDialog.TargetVideoTrack],
                        settingDialog.JimakuColor,
                        settingDialog.OutlineColor,
                        settingDialog.OutlineWidth
                        );
                }

                helper.Settings["JimakuColor"] = settingDialog.JimakuColor;
                helper.Settings["JimakuOutlineColor"] = settingDialog.OutlineColor;
                helper.Settings["JimakuOutlineWidth"] = settingDialog.OutlineWidth;
                helper.Settings.Save();
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
