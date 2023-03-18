using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptSetJimakuColor
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
            if(outlineWidthBox.Text == "0")
            {
                outlineWidthBox.Text = "0";
            }
            else if(!double.TryParse(outlineWidthBox.Text, out double outlineWidth))
            {
                outlineWidthBox.Text = "0";
                okButton.Enabled = false;
            }
            else { okButton.Enabled = true; }
        }

        private void JimakuColorBox_Click(object sender, System.EventArgs e)
        {
            if(jimakuColorDialog.ShowDialog() == DialogResult.Cancel) { return; }

            jimakuColorBox.BackColor = jimakuColorDialog.Color;
        }

        private void OutlineColorBox_Click(object sender, System.EventArgs e)
        {
            if (outlineColorDialog.ShowDialog() == DialogResult.Cancel) { return; }

            outlineColorBox.BackColor = outlineColorDialog.Color;
        }
    }
}
