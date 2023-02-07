using System.Windows.Forms;

namespace VegasScriptAddMediaBinInSelectedTrack
{
    public partial class BinSettingForm : Form
    {
        public BinSettingForm()
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
