using ScriptPortal.Vegas;
using System.Drawing;
using System.Collections.Generic;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;
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

                if (!helper.Project.AllVideoTracks.Any())
                {
                    MessageBox.Show("ビデオトラックがありません");
                    return;
                }

                Dictionary<string, VideoTrack> trackDict = helper.VideoTrack.KV;
                List<string> trackNames = trackDict.Keys.ToList();

                VideoTrack selected = helper.Project.SelectedVideoTrack(false);

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.TargetVideoTrackDataSource = trackNames;
                settingDialog.TargetVideoTrack = selected != null ? helper.Track.GetKey(selected) : trackNames[0];
                settingDialog.JimakuColor = helper.Config[Names.WdJimaku.Color];
                settingDialog.OutlineColor = helper.Config[Names.WdJimaku.Outline.Color];
                settingDialog.OutlineWidth = helper.Config[Names.WdJimaku.Outline.Width];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                using (new UndoBlock("字幕の色とアウトラインを指定の色に統一"))
                {
                    helper.TextParam.SetTextColor(
                        trackDict[settingDialog.TargetVideoTrack],
                        settingDialog.JimakuColor,
                        settingDialog.OutlineColor,
                        settingDialog.OutlineWidth
                        );
                }

                helper.Config[Names.WdJimaku.Color] = settingDialog.JimakuColor;
                helper.Config[Names.WdJimaku.Outline.Color] = settingDialog.OutlineColor;
                helper.Config[Names.WdJimaku.Outline.Width] = settingDialog.OutlineWidth;
                helper.Config.Save();
            }
            catch (VHNoneEventsException)
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
