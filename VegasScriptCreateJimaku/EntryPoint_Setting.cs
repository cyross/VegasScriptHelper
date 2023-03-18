using ScriptPortal.Vegas;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;
using VegasScriptHelper.Settings;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void LoadFlagsSetting(
            VegasHelper helper,
            ref Flags flags)
        {
            flags.Behavior = (PrefixBehaviorType)helper.Config[Names.WdJimaku.Prefix.Behavior];
            flags.IsRemoveActorAttr = helper.Config[Names.WdActor.Remove.Attribute];
            flags.IsCreateOneEventCheck = helper.Config[Names.WdBG.Create.One.Event.Check];
            flags.IsCollapseTrackGroup = helper.Config[Names.WdAll.Is.Track.Group.Collapse];
            flags.IsDivideTracks = helper.Config[Names.WdActor.Divide.Tracks];
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

            helper.Config[Names.WdJimaku.File.Path] = jimakuParams.JimakuFilePath;

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

            helper.Config.Save();
        }

        private void SetAudioSetting(VegasHelper helper, in InsertAudioInfo info)
        {
            helper.Config[Names.WdAudio.File.Folder] = info.Folder;
            helper.Config[Names.WdAudio.Track.Name] = info.Track.Name;
            helper.Config[Names.WdAudio.Insert.Interval] = info.Interval;
            helper.Config[Names.WdAudio.Is.Folder.Recursive] = info.IsRecursive;
            helper.Config[Names.WdAudio.Is.Insert.From.Standard.Position] = info.IsInsertFromStartPosition;
            helper.Config[Names.WdAudio.Standard.Silence.Time] = info.StandardSilenceTime;
        }

        private void SetVideoTrackSetting(VegasHelper helper, string target, in TextTrackInfo info)
        {
            helper.Config[target + "TrackName"] = info.Track.Name;
            helper.Config[target + "PresetName"] = info.PresetName;
            helper.Config[target + "Margin"] = info.Margin;
        }

        private void SetColorSetting(VegasHelper helper, string target, in ColorInfo info)
        {
            helper.Config["Use" + target + "ColorSetting"] = info.IsUse;
            helper.Config[target + "OutlineWidth"] = info.OutlineWidth;

            if (!info.IsUse) { return; }

            helper.Config[target + "Color"] = info.TextColor;
            helper.Config[target + "OutlineColor"] = info.OutlineColor;
        }

        private void SetMediaBinSetting(VegasHelper helper, string target, in MediaBinInfo info)
        {
            helper.Config["Use" + target + "MediaBin"] = info.IsUse;

            if (!info.IsUse) { return; }

            helper.Config[target + "MediaBinName"] = info.Name;
        }

        private void SetBackgroundSetting(VegasHelper helper, string target, in BackgroundInfo info)
        {
            helper.Config["Create" + target + "BG"] = info.IsCreate;

            if (!info.IsCreate) { return; }

            helper.Config[target + "BGMediaName"] = info.Media.Name;
            helper.Config[target + "BGMargin"] = info.Margin;
        }

        private void SetBasicTrackInfoToSetting<T>(VegasHelper helper, string target, in BasicTrackStruct<T> trackStruct) where T: Track
        {
            helper.Config["Use" + target] = trackStruct.IsCreate;
            helper.Config[target + "TrackName"] = trackStruct.Info.Name;
        }

        private void SetFlagsToSetting(VegasHelper helper, in Flags flags)
        {
            helper.Config[Names.WdJimaku.Prefix.Behavior] = (int)flags.Behavior;
            helper.Config[Names.WdActor.Remove.Attribute] = flags.IsRemoveActorAttr;
            helper.Config[Names.WdBG.Create.One.Event.Check] = flags.IsCreateOneEventCheck;
            helper.Config[Names.WdAll.Is.Track.Group.Collapse] = flags.IsCollapseTrackGroup;
            helper.Config[Names.WdActor.Divide.Tracks] = flags.IsDivideTracks;
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
