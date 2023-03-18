using ScriptPortal.Vegas;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Jimaku;
using VegasScriptHelper.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System;

namespace VegasScriptRemoveJimakuPrefix
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            try
            {
                VegasHelper helper = VegasHelper.Instance(vegas);

                Dictionary<string, VideoTrack> keyValuePairs = helper.VideoTrack.KV;

                if (!keyValuePairs.Any())
                {
                    MessageBox.Show("ビデオトラックがありません");
                }

                List<string> videoTrackKeys = keyValuePairs.Keys.ToList();

                VideoTrack selected = helper.Project.SelectedVideoTrack(false);

                string initialKey = selected != null ? helper.Track.GetKey(selected) : videoTrackKeys[0];

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.RemoveJimakuDataSource = videoTrackKeys;
                settingDialog.RemoveJimakuTrackName = initialKey;

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                using (new UndoBlock("字幕の接頭辞を削除"))
                {
                    DelPrefix delPrefix = new DelPrefix(helper);
                    delPrefix.Exec(keyValuePairs[settingDialog.RemoveJimakuTrackName]);
                }
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
