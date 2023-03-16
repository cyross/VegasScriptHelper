using System;
using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;
using System.Diagnostics;

namespace VegasScriptPrescribedPattern
{
    public class EntryPoint: IEntryPoint
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
                // 設定ダイアログが不要なときは削除
                if (settingDialog == null) { settingDialog = new SettingDialog(); }
                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                // スクリプト本体を実装
                // IMainProcインタフェースを実装するクラスを作成する
            }
#else // not update script
            // 設定ダイアログが不要なときは削除
            if (settingDialog == null) { settingDialog = new SettingDialog(); }

            // スクリプト本体を実装
#endif
            helper.Settings.Save();
        }
    }
}
