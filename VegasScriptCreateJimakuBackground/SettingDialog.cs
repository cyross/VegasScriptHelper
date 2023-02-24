using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptCreateJimakuBackground
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        public List<string> AudioTrackBoxDataSource
        {
            set { audioTrackBox.DataSource = value; }
        }

        public string AudioTrackName
        {
            get { return audioTrackBox.Text; }
            set { audioTrackBox.Text = value; }
        }

        public List<string> VideoTrackBoxDataSource
        {
            set { videoTrackBox.DataSource = value; }
        }

        public string VideoTrackName
        {
            get { return videoTrackBox.Text; }
            set { videoTrackBox.Text = value; }
        }

        public List<string> TargetMediaBoxDataSource
        {
            set { targetMediaBox.DataSource = value; }
        }

        public string TargetMediaName
        {
            get { return targetMediaBox.Text; }
            set { targetMediaBox.Text = value; }
        }

        public double EventMargin
        {
            get { return double.Parse(marginBox.Text); }
        }

        public bool IscreateOneEventCheck
        {
            get { return createOneEventCheck.Checked; }
        }
    }
}
