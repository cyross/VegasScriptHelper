using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptApplySerifuColor
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        public double OutlineWidth
        {
            get { return double.Parse(OutlineWidthTextBox.Text); }
            set { OutlineWidthTextBox.Text = value.ToString(); }
        }

        public bool RemovePrefix
        {
            get { return RemovePrefixFlag.Checked; }
            set { RemovePrefixFlag.Checked = value; }
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
