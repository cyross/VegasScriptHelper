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

namespace VegasScriptApplySerifuColor
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

        public double OutlineWidth
        {
            get { return double.Parse(OutlineWidthTextBox.Text); }
            set { OutlineWidthTextBox.Text = value.ToString(); }
        }

        public bool RemovePrefix
        {
            get { return removePrefixFlag.Checked; }
            set { removePrefixFlag.Checked = value; }
        }

        public object JimakuTrackDataSource
        {
            set { jimakuTrackName.DataSource = value; }
        }

        public string JimakuTrackName
        {
            get { return jimakuTrackName.Text; }
            set { jimakuTrackName.Text = value;}
        }
    }
}
