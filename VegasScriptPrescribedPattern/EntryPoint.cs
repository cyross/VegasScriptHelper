﻿using System;
using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptDebug;
using System.Diagnostics;

namespace VegasScriptPrescribedPattern
{
    public class EntryPoint: IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            try
            {
                // ヘルパクラスのオブジェクト生成は必須
                VegasHelper helper = VegasHelper.Instance(vegas);

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
