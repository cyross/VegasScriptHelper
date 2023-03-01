using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void SetToDialog(VegasHelper helper, ref KeyListManager manager, ref BasicTrackStructs structs, ref Flags flags)
        {
            settingDialog.SetAudioTrackInfo(helper, manager.Audio, manager.AudioMBin);

            settingDialog.JimakuFilePath = helper.Settings["JimakuFilePath"];
            settingDialog.PrefixBehavior = flags.Behavior;
            settingDialog.IsRemoveActorAttr = flags.IsRemoveActorAttr;

            settingDialog.SetJimakuTrackInfo(helper, manager.Jimaku, manager.JimakuPlugin, manager.JimakuMBin);

            settingDialog.SetActorTrackInfo(helper, manager.Actor, manager.ActorPlugin, manager.ActorMBin);

            settingDialog.SetJimakuColorInfo(helper);

            settingDialog.SetActorColorInfo(helper);

            settingDialog.SetJimakuBackgroundInfo(helper, manager.JimakuBG, manager.JimakuBGMedia, manager.JimakuBGMBin);

            settingDialog.SetActorBackgroundInfo(helper, manager.ActorBG, manager.ActorBGMedia, manager.ActorMBin);

            settingDialog.SetTachieInfo(structs.Tachie);

            settingDialog.SetBGInfo(structs.BG);

            settingDialog.IsCreateOneEventCheck = flags.IsCreateOneEventCheck;
        }
    }
}
