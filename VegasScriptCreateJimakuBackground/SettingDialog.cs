using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateJimakuBackground
{
    public partial class SettingDialog : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            pfc.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(pfc.Families[0], 9);
            Font = f_main;
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
