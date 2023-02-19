using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptUpdateSpaces
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        public double Space
        {
            get
            {
                return double.Parse(spaceBox.Text);
            }

            set
            {
                spaceBox.Text = value.ToString();
            }
        }
    }
}
