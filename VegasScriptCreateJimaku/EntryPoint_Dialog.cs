using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;
using VegasScriptHelper.Settings;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void SetFromInfoToDialog(VegasHelper helper, ref KeyListManager manager, ref BasicTrackStructs structs, ref Flags flags, ref HypheInfo hypheInfo)
        {
            settingDialog.SetFromAudioTrackInfo(helper, manager.Audio, manager.AudioMBin);
            settingDialog.JimakuFilePath = helper.Config[Names.WdJimaku.File.Path];
            settingDialog.SetFromFlags(flags);
            settingDialog.SetFromJimakuTrackInfo(helper, manager.Jimaku, manager.JimakuPlugin, manager.JimakuMBin);
            settingDialog.SetFromActorTrackInfo(helper, manager.Actor, manager.ActorPlugin, manager.ActorMBin);
            settingDialog.SetFromJimakuColorInfo(helper);
            settingDialog.SetFromActorColorInfo(helper);
            settingDialog.SetFromJimakuBackgroundInfo(helper, manager.JimakuBG, manager.JimakuBGMedia, manager.JimakuBGMBin);
            settingDialog.SetFromActorBackgroundInfo(helper, manager.ActorBG, manager.ActorBGMedia, manager.ActorMBin);
            settingDialog.SetFromBasicTrackStructs(structs);
            settingDialog.SetFromHypheInfo(hypheInfo);
        }

        private void LoadFromDialogToInfo(ref JimakuParams jimakuParams, ref BasicTrackStructs structs, ref Flags flags, ref HypheInfo hypheInfo)
        {
            settingDialog.SetToFlags(ref flags);

            jimakuParams.IsCreateActorTrack = (flags.Behavior == PrefixBehaviorType.NewEvent);
            jimakuParams.IsDeletePrefix = (flags.Behavior != PrefixBehaviorType.Remain);

            settingDialog.SetToBasicTrackStructs(ref structs);
            settingDialog.SetToHypheInfo(ref hypheInfo);
        }
    }
}
