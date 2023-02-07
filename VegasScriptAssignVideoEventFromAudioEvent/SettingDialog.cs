using System.Collections.Generic;
using System.Windows.Forms;

namespace VegasScriptAssignVideoEventFromAudioEvent
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
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
