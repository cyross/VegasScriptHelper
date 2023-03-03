using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptAddMediaBinInSelectedTrack
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
