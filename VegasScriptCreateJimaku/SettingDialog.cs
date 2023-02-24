using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;

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

        public PrefixBehaviorType PrefixBehavior
        {
            get { return prefixBehavior; }
            set { prefixBehavior = value; }
        }

        public List<string> AudioTrackBoxDataSource
        {
            set {
                audioTrackNameBox.Items.Clear();
                audioTrackNameBox.Items.AddRange(value.ToArray());
            }
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
            get { return float.Parse(intervalBox.Text); }
            set { intervalBox.Text = value.ToString(); }
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
            set {
                audioMediaBinBox.Items.Clear();
                audioMediaBinBox.Items.AddRange(value.ToArray());
            }
        }

        public string AudioMediaBinName
        {
            get { return audioMediaBinBox.Text; }
            set { audioMediaBinBox.Text = value; }
        }

        public List<string> JimakuTrackBoxDataSource
        {
            set {
                jimakuTrackBox.Items.Clear();
                jimakuTrackBox.Items.AddRange(value.ToArray());
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
            set { jimakuOutlineWidthBox.Text = value.ToString(); }
            get { return double.Parse(jimakuOutlineWidthBox.Text); }
        }

        public List<string> ActorTrackBoxDataSource
        {
            set {
                actorTrackBox.Items.Clear();
                actorTrackBox.Items.AddRange(value.ToArray());
            }
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
            set { actorOutlineWidthBox.Text = value.ToString(); }
            get { return double.Parse(actorOutlineWidthBox.Text); }
        }

        public bool UseJimakuMediaBin
        {
            get { return useJimakuMediaBin.Checked; }
            set { useJimakuMediaBin.Checked = value; }
        }

        public List<string> JimakuMediaBinBoxDataSource
        {
            set {
                jimakuMediaBinBox.Items.Clear();
                jimakuMediaBinBox.Items.AddRange(value.ToArray());
            }
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
            set {
                actorMediaBinBox.Items.Clear();
                actorMediaBinBox.Items.AddRange(value.ToArray());
            }
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
            set {
                jimakuBackgroundTrackBox.Items.Clear();
                jimakuBackgroundTrackBox.Items.AddRange(value.ToArray());
            }
        }

        public string JimakuBackgroundTrackName
        {
            get { return jimakuBackgroundTrackBox.Text; }
            set { jimakuBackgroundTrackBox.Text = value; }
        }

        public List<string> JimakuBackgroundMediaBoxDataSource
        {
            set {
                jimakuBackgroundMediaBox.Items.Clear();
                jimakuBackgroundMediaBox.Items.AddRange(value.ToArray());
            }
        }

        public string JimakuBackgroundMediaName
        {
            get { return jimakuBackgroundMediaBox.Text; }
            set { jimakuBackgroundMediaBox.Text = value; }
        }

        public double JimakuBackgroundMargin
        {
            set { jimakuBackgroundMarginBox.Text = value.ToString(); }
            get { return double.Parse(jimakuBackgroundMarginBox.Text); }
        }

        public bool UseJimakuBackgroundMediaBin
        {
            get { return useJimakuBackgroundMediaBin.Checked; }
            set { useJimakuBackgroundMediaBin.Checked = value; }
        }

        public List<string> JimakuBackgroundMediaBinBoxDataSource
        {
            set {
                jimakuBackgroundMediaBinBox.Items.Clear();
                jimakuBackgroundMediaBinBox.Items.AddRange(value.ToArray());
            }
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
            set {
                actorBackgroundTrackBox.Items.Clear();
                actorBackgroundTrackBox.Items.AddRange(value.ToArray());
            }
        }

        public string ActorBackgroundTrackName
        {
            get { return actorBackgroundTrackBox.Text; }
            set { actorBackgroundTrackBox.Text = value; }
        }

        public List<string> ActorBackgroundMediaBoxDataSource
        {
            set {
                actorBackgroundMediaBox.Items.Clear();
                actorBackgroundMediaBox.Items.AddRange(value.ToArray());
            }
        }

        public string ActorBackgroundMediaName
        {
            get { return actorBackgroundMediaBox.Text; }
            set { actorBackgroundMediaBox.Text = value; }
        }

        public double ActorBackgroundMargin
        {
            set { actorBackgroundMarginBox.Text = value.ToString(); }
            get { return double.Parse(actorBackgroundMarginBox.Text); }
        }

        public bool UseActorBackgroundMediaBin
        {
            get { return useActorBackgroundMediaBin.Checked; }
            set { useActorBackgroundMediaBin.Checked = value; }
        }

        public List<string> ActorBackgroundMediaBinBoxDataSource
        {
            set {
                actorBackgroundMediaBinBox.Items.Clear();
                actorBackgroundMediaBinBox.Items.AddRange(value.ToArray());
            }
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
            set {
                jimakuPresetBox.Items.Clear();
                jimakuPresetBox.Items.AddRange(value.ToArray());
            }
        }

        public string JimakuPresetName
        {
            get { return jimakuPresetBox.Text; }
            set { jimakuPresetBox.Text = value; }
        }

        public List<string> ActorPresetBoxDataSource
        {
            set {
                actorPresetBox.Items.Clear();
                actorPresetBox.Items.AddRange(value.ToArray());
            }
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
            set { jimakuMarginBox.Text = value.ToString(); }
            get { return double.Parse(jimakuMarginBox.Text); }
        }

        public double ActorMargin
        {
            set { actorMarginBox.Text = value.ToString(); }
            get { return double.Parse(actorMarginBox.Text); }
        }

        public void SetAudioTrack(
            VegasHelper helper,
            List<string> audioKeyList,
            string firstAudioKey,
            List<string> mediaBinKeyList,
            string firstMediaBinKey)
        {
            AudioTrackBoxDataSource = audioKeyList;
            AudioTrackName = firstAudioKey;
            AudioFileFolder = helper.Settings["AudioFileFolder"];
            AudioInterval = helper.Settings["AudioInsertInterval"];
            IsRecursive = helper.Settings["IsAudioFolderRecursive"];
            IsInsertFromStartPosition = helper.Settings["IsInsertFromStartPosition"];

            AudioMediaBinBoxDataSource = mediaBinKeyList;
            AudioMediaBinName = firstMediaBinKey;
            UseAudioMediaBin = helper.Settings["UseAudioMediaBin"];
        }

        public void SetJimakuTrack(
            VegasHelper helper,
            List<string> videoKeyList,
            string firstVideoKey,
            List<string> pluginKeyList,
            string firstPluginKey,
            List<string> mediaBinKeyList,
            string firstMediaBinKey)
        {
            JimakuTrackBoxDataSource = videoKeyList;
            JimakuTrackName = firstVideoKey;
            JimakuPresetBoxDataSource = pluginKeyList;
            JimakuPresetName = firstPluginKey;
            JimakuMargin = helper.Settings["jimakuMargin"];
            JimakuMediaBinBoxDataSource = mediaBinKeyList;
            JimakuMediaBinName = firstMediaBinKey;
            UseJimakuMediaBin = helper.Settings["UseJimakuMediaBin"];
        }

        public void SetActorTrack(
            VegasHelper helper,
            List<string> videoKeyList,
            string firstVideoKey,
            List<string> pluginKeyList,
            string firstPluginKey,
            List<string> mediaBinKeyList,
            string firstMediaBinKeys)
        {
            ActorTrackBoxDataSource = videoKeyList;
            ActorTrackName = firstVideoKey;
            ActorPresetBoxDataSource = pluginKeyList;
            ActorPresetName = firstPluginKey;
            ActorMargin = helper.Settings["actorMargin"];
            ActorMediaBinBoxDataSource = mediaBinKeyList;
            ActorMediaBinName = firstMediaBinKeys;
            UseActorMediaBin = helper.Settings["UseActorMediaBin"];
        }

        public void SetJimakuColor(VegasHelper helper)
        {
            JimakuColor = helper.Settings["JimakuColor"];
            JimakuOutlineColor = helper.Settings["JimakuOutlineColor"];
            JimakuOutlineWidth = helper.Settings["JimakuOutlineWidth"];
            UseJimakuDefaultSettings = helper.Settings["UseJimakuColorSetting"];
        }
        public void SetActorColor(VegasHelper helper)
        {
            ActorColor = helper.Settings["ActorColor"];
            ActorOutlineColor = helper.Settings["ActorOutlineColor"];
            ActorOutlineWidth = helper.Settings["ActorOutlineWidth"];
            UseActorDefaultSettings = helper.Settings["UseActorColorSetting"];
        }

        public void SetJimakuBackground(
            VegasHelper helper,
            List<string> videoKeyList,
            string firstVideoKey,
            List<string> mediaKeyList,
            string firstMediaKey,
            List<string> mediaBinKeyList,
            string firstMediaBinKey)
        {
            JimakuBackgroundTrackBoxDataSource = videoKeyList;
            JimakuBackgroundTrackName = firstVideoKey;
            JimakuBackgroundMediaBoxDataSource = mediaKeyList;
            JimakuBackgroundMediaName = firstMediaKey;
            JimakuBackgroundMargin = helper.Settings["JimakuBackgroundMargin"];
            JimakuBackgroundMediaBinBoxDataSource = mediaBinKeyList;
            JimakuBackgroundMediaBinName = firstMediaBinKey;
            CreateJimakuBackground = helper.Settings["CreateJimakuBackground"];
        }

        public void SetActorBackground(
            VegasHelper helper,
            List<string> videoKeyList,
            string firstVideoKey,
            List<string> mediaKeyList,
            string firstMediaKey,
            List<string> mediaBinKeyList,
            string firstMediaBinKey)
        {
            ActorBackgroundTrackBoxDataSource = videoKeyList;
            ActorBackgroundTrackName = firstVideoKey;
            ActorBackgroundMediaBoxDataSource = mediaKeyList;
            ActorBackgroundMediaName = firstMediaKey;
            ActorBackgroundMargin = helper.Settings["ActorBackgroundMargin"];
            ActorBackgroundMediaBinBoxDataSource = mediaBinKeyList;
            ActorBackgroundMediaBinName = firstMediaBinKey;
            CreateActorBackground = helper.Settings["CreateActorBackground"];
        }

        private void CreateJimakuBackground_CheckedChanged(object sender, EventArgs e)
        {
            jimakuBackgroundTrackBox.Enabled = createJimakuBackground.Checked;
            jimakuBackgroundMediaBox.Enabled = createJimakuBackground.Checked;
            jimakuBackgroundMarginBox.Enabled = createJimakuBackground.Checked;
            useJimakuBackgroundMediaBin.Enabled = createJimakuBackground.Checked;
            jimakuBackgroundMediaBinBox.Enabled = createJimakuBackground.Checked;
        }

        private void CreateActorBackground_CheckedChanged(object sender, EventArgs e)
        {
            actorBackgroundTrackBox.Enabled = createActorBackground.Checked;
            actorBackgroundMediaBox.Enabled = createActorBackground.Checked;
            actorBackgroundMarginBox.Enabled = createActorBackground.Checked;
            useActorBackgroundMediaBin.Enabled = createActorBackground.Checked;
            actorBackgroundMediaBinBox.Enabled = createActorBackground.Checked;
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

        private void SetColorToolTip(Control control)
        {
            colorTooltip.SetToolTip(control, "ボックスをクリックすると色の設定ができます");
        }

        private void UpdateJimakuColorSettings(bool enabled)
        {
            jimakuColorBox.Enabled = enabled;
            jimakuOutlineColorBox.Enabled = enabled;
        }

        private void UpdateActorColorSettings(bool enabled)
        {
            actorColorBox.Enabled = enabled;
            actorOutlineColorBox.Enabled = enabled;
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

        private void UseAudioMediaBin_Checked(object sender, EventArgs e)
        {
            audioMediaBinBox.Enabled = useAudioMediaBin.Checked;
        }

        private void UseVideoMediaBin_Checked(object sender, EventArgs e)
        {
            jimakuMediaBinBox.Enabled = useJimakuMediaBin.Checked;
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

        private void ColorBoxClicked(PictureBox box, ColorDialog dialog)
        {
            dialog.Color = box.BackColor;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                box.BackColor = dialog.Color;
            }
        }

        private void UseJimakuDefaultSettings_Click(object sender, EventArgs e)
        {
            UpdateJimakuColorSettings(useJimakuDefaultSettings.Checked);
        }

        private void UseActorDefaultSettings_Click(object sender, EventArgs e)
        {
            UpdateActorColorSettings(useJimakuDefaultSettings.Checked);
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
    }
}
