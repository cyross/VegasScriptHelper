using ScriptPortal.Vegas;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.VegasHelperYamlSpecs;

namespace VegasScriptCreateInitialBin
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            if(settingDialog == null) { settingDialog = new SettingDialog(); }

            settingDialog.VoiroVoiceBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.voiroVoice];
            settingDialog.VoiroJimakuBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.voiroJimaku];
            settingDialog.VoiroActorBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.voiroActor];
            settingDialog.JimakuBackgroundBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.jimakuBG];
            settingDialog.ActorBackgroundBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.actorBG];
            settingDialog.TachieBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.tachie];
            settingDialog.DLAudioBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.dlAudio];
            settingDialog.CreatedAudioBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.createdAudio];
            settingDialog.DLMovieBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.dlMovie];
            settingDialog.CreatedMovieBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.createdMovie];
            settingDialog.DLImageBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.dlImage];
            settingDialog.CreatedImageBinName = helper.Settings.DefaultBinName[DefaultBinNameSetting.createdImage];

            if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

            try
            {
                using (new UndoBlock("ボイロ動画用ビンを作成"))
                {
                    CreateMediaBin(helper, settingDialog.VoiroVoiceBinName, "AudioMediaBinName");
                    CreateMediaBin(helper, settingDialog.VoiroJimakuBinName, "JimakuMediaBinName");
                    CreateMediaBin(helper, settingDialog.VoiroActorBinName, "ActorMediaBinName");
                    CreateMediaBin(helper, settingDialog.JimakuBackgroundBinName, "JimakuBGMediaBinName");
                    CreateMediaBin(helper, settingDialog.ActorBackgroundBinName, "ActorBGMediaBinName");
                    CreateMediaBin(helper, settingDialog.TachieBinName, "");
                    CreateMediaBin(helper, settingDialog.DLAudioBinName, "");
                    CreateMediaBin(helper, settingDialog.CreatedAudioBinName, "");
                    CreateMediaBin(helper, settingDialog.DLMovieBinName, "");
                    CreateMediaBin(helper, settingDialog.CreatedMovieBinName, "");
                    CreateMediaBin(helper, settingDialog.DLImageBinName, "");
                    CreateMediaBin(helper, settingDialog.CreatedImageBinName, "");

                    helper.Settings.Save();
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

        private void CreateMediaBin(VegasHelper helper, string name, string settingName)
        {
            if(!helper.IsExistMediaBin(name))
            {
                helper.CreateMediaBin(name);

                if (settingName.Length > 0){
                    helper.Settings[settingName] = name;
                }
            }
        }
    }
}
