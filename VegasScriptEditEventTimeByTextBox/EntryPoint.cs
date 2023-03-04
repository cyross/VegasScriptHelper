using ScriptPortal.Vegas;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptEditEventTimeByTextBox
{
    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            // ヘルパクラスのオブジェクト生成は必須
            VegasHelper helper = VegasHelper.Instance(vegas);

            using (var block = new UndoBlock("EditEventTimeEx"))
            {
                try
                {
                    TrackEvent selectedEvent = helper.GetSelectedEvent(false);

                    if (selectedEvent == null) {
                        MessageBox.Show("イベントが選択されていません");
                        return;
                    }

                    RulerFormat rulerFormat = (RulerFormat)helper.Settings[SN.WdTime.Ruler.Format];

                    // 設定ダイアログが不要なときは削除
                    if (settingDialog == null) { settingDialog = new SettingDialog(); }

                    settingDialog.RulerFormat = rulerFormat;
                    settingDialog.SetToDialog(selectedEvent);

                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // スクリプト本体を実装
                    settingDialog.SetFromDialog(selectedEvent);
                    rulerFormat = settingDialog.RulerFormat;

                    helper.Settings[SN.WdTime.Ruler.Format] = (int)rulerFormat;
                }
                catch (Exception ex)
                {
                    string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                    Debug.WriteLine("---[Exception In Helper]---");
                    Debug.WriteLine(errMessage);
                    Debug.WriteLine("---------------------------");
                    MessageBox.Show(errMessage);
                    throw ex;
                }
            }

            helper.Settings.Save();
        }
    }
}
