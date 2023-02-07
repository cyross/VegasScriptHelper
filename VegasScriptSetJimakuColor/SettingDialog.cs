using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VegasScriptSetJimakuColor
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        public List<string> TargetVideoTrackDataSource
        {
            set { targetVideoTrackName.DataSource = value; }
        }

        public string TargetVideoTrack
        {
            set { targetVideoTrackName.Text = value; }
            get { return targetVideoTrackName.Text; }
        }

        public Color JimakuColor
        {
            set
            {
                jimakuColorBox.BackColor = value;
                jimakuColorDialog.Color = value;
            }
            get { return jimakuColorBox.BackColor;}
        }

        public Color OutlineColor
        {
            set
            {
                outlineColorBox.BackColor = value;
                outlineColorDialog.Color = value;
            }
            get { return outlineColorBox.BackColor; }
        }

        public double OutlineWidth
        {
            set { outlineWidthBox.Text = value.ToString(); }
            get { return double.Parse(outlineWidthBox.Text); }
        }

        private void SettingForm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double outlineWidth = 0.0f;
            if(outlineWidthBox.Text == "0")
            {
                outlineWidthBox.Text = "0";
            }
            else if(!double.TryParse(outlineWidthBox.Text, out outlineWidth))
            {
                outlineWidthBox.Text = "0";
                okButton.Enabled = false;
            }
            else { okButton.Enabled = true; }
        }

        private void jimakuColorBox_Click(object sender, System.EventArgs e)
        {
            if(jimakuColorDialog.ShowDialog() == DialogResult.Cancel) { return; }

            jimakuColorBox.BackColor = jimakuColorDialog.Color;
        }

        private void outlineColorBox_Click(object sender, System.EventArgs e)
        {
            if (outlineColorDialog.ShowDialog() == DialogResult.Cancel) { return; }

            outlineColorBox.BackColor = outlineColorDialog.Color;
        }
    }
}
