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

namespace VegasScriptRemoveJimakuPrefix
{
    public partial class SettingDialog : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;
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
