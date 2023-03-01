using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        public bool IsRemoveActorAttr
        {
            get { return removeActorAttributeCheck.Checked; }
            set { removeActorAttributeCheck.Checked = value; }
        }

        public List<string> AudioTrackBoxDataSource
        {
            set { SetComboBox(audioTrackNameBox, value); }
        }

        public string AudioTrackName
        {
            get { return audioTrackNameBox.Text; }
            set { audioTrackNameBox.Text = value; }
        }

        public string AudioFileFolder
        {
            get { return audioFileFolderBox.Text; }
            set { audioFileFolderBox.Text = value; }
        }

        public float AudioInterval
        {
            get { return GetBoxValue<float>(intervalBox); }
            set { SetBoxValue(intervalBox, value); }
        }

        public bool IsInsertFromStartPosition
        {
            get { return fromStartPosition.Checked; }
            set
            {
                fromStartPosition.Checked = value;
                fromCurrentPosition.Checked = !value;
            }
        }

        public bool IsRecursive
        {
            get { return IsRecursiveCheck.Checked; }
            set { IsRecursiveCheck.Checked = value; }
        }

        public string JimakuFilePath
        {
            get { return jimakuFilePathBox.Text; }
            set { jimakuFilePathBox.Text = value; }
        }

        public bool UseAudioMediaBin
        {
            get { return useAudioMediaBin.Checked; }
            set { useAudioMediaBin.Checked = value; }
        }

        public List<string> AudioMediaBinBoxDataSource
        {
            set { SetComboBox(audioMediaBinBox, value); }
        }

        public string AudioMediaBinName
        {
            get { return audioMediaBinBox.Text; }
            set { audioMediaBinBox.Text = value; }
        }

        public List<string> JimakuTrackBoxDataSource
        {
            set
            {
                SetComboBox(jimakuTrackBox, value);
            }
        }

        public string JimakuTrackName
        {
            get { return jimakuTrackBox.Text; }
            set { jimakuTrackBox.Text = value; }
        }

        public bool UseJimakuDefaultSettings
        {
            get { return useJimakuDefaultSettings.Checked; }
            set { useJimakuDefaultSettings.Checked = value; }
        }

        public Color JimakuColor
        {
            get { return jimakuColorBox.BackColor; }
            set { jimakuColorBox.BackColor = value; }
        }

        public Color JimakuOutlineColor
        {
            get { return jimakuOutlineColorBox.BackColor; }
            set { jimakuOutlineColorBox.BackColor = value; }
        }

        public double JimakuOutlineWidth
        {
            get { return GetBoxValue<double>(jimakuOutlineWidthBox); }
            set { SetBoxValue(jimakuOutlineWidthBox, value); }
        }

        public List<string> ActorTrackBoxDataSource
        {
            set { SetComboBox(actorTrackBox, value); }
        }

        public string ActorTrackName
        {
            get { return actorTrackBox.Text; }
            set { actorTrackBox.Text = value; }
        }

        public bool UseActorDefaultSettings
        {
            get { return useActorDefaultSettings.Checked; }
            set { useActorDefaultSettings.Checked = value; }
        }

        public Color ActorColor
        {
            get { return actorColorBox.BackColor; }
            set { actorColorBox.BackColor = value; }
        }

        public Color ActorOutlineColor
        {
            get { return actorOutlineColorBox.BackColor; }
            set { actorOutlineColorBox.BackColor = value; }
        }

        public double ActorOutlineWidth
        {
            get { return GetBoxValue<double>(actorOutlineWidthBox); }
            set { SetBoxValue(actorOutlineWidthBox, value); }
        }

        public double StandardSilenceTime
        {
            get { return GetBoxValue<double>(silenceTimeBox); }
            set { SetBoxValue(silenceTimeBox, value); }
        }

        public bool UseJimakuMediaBin
        {
            get { return useJimakuMediaBin.Checked; }
            set { useJimakuMediaBin.Checked = value; }
        }

        public List<string> JimakuMediaBinBoxDataSource
        {
            set { SetComboBox(jimakuMediaBinBox, value); }
        }

        public string JimakuMediaBinName
        {
            get { return jimakuMediaBinBox.Text; }
            set { jimakuMediaBinBox.Text = value; }
        }

        public bool UseActorMediaBin
        {
            get { return useActorMediaBin.Checked; }
            set { useActorMediaBin.Checked = value; }
        }

        public List<string> ActorMediaBinBoxDataSource
        {
            set { SetComboBox(actorMediaBinBox, value); }
        }

        public string ActorMediaBinName
        {
            get { return actorMediaBinBox.Text; }
            set { actorMediaBinBox.Text = value; }
        }

        public bool CreateJimakuBackground
        {
            get { return createJimakuBackground.Checked; }
            set { createJimakuBackground.Checked = value; }
        }

        public List<string> JimakuBackgroundTrackBoxDataSource
        {
            set { SetComboBox(jimakuBackgroundTrackBox, value); }
        }

        public string JimakuBackgroundTrackName
        {
            get { return jimakuBackgroundTrackBox.Text; }
            set { jimakuBackgroundTrackBox.Text = value; }
        }

        public List<string> JimakuBackgroundMediaBoxDataSource
        {
            set { SetComboBox(jimakuBackgroundMediaBox, value); }
        }

        public string JimakuBackgroundMediaName
        {
            get { return jimakuBackgroundMediaBox.Text; }
            set { jimakuBackgroundMediaBox.Text = value; }
        }

        public double JimakuBackgroundMargin
        {
            get { return GetBoxValue<double>(jimakuBackgroundMarginBox); }
            set { SetBoxValue(jimakuBackgroundMarginBox, value); }
        }

        public bool UseJimakuBackgroundMediaBin
        {
            get { return useJimakuBackgroundMediaBin.Checked; }
            set { useJimakuBackgroundMediaBin.Checked = value; }
        }

        public List<string> JimakuBackgroundMediaBinBoxDataSource
        {
            set { SetComboBox(jimakuBackgroundMediaBinBox, value); }
        }

        public string JimakuBackgroundMediaBinName
        {
            get { return jimakuBackgroundMediaBinBox.Text; }
            set { jimakuBackgroundMediaBinBox.Text = value; }
        }

        public bool CreateActorBackground
        {
            get { return createActorBackground.Checked; }
            set { createActorBackground.Checked = value; }
        }

        public List<string> ActorBackgroundTrackBoxDataSource
        {
            set { SetComboBox(actorBackgroundTrackBox, value); }
        }

        public string ActorBackgroundTrackName
        {
            get { return actorBackgroundTrackBox.Text; }
            set { actorBackgroundTrackBox.Text = value; }
        }

        public List<string> ActorBackgroundMediaBoxDataSource
        {
            set { SetComboBox(actorBackgroundMediaBox, value); }
        }

        public string ActorBackgroundMediaName
        {
            get { return actorBackgroundMediaBox.Text; }
            set { actorBackgroundMediaBox.Text = value; }
        }

        public double ActorBackgroundMargin
        {
            get { return GetBoxValue<double>(actorBackgroundMarginBox); }
            set { SetBoxValue(actorBackgroundMarginBox, value); }
        }

        public bool UseActorBackgroundMediaBin
        {
            get { return useActorBackgroundMediaBin.Checked; }
            set { useActorBackgroundMediaBin.Checked = value; }
        }

        public List<string> ActorBackgroundMediaBinBoxDataSource
        {
            set { SetComboBox(actorBackgroundMediaBinBox, value); }
        }

        public string ActorBackgroundMediaBinName
        {
            get { return actorBackgroundMediaBinBox.Text; }
            set { actorBackgroundMediaBinBox.Text = value; }
        }

        public bool IsCreateOneEventCheck
        {
            get { return createOneEventCheck.Checked; }
            set { createOneEventCheck.Checked = value; }
        }

        public List<string> JimakuPresetBoxDataSource
        {
            set { SetComboBox(jimakuPresetBox, value); }
        }

        public string JimakuPresetName
        {
            get { return jimakuPresetBox.Text; }
            set { jimakuPresetBox.Text = value; }
        }

        public List<string> ActorPresetBoxDataSource
        {
            set { SetComboBox(actorPresetBox, value); }
        }

        public string ActorPresetName
        {
            get { return actorPresetBox.Text; }
            set { actorPresetBox.Text = value; }
        }

        public double JimakuMargin
        {
            get { return GetBoxValue<double>(jimakuMarginBox); }
            set { SetBoxValue(jimakuMarginBox, value); }
        }

        public double ActorMargin
        {
            get { return GetBoxValue<double>(actorMarginBox); }
            set { SetBoxValue(actorMarginBox, value); }
        }

        public bool DivideTracks
        {
            get { return divideTrackChecBox.Checked; }
            set { divideTrackChecBox.Checked = value; }
        }

        public bool IsTachieCheck
        {
            get { return tachieCheck.Checked; }
            set { tachieCheck.Checked = value; }
        }

        public string TachieTrackName
        {
            get { return tachieBox.Text; }
            set { tachieBox.Text = value; }
        }

        public bool IsBGCheck
        {
            get { return bgCheck.Checked; }
            set { bgCheck.Checked = value; }
        }

        public string BGTrackName
        {
            get { return bgBox.Text; }
            set { bgBox.Text = value; }
        }
    }
}
