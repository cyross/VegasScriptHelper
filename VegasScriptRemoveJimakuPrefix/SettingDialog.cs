using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptRemoveJimakuPrefix
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        public List<string> RemoveJimakuDataSource
        {
            set { removeJimakuBox.DataSource = value; }
        }

        public string RemoveJimakuTrackName
        {
            set { removeJimakuBox.Text = value; }
            get { return removeJimakuBox.Text; }
        }
    }
}
