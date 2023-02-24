using ScriptPortal.Vegas;
using System;
using System.CodeDom;
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

            settingDialog.VoiroVoiceBinName = helper.Settings.DefaultBinName["voiroVoice"];
            settingDialog.VoiroJimakuBinName = helper.Settings.DefaultBinName["voiroJimaku"];
            settingDialog.VoiroActorBinName = helper.Settings.DefaultBinName["voiroActor"];
            settingDialog.JimakuBackgroundBinName = helper.Settings.DefaultBinName["jimakuBackground"];
            settingDialog.ActorBackgroundBinName = helper.Settings.DefaultBinName["actorBackground"];
            settingDialog.TachieBinName = helper.Settings.DefaultBinName["tachie"];
            settingDialog.DLAudioBinName = helper.Settings.DefaultBinName["dlAudio"];
            settingDialog.CreatedAudioBinName = helper.Settings.DefaultBinName["createdAudio"];
            settingDialog.DLMovieBinName = helper.Settings.DefaultBinName["dlMovie"];
            settingDialog.CreatedMovieBinName = helper.Settings.DefaultBinName["createdMovie"];
            settingDialog.DLImageBinName = helper.Settings.DefaultBinName["dlImage"];
            settingDialog.CreatedImageBinName = helper.Settings.DefaultBinName["createdImage"];

            if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

            try
            {
                using (new UndoBlock("ボイロ動画用ビンを作成"))
                {
                    CreateMediaBin(helper, settingDialog.VoiroVoiceBinName);
                    CreateMediaBin(helper, settingDialog.VoiroJimakuBinName);
                    CreateMediaBin(helper, settingDialog.VoiroActorBinName);
                    CreateMediaBin(helper, settingDialog.JimakuBackgroundBinName);
                    CreateMediaBin(helper, settingDialog.ActorBackgroundBinName);
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
