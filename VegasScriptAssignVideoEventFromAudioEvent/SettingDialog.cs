using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptAssignVideoEventFromAudioEvent
{
    public partial class SettingDialog : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;
        }

        public List<string> JimakuTrackNameDataSource
        {
            set { targetVideoTrack.DataSource = value; } 
        }

        public string JimakuTrackName
        {
            get { return targetVideoTrack.Text; }
            set { targetVideoTrack.Text = value; }
        }

        public List<string> VoiceTrackNameDataSource
        {
            set { targetAudioTrack.DataSource = value;}
        }

        public string VoiceTrackName
        {
            get { return targetAudioTrack.Text; }
            set { targetAudioTrack.Text = value; }
        }

        public double JimakuMargin
        {
            get { return double.Parse(marginBox.Text); }
            set { marginBox.Text = value.ToString(); }
        }
    }
}
