using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptAddMediaBinInSelectedTrack
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

        public object ExistBinNames
        {
            set { binName.DataSource = value; }
        }

        public string BinName
        {
            get { return binName.Text; }
            set { binName.Text = value; }
        }
    }
}
