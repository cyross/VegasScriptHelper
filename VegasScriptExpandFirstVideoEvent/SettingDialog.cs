using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using VegasScriptHelper;

namespace VegasScriptExpandFirstVideoEvent
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
        }

        public List<string> VideoTrackNameDataSource
        {
            set { videoTrack.DataSource = value; }
        }

        public string VideoTrackName
        {
            get { return videoTrack.Text; }
            set { videoTrack.Text = value; }
        }

        public List<string> AudioTrackNameDataSource
        {
            set { audioTrack.DataSource = value; }
        }

        public string AudioTrackName
        {
            get { return audioTrack.Text; }
            set { audioTrack.Text = value; }
        }

        public double ExpandMargin
        {
            get { return double.Parse(marginBox.Text); }
            set { marginBox.Text = value.ToString(); }
        }
    }
}
