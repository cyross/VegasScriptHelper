using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        public void SetAudioTrackInfo(VegasHelper helper, KeyListInfo klAudio, KeyListInfo klMediaBin)
        {
            SetComboBox(audioTrackNameBox, klAudio);
            AudioFileFolder = helper.Settings["AudioFileFolder"];
            AudioInterval = helper.Settings["AudioInsertInterval"];
            IsRecursive = helper.Settings["IsAudioFolderRecursive"];
            IsInsertFromStartPosition = helper.Settings["IsInsertFromStartPosition"];
            StandardSilenceTime = helper.Settings["StandardSilenceTime"];

            SetComboBox(audioMediaBinBox, klMediaBin);
            UseAudioMediaBin = helper.Settings["UseAudioMediaBin"];
        }

        public void SetJimakuTrackInfo(
            VegasHelper helper,
            KeyListInfo klJimaku,
            KeyListInfo klPlugin,
            KeyListInfo klMediaBin)
        {
            SetComboBox(jimakuTrackBox, klJimaku);
            SetComboBox(jimakuPresetBox, klPlugin);
            SetComboBox(jimakuMediaBinBox, klMediaBin);
            JimakuMargin = helper.Settings["JimakuMargin"];
            UseJimakuMediaBin = helper.Settings["UseJimakuMediaBin"];
        }

        public void SetActorTrackInfo(
            VegasHelper helper,
            KeyListInfo klActor,
            KeyListInfo klPlugin,
            KeyListInfo klMediaBin)
        {
            SetComboBox(actorTrackBox, klActor);
            SetComboBox(actorPresetBox, klPlugin);
            SetComboBox(actorMediaBinBox, klMediaBin);
            ActorMargin = helper.Settings["ActorMargin"];
            UseActorMediaBin = helper.Settings["UseActorMediaBin"];
        }

        public void SetJimakuColorInfo(VegasHelper helper)
        {
            SetColorInfo(helper, "Jimaku",
                jimakuColorBox, jimakuOutlineColorBox, jimakuOutlineWidthBox, useJimakuDefaultSettings);
        }
        public void SetActorColorInfo(VegasHelper helper)
        {
            SetColorInfo(helper, "Actor",
                actorColorBox, actorOutlineColorBox, actorOutlineWidthBox, useActorDefaultSettings);
        }

        private void SetColorInfo(
            VegasHelper helper,
            string target,
            PictureBox textColorBox,
            PictureBox outlineColorBox,
            TextBox outlineWidthBox,
            CheckBox useCheck)
        {
            textColorBox.BackColor = helper.Settings[target + "Color"];
            outlineColorBox.BackColor = helper.Settings[target + "OutlineColor"];
            outlineWidthBox.Text = helper.Settings[target + "OutlineWidth"].ToString();
            useCheck.Checked = helper.Settings["Use" + target + "ColorSetting"];
        }

        public void SetJimakuBackgroundInfo(
            VegasHelper helper,
            in KeyListInfo klJimakuBG,
            in KeyListInfo klMedia,
            in KeyListInfo klMediaBin)
        {
            SetComboBox(jimakuBackgroundTrackBox, klJimakuBG);
            SetComboBox(jimakuBackgroundMediaBox, klMedia);
            SetComboBox(jimakuBackgroundMediaBinBox, klMediaBin);
            JimakuBackgroundMargin = helper.Settings["JimakuBGMargin"];
            CreateJimakuBackground = helper.Settings["CreateJimakuBG"];
        }

        public void SetActorBackgroundInfo(
            VegasHelper helper,
            in KeyListInfo klActorBG,
            in KeyListInfo klMedia,
            in KeyListInfo klMediaBin)
        {
            SetComboBox(actorBackgroundTrackBox, klActorBG);
            SetComboBox(actorBackgroundMediaBox, klMedia);
            SetComboBox(actorBackgroundMediaBinBox, klMediaBin);
            ActorBackgroundMargin = helper.Settings["ActorBGMargin"];
            CreateActorBackground = helper.Settings["CreateActorBG"];
        }

        public void SetTachieInfo(in BasicTrackStruct tachieTrack)
        {
            IsTachieCheck = tachieTrack.IsCreate;
            TachieTrackName = tachieTrack.Info.Name;
        }

        public void SetBGInfo(in BasicTrackStruct bgTrack)
        {
            IsBGCheck = bgTrack.IsCreate;
            BGTrackName = bgTrack.Info.Name;
        }
    }
}
