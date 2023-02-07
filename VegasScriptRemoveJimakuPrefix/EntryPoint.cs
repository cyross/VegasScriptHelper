using ScriptPortal.Vegas;
using VegasScriptHelper;
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

                Dictionary<string, VideoTrack> keyValuePairs = helper.GetVideoKeyValuePairs();

                if (!keyValuePairs.Any())
                {
                    MessageBox.Show("ビデオトラックがありません");
                }

                List<string> videoTrackKeys = keyValuePairs.Keys.ToList();

                VideoTrack selected = helper.SelectedVideoTrack(false);

                string initialKey = selected != null ? helper.GetTrackKey(selected) : videoTrackKeys[0];

                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.RemoveJimakuDataSource = videoTrackKeys;
                settingDialog.RemoveJimakuTrackName = initialKey;

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                using (new UndoBlock("字幕の接頭辞を削除"))
                {
                    helper.DeleteJimakuPrefix(keyValuePairs[settingDialog.RemoveJimakuTrackName]);
                }
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
