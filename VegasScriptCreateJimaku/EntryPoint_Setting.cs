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
            flags.Behavior = (PrefixBehaviorType)helper.Settings[SN.WdJimaku.Prefix.Behavior];
            flags.IsRemoveActorAttr = helper.Settings[SN.WdActor.Remove.Attribute];
            flags.IsCreateOneEventCheck = helper.Settings[SN.WdBG.Create.One.Event.Check];
            flags.IsCollapseTrackGroup = helper.Settings[SN.WdAll.Is.Track.Group.Collapse];
            flags.IsDivideTracks = helper.Settings[SN.WdActor.Divide.Tracks];
        }

        private void SaveSetting(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            ref Flags flags,
            ref BasicTrackStructs trackStructs,
            ref HypheInfo hypheInfo)
        {
            SetAudioSetting(helper, audioInfo);

            helper.Settings[SN.WdJimaku.File.Path] = jimakuParams.JimakuFilePath;

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

            SaveHypheInfo(helper, hypheInfo);

            helper.Settings.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Settings[SN.WdAudio.File.Folder] = info.Folder;
            helper.Settings[SN.WdAudio.Track.Name] = info.Track.Name;
            helper.Settings[SN.WdAudio.Insert.Interval] = info.Interval;
            helper.Settings[SN.WdAudio.Is.Folder.Recursive] = info.IsRecursive;
            helper.Settings[SN.WdAudio.Is.Insert.From.Standard.Position] = info.IsInsertFromStartPosition;
            helper.Settings[SN.WdAudio.Standard.Silence.Time] = info.StandardSilenceTime;
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

        private void SetBasicTrackInfoToSetting<T>(VegasHelper helper, string target, in BasicTrackStruct<T> trackStruct) where T: Track
        {
            helper.Settings["Use" + target] = trackStruct.IsCreate;
            helper.Settings[target + "TrackName"] = trackStruct.Info.Name;
        }

        private void SetFlagsToSetting(VegasHelper helper, in Flags flags)
        {
            helper.Settings[SN.WdJimaku.Prefix.Behavior] = (int)flags.Behavior;
            helper.Settings[SN.WdActor.Remove.Attribute] = flags.IsRemoveActorAttr;
            helper.Settings[SN.WdBG.Create.One.Event.Check] = flags.IsCreateOneEventCheck;
            helper.Settings[SN.WdAll.Is.Track.Group.Collapse] = flags.IsCollapseTrackGroup;
            helper.Settings[SN.WdActor.Divide.Tracks] = flags.IsDivideTracks;
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
