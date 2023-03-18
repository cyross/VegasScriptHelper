using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Settings;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        public void SetFromAudioTrackInfo(VegasHelper helper, KeyListInfo klAudio, KeyListInfo klMediaBin)
        {
            SetComboBox(audioTrackNameBox, klAudio);
            AudioFileFolder = helper.Config[Names.WdAudio.File.Folder];
            AudioInterval = helper.Config[Names.WdAudio.Insert.Interval];
            IsRecursive = helper.Config[Names.WdAudio.Is.Folder.Recursive];
            IsInsertFromStartPosition = helper.Config[Names.WdAudio.Is.Insert.From.Start.Position];
            StandardSilenceTime = helper.Config[Names.WdAudio.Standard.Silence.Time];

            SetComboBox(audioMediaBinBox, klMediaBin);
            UseAudioMediaBin = helper.Config[Names.WdAudio.Use.MediaBin];
        }

        public void SetFromJimakuTrackInfo(
            VegasHelper helper,
            KeyListInfo klJimaku,
            KeyListInfo klPlugin,
            KeyListInfo klMediaBin)
        {
            SetComboBox(jimakuTrackBox, klJimaku);
            SetComboBox(jimakuPresetBox, klPlugin);
            SetComboBox(jimakuMediaBinBox, klMediaBin);
            JimakuMargin = helper.Config[Names.WdJimaku.Margin];
            UseJimakuMediaBin = helper.Config[Names.WdJimaku.Use.MediaBin];
        }

        public void SetFromActorTrackInfo(
            VegasHelper helper,
            KeyListInfo klActor,
            KeyListInfo klPlugin,
            KeyListInfo klMediaBin)
        {
            SetComboBox(actorTrackBox, klActor);
            SetComboBox(actorPresetBox, klPlugin);
            SetComboBox(actorMediaBinBox, klMediaBin);
            ActorMargin = helper.Config[Names.WdActor.Margin];
            UseActorMediaBin = helper.Config[Names.WdActor.Use.MediaBin];
        }

        public void SetFromJimakuColorInfo(VegasHelper helper)
        {
            SetFromColorInfo(helper, "Jimaku",
                jimakuColorBox, jimakuOutlineColorBox, jimakuOutlineWidthBox, useJimakuDefaultSettings);
        }
        public void SetFromActorColorInfo(VegasHelper helper)
        {
            SetFromColorInfo(helper, "Actor",
                actorColorBox, actorOutlineColorBox, actorOutlineWidthBox, useActorDefaultSettings);
        }

        private void SetFromColorInfo(
            VegasHelper helper,
            string target,
            PictureBox textColorBox,
            PictureBox outlineColorBox,
            TextBox outlineWidthBox,
            CheckBox useCheck)
        {
            textColorBox.BackColor = helper.Config[target + "Color"];
            outlineColorBox.BackColor = helper.Config[target + "OutlineColor"];
            outlineWidthBox.Text = helper.Config[target + "OutlineWidth"].ToString();
            useCheck.Checked = helper.Config["Use" + target + "ColorSetting"];
        }

        public void SetFromJimakuBackgroundInfo(
            VegasHelper helper,
            in KeyListInfo klJimakuBG,
            in KeyListInfo klMedia,
            in KeyListInfo klMediaBin)
        {
            SetComboBox(jimakuBackgroundTrackBox, klJimakuBG);
            List<string> medias = klMedia.Keys;
            medias.Insert(0, VHMedia.NoSelectMedia);

            string mediakey = klMedia.FirstKey;
            if (!medias.Contains(mediakey)){ mediakey = VHMedia.NoSelectMedia; }

            SetComboBox(jimakuBackgroundMediaBox, medias, mediakey);
            SetComboBox(jimakuBackgroundMediaBinBox, klMediaBin);
            JimakuBackgroundMargin = helper.Config[Names.WdJimaku.BG.Margin];
            CreateJimakuBackground = helper.Config[Names.WdJimaku.Create.BG];
        }

        public void SetFromActorBackgroundInfo(
            VegasHelper helper,
            in KeyListInfo klActorBG,
            in KeyListInfo klMedia,
            in KeyListInfo klMediaBin)
        {
            SetComboBox(actorBackgroundTrackBox, klActorBG);
            List<string> medias = klMedia.Keys;
            medias.Insert(0, VHMedia.NoSelectMedia);

            string mediakey = klMedia.FirstKey;
            if (!medias.Contains(mediakey)) { mediakey = VHMedia.NoSelectMedia; }

            SetComboBox(actorBackgroundMediaBox, medias, mediakey);
            SetComboBox(actorBackgroundMediaBinBox, klMediaBin);
            ActorBackgroundMargin = helper.Config[Names.WdActor.BG.Margin];
            CreateActorBackground = helper.Config[Names.WdActor.Create.BG];
        }

        public void SetFromFlags(in Flags flags)
        {
            PrefixBehavior = flags.Behavior;
            IsRemoveActorAttr = flags.IsRemoveActorAttr;
            IsCreateOneEventCheck = flags.IsCreateOneEventCheck;
            IsCollapseTrackGroupCheck = flags.IsCollapseTrackGroup;
            DivideTracks = flags.IsDivideTracks;
        }

        public void SetFromTachieInfo(in BasicTrackStruct<VideoTrack> tachieTrack)
        {
            IsTachieCheck = tachieTrack.IsCreate;
            TachieTrackName = tachieTrack.Info.Name;
        }

        public void SetFromBGInfo(in BasicTrackStruct<VideoTrack> bgTrack)
        {
            IsBGCheck = bgTrack.IsCreate;
            BGTrackName = bgTrack.Info.Name;
        }

        public void SetFromFGInfo(in BasicTrackStruct<VideoTrack> fgTrack)
        {
            IsFGCheck = fgTrack.IsCreate;
            FGTrackName = fgTrack.Info.Name;
        }

        public void SetFromBGMInfo(in BasicTrackStruct<AudioTrack> bgmTrack)
        {
            IsBGMCheck = bgmTrack.IsCreate;
            BGMTrackName = bgmTrack.Info.Name;
        }

        public void SetFromBasicTrackStructs(in BasicTrackStructs structs)
        {
            SetFromTachieInfo(structs.Tachie);
            SetFromBGInfo(structs.BG);
            SetFromFGInfo(structs.FG);
            SetFromBGMInfo(structs.BGM);
        }

        public void SetFromHypheInfo(in HypheInfo info)
        {
            UseHypheCheck = info.IsUse;
            HypheLength = info.Length;
        }
    }
}
