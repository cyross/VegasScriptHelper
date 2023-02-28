using System;
using System.Runtime;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using System.ComponentModel;

namespace VegasScriptCreateJimaku
{
    public enum PrefixBehaviorType
    {
        Remain = 0,
        Delete = 1,
        NewEvent = 2
    }

    public partial class SettingDialog : Form
    {
        private PrefixBehaviorType prefixBehavior;

        public SettingDialog()
        {
            InitializeComponent();

            SetColorToolTip(jimakuColorBox);
            SetColorToolTip(jimakuOutlineColorBox);
            SetColorToolTip(actorColorBox);
            SetColorToolTip(actorOutlineColorBox);

            UpdatePrefixBehavor();
        }

        public bool IsRemoveActorAttr
        {
            get { return removeActorAttributeCheck.Checked; }
            set { removeActorAttributeCheck.Checked = value; }
        }

        public PrefixBehaviorType PrefixBehavior
        {
            get { return prefixBehavior; }
            set { prefixBehavior = value; }
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
            set {
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

        public bool IsEventGroupCheck
        {
            get { return isGroupEventCheckBox.Checked; }
            set { isGroupEventCheckBox.Checked = value; }
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

        public bool SeparateTracks
        {
            get { return separateTrackChecBox.Checked; }
            set { separateTrackChecBox.Checked = value; }
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

        private void SetComboBox(ComboBox combobox, KeyListInfo klStruct)
        {
            SetComboBox(combobox, klStruct.Keys, klStruct.FirstKey);
        }

        private void SetComboBox(ComboBox combobox, List<string> list, string text = null)
        {
            combobox.Items.Clear();
            combobox.Items.AddRange(list.ToArray());

            if(text != null) { combobox.Text = text; }
        }

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

        public void GetTachieInfo(ref BasicTrackStruct tachieTrack)
        {
            tachieTrack.IsCreate = IsTachieCheck;
            tachieTrack.Info.Name = TachieTrackName;
        }

        public void GetBGInfo(ref BasicTrackStruct bgTrack)
        {
            bgTrack.IsCreate = IsBGCheck;
            bgTrack.Info.Name = BGTrackName;
        }

        private void SetBoxValue<T>(TextBox box, T value)
        {
            box.Text = value.ToString();
        }

        private T GetBoxValue<T>(TextBox box)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(box.Text);
        }

        private void SetColorToolTip(Control control)
        {
            colorTooltip.SetToolTip(control, "ボックスをクリックすると色の設定ができます");
        }

        private void UpdatePrefixBehavor()
        {
            if (remainActorName.Checked)
            {
                prefixBehavior = PrefixBehaviorType.Remain;
                actorGroup.Enabled = false;
            }
            if (deleteActorName.Checked)
            {
                prefixBehavior = PrefixBehaviorType.Delete;
                actorGroup.Enabled = false;
            }
            if (createNewEvent.Checked)
            {
                prefixBehavior = PrefixBehaviorType.NewEvent;
                actorGroup.Enabled = true;
            }
        }

        private void CreateBGEnabledChange(
            bool enabled,
            ComboBox trackBox, ComboBox mediaBox, TextBox marginBox, CheckBox useCheck, ComboBox bgMediaBinBox)
        {
            trackBox.Enabled = enabled;
            mediaBox.Enabled = enabled;
            marginBox.Enabled = enabled;
            useCheck.Enabled = enabled;
            bgMediaBinBox.Enabled = enabled;
        }

        private void ColorBoxClicked(PictureBox box, ColorDialog dialog)
        {
            dialog.Color = box.BackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                box.BackColor = dialog.Color;
            }
        }

        public DialogBGInfo JimakuBGInfo
        {
            get
            {
                return CreateBGInfo(
                    CreateJimakuBackground,
                    JimakuBackgroundTrackName,
                    JimakuBackgroundMediaName,
                    JimakuBackgroundMargin,
                    UseJimakuBackgroundMediaBin,
                    JimakuBackgroundMediaBinName
                    );
            }
        }

        public DialogBGInfo ActorBGInfo
        {
            get
            {
                return CreateBGInfo(
                    CreateActorBackground,
                    ActorBackgroundTrackName,
                    ActorBackgroundMediaName,
                    ActorBackgroundMargin,
                    UseActorBackgroundMediaBin,
                    ActorBackgroundMediaBinName
                    );
            }
        }

        public DialogBGInfo CreateBGInfo(bool createBg, string trackName, string mediaName, double margin, bool useBin, string binName)
        {
            DialogBGInfo bgInfo = new DialogBGInfo()
            {
                createBG = createBg,
                trackName = trackName,
                mediaName = mediaName,
                margin = margin,
                useMediaBin = useBin,
                mediaBinName = binName
            };
            return bgInfo;
        }

        public DialogTrackInfo JimakuTrackInfo
        {
            get
            {
                return CreateTrackInfo(
                    JimakuTrackName,
                    JimakuPresetName,
                    UseJimakuMediaBin,
                    JimakuMediaBinName
                    );
            }
        }

        public DialogTrackInfo ActorTrackInfo
        {
            get
            {
                return CreateTrackInfo(
                    ActorTrackName,
                    ActorPresetName,
                    UseActorMediaBin,
                    ActorMediaBinName
                    );
            }
        }

        public DialogTrackInfo CreateTrackInfo(string trackName, string presetName, bool useBin, string binName)
        {
            DialogTrackInfo info = new DialogTrackInfo()
            {
                trackName = trackName,
                presetName = presetName,
                useMediaBin = useBin,
                mediaBinName = binName
            };
            return info;
        }

        private void AudioFileFolderButton_Clicked(object sender, EventArgs e)
        {
            audioFileFolderBrowser.SelectedPath = audioFileFolderBox.Text;
            if (audioFileFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                audioFileFolderBox.Text = audioFileFolderBrowser.SelectedPath;
            }
        }

        private void JimakuFileDialogOpenButton_Clicked(object sender, EventArgs e)
        {
            jimakuFileBrowser.FileName = jimakuFilePathBox.Text;
            if (jimakuFileBrowser.ShowDialog() == DialogResult.OK)
            {
                jimakuFilePathBox.Text = jimakuFileBrowser.FileName;
            }
        }
        private void UseAudioMediaBin_Checked(object sender, EventArgs e)
        {
            audioMediaBinPanel.Enabled = useAudioMediaBin.Checked;
        }

        private void UseJimakuMediaBin_Checked(object sender, EventArgs e)
        {
            jimakuMediaBinPanel.Enabled = useJimakuMediaBin.Checked;
        }

        private void UseActorMediaBin_Checked(object sender, EventArgs e)
        {
            actorMediaBinPanel.Enabled = useActorMediaBin.Checked;
        }

        private void CreateJimakuBG_Checked(object sender, EventArgs e)
        {
            jimakuBGPanel.Enabled = createJimakuBackground.Checked;
        }

        private void CreateActorBG_Checked(object sender, EventArgs e)
        {
            actorBGPanel.Enabled = createActorBackground.Checked;
        }

        private void UseJimakuBGMediaBin_Checked(object sender, EventArgs e)
        {
            jimakuBGMediaBinPanel.Enabled = useJimakuMediaBin.Checked;
        }

        private void UseActorBGMediaBin_Checked(object sender, EventArgs e)
        {
            actorBGMediaBinPanel.Enabled = useActorMediaBin.Checked;
        }

        private void JimakuColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(jimakuColorBox, jimakuColorDialog);
        }

        private void JimakuOutlineColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(jimakuOutlineColorBox, jimakuOutlineColorDialog);
        }

        private void ActorColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(actorColorBox, actorColorDialog);
        }

        private void ActorOutlineColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(actorOutlineColorBox, actorOutlineColorDialog);
        }

        private void RemainActorName_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrefixBehavor();
        }

        private void DeleteActorName_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrefixBehavor();
        }

        private void CreateNewEvent_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrefixBehavor();
        }

        private void Tachie_CheckedChanged(object sender, EventArgs e)
        {
            tachiePanel.Enabled = tachieCheck.Checked;
        }
    }
}
