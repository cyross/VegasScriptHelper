using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateInitialBin
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            if(settingDialog == null) { settingDialog = new SettingDialog(); }

            settingDialog.VoiroVoiceBinName = VegasScriptSettings.DefaultBinName["voiroVoice"];
            settingDialog.VoiroJimakuBinName = VegasScriptSettings.DefaultBinName["voiroJimaku"];
            settingDialog.JimakuBackgroundBinName = VegasScriptSettings.DefaultBinName["jimakuBackground"];
            settingDialog.TachieBinName = VegasScriptSettings.DefaultBinName["tachie"];
            settingDialog.DLAudioBinName = VegasScriptSettings.DefaultBinName["dlAudio"];
            settingDialog.CreatedAudioBinName = VegasScriptSettings.DefaultBinName["createdAudio"];
            settingDialog.DLMovieBinName = VegasScriptSettings.DefaultBinName["dlMovie"];
            settingDialog.CreatedMovieBinName = VegasScriptSettings.DefaultBinName["createdMovie"];
            settingDialog.DLImageBinName = VegasScriptSettings.DefaultBinName["dlImage"];
            settingDialog.CreatedImageBinName = VegasScriptSettings.DefaultBinName["createdImage"];

            if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

            try
            {
                using (new UndoBlock("ボイロ動画用ビンを作成"))
                {
                    CreateMediaBin(helper, settingDialog.VoiroVoiceBinName);
                    CreateMediaBin(helper, settingDialog.VoiroJimakuBinName);
                    CreateMediaBin(helper, settingDialog.JimakuBackgroundBinName);
                    CreateMediaBin(helper, settingDialog.TachieBinName);
                    CreateMediaBin(helper, settingDialog.DLAudioBinName);
                    CreateMediaBin(helper, settingDialog.CreatedAudioBinName);
                    CreateMediaBin(helper, settingDialog.DLMovieBinName);
                    CreateMediaBin(helper, settingDialog.CreatedMovieBinName);
                    CreateMediaBin(helper, settingDialog.DLImageBinName);
                    CreateMediaBin(helper, settingDialog.CreatedImageBinName);
                }
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

        private void CreateMediaBin(VegasHelper helper, string name)
        {
            if(!helper.IsExistMediaBin(name))
            {
                helper.CreateMediaBin(name);
            }
        }
    }
}
