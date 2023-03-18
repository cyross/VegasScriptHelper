using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptInsertAudioFileFromDirectory
{
    public partial class SettingDialog : Form
    {
        private readonly PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VHUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;

            Font f_bold = new Font(myFontCollection.Families[0], 9, FontStyle.Bold);
            noticeLabel.Font = f_bold;
        }

        private void AudioFileFolderDialogOpenButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog() {
                SelectedPath = AudioFileFolderText.Text
            };

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
            set { useMediaBin.Checked = value; }
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
