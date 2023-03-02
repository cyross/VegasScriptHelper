using ScriptPortal.Vegas;
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
        private void LoadFlagsSetting(
            VegasHelper helper,
            ref Flags flags)
        {
            flags.Behavior = (PrefixBehaviorType)helper.Settings["PrefixBehavior"];
            flags.IsRemoveActorAttr = helper.Settings["RemoveActorAttribute"];
            flags.IsCreateOneEventCheck = helper.Settings["CreateOneEventCheck"];
            flags.IsCollapseTrackGroup = helper.Settings["IsCollapseTrackGroup"];
            flags.IsDivideTracks = helper.Settings["DivideTracks"];
        }

        private void SaveSetting(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            ref Flags flags,
            ref BasicTrackStructs trackStructs)
        {
            SetAudioSetting(helper, audioInfo);

            helper.Settings["JimakuFilePath"] = jimakuParams.JimakuFilePath;

            SetVideoTrackSetting(helper, "Jimaku", jimakuParams.Jimaku);
            SetVideoTrackSetting(helper, "Actor", jimakuParams.Actor);

            SetColorSetting(helper, "Jimaku", jimakuParams.JimakuColor);
            SetColorSetting(helper, "Actor", jimakuParams.ActorColor);

            SetBackgroundSetting(helper, "Jimaku", jimakuBG);
            SetBackgroundSetting(helper, "Actor", actorBG);

            SetMediaBinSetting(helper, "Audio", audioInfo.MediaBin);
            SetMediaBinSetting(helper, "Jimaku", jimakuParams.Jimaku.MediaBin);
            SetMediaBinSetting(helper, "Actor", jimakuParams.Actor.MediaBin);
            SetMediaBinSetting(helper, "JimakuBG", jimakuBG.MediaBin);
            SetMediaBinSetting(helper, "ActorBG", actorBG.MediaBin);

            SetFlagsToSetting(helper, flags);

            SetBasicTracksInfoToSetting(helper, trackStructs);

            helper.Settings.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Settings["AudioFileFolder"] = info.Folder;
            helper.Settings["AudioTrackName"] = info.Track.Name;
            helper.Settings["AudioInsertInterval"] = info.Interval;
            helper.Settings["IsAudioFolderRecursive"] = info.IsRecursive;
            helper.Settings["IsInsertFromStartPosition"] = info.IsInsertFromStartPosition;
            helper.Settings["StandardSilenceTime"] = info.StandardSilenceTime;
        }

        private void SetVideoTrackSetting(VegasHelper helper, string target, in TextTrackInfo info)
        {
            helper.Settings[target + "TrackName"] = info.Track.Name;
            helper.Settings[target + "PresetName"] = info.PresetName;
            helper.Settings[target + "Margin"] = info.Margin;
        }

        private void SetColorSetting(VegasHelper helper, string target, in ColorInfo info)
        {
            helper.Settings["Use" + target + "ColorSetting"] = info.IsUse;
            helper.Settings[target + "OutlineWidth"] = info.OutlineWidth;

            if (!info.IsUse) { return; }

            helper.Settings[target + "Color"] = info.TextColor;
            helper.Settings[target + "OutlineColor"] = info.OutlineColor;
        }

        private void SetMediaBinSetting(VegasHelper helper, string target, in MediaBinInfo info)
        {
            helper.Settings["Use" + target + "MediaBin"] = info.IsUse;

            if (!info.IsUse) { return; }

            helper.Settings[target + "MediaBinName"] = info.Name;
        }

        private void SetBackgroundSetting(VegasHelper helper, string target, in BackgroundInfo info)
        {
            helper.Settings["Create" + target + "BG"] = info.IsCreate;

            if (!info.IsCreate) { return; }

            helper.Settings[target + "BGMediaName"] = info.Media.Name;
            helper.Settings[target + "BGMargin"] = info.Margin;
        }

        private void SetBasicTrackInfoToSetting<T>(VegasHelper helper, string target, in BasicTrackStruct<T> trackStruct)
        {
            helper.Settings["Use" + target] = trackStruct.IsCreate;
            helper.Settings[target + "TrackName"] = trackStruct.Info.Name;
        }

        private void SetFlagsToSetting(VegasHelper helper, in Flags flags)
        {
            helper.Settings["PrefixBehavior"] = (int)flags.Behavior;
            helper.Settings["RemoveActorAttribute"] = flags.IsRemoveActorAttr;
            helper.Settings["CreateOneEventCheck"] = flags.IsCreateOneEventCheck;
            helper.Settings["IsCollapseTrackGroup"] = flags.IsCollapseTrackGroup;
            helper.Settings["DivideTracks"] = flags.IsDivideTracks;
        }

        private void SetBasicTracksInfoToSetting(VegasHelper helper, in BasicTrackStructs trackStructs)
        {
            SetBasicTrackInfoToSetting(helper, "Tachie", trackStructs.Tachie);
            SetBasicTrackInfoToSetting(helper, "BG", trackStructs.BG);
            SetBasicTrackInfoToSetting(helper, "FG", trackStructs.FG);
            SetBasicTrackInfoToSetting(helper, "BGM", trackStructs.BGM);
        }
    }
}
