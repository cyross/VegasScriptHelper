using System.Windows.Forms;

namespace VegasScriptAddMediaBinInSelectedTrack
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
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
