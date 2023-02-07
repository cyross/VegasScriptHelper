using System.Windows.Forms;
using System.Collections.Generic;

namespace ExpandFirstVideoEvent
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
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
