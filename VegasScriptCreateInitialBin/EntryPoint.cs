using ScriptPortal.Vegas;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
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

            settingDialog.VoiroVoiceBinName = helper.Config.DefBinName[DefaultBinName.voiroVoice];
            settingDialog.VoiroJimakuBinName = helper.Config.DefBinName[DefaultBinName.voiroJimaku];
            settingDialog.VoiroActorBinName = helper.Config.DefBinName[DefaultBinName.voiroActor];
            settingDialog.JimakuBackgroundBinName = helper.Config.DefBinName[DefaultBinName.jimakuBG];
            settingDialog.ActorBackgroundBinName = helper.Config.DefBinName[DefaultBinName.actorBG];
            settingDialog.TachieBinName = helper.Config.DefBinName[DefaultBinName.tachie];
            settingDialog.DLAudioBinName = helper.Config.DefBinName[DefaultBinName.dlAudio];
            settingDialog.CreatedAudioBinName = helper.Config.DefBinName[DefaultBinName.createdAudio];
            settingDialog.DLMovieBinName = helper.Config.DefBinName[DefaultBinName.dlMovie];
            settingDialog.CreatedMovieBinName = helper.Config.DefBinName[DefaultBinName.createdMovie];
            settingDialog.DLImageBinName = helper.Config.DefBinName[DefaultBinName.dlImage];
            settingDialog.CreatedImageBinName = helper.Config.DefBinName[DefaultBinName.createdImage];

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

                    helper.Config.Save();
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

        private void CreateMediaBin(VegasHelper helper, string name, string configName)
        {
            if(!helper.MediaBin.IsExist(name))
            {
                helper.MediaBin.Create(name);

                if (configName.Length > 0){
                    helper.Config[configName] = name;
                }
            }
        }
    }
}
