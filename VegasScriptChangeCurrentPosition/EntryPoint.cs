using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptChangeCurrentPosition
{
    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            // ヘルパクラスのオブジェクト生成は必須
            VegasHelper helper = VegasHelper.Instance(vegas);

#if true // for update script
            using (var block = new UndoBlock("$projectname"))
            {
                try
                {
                    // 設定ダイアログが不要なときは削除
                    if (settingDialog == null) { settingDialog = new SettingDialog(); }
                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    // スクリプト本体を実装
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
#else // not update script
            try
            {
                // 設定ダイアログが不要なときは削除
                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                // スクリプト本体を実装
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
#endif
            helper.Settings.Save();
        }
    }
}
