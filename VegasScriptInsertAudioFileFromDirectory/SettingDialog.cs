using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VegasScriptInsertAudioFileFromDirectory
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        private void AudioFileFolderDialogOpenButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = AudioFileFolderText.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                AudioFileFolderText.Text = folderBrowser.SelectedPath;
            }
        }

        public string AudioFileFolder {
            get { return AudioFileFolderText.Text; }
            set { AudioFileFolderText.Text = value; }
        }

        public float AudioInterval {
            get { return float.Parse(IntervalInputText.Text); }
            set { IntervalInputText.Text = value.ToString(); }
        }

        public bool IsRecursive {
            get { return IsRecursiveCheck.Checked; }
            set { IsRecursiveCheck.Checked = value; }
        }

        public bool StartFrom
        {
            get { return fromStart.Checked; }
            set
            {
                if (value)
                {
                    fromStart.Checked = true;
                    fromCurrent.Checked = false;
                }
                else
                {
                    fromStart.Checked = false;
                    fromStart.Checked = true;
                }
            }
        }

        public bool UseMediaBin
        {
            get { return useMediaBin.Checked; }
        }

        public string MediaBinName
        {
            get { return mediaBinName.Text; }
            set { mediaBinName.Text = value; }
        }

        public List<string> TrackNameDataSource
        {
            set { trackName.DataSource = value; }
        }

        public string TrackName
        {
            get { return trackName.Text; }
            set { trackName.Text = value; }
        }
    }
}
