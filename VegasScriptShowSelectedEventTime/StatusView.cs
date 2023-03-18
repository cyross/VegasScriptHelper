using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptSetJimakuColor
{
    public partial class StatusView : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public StatusView()
        {
            InitializeComponent();
            
            myFontCollection.AddFontFile(VHUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;
            startTimeLabel.Font = f_main;
            lengthLabel.Font = f_main;
        }

        public Panel MainPanel
        {
            get { return mainPanel; }
        }

        public string StartTimeLabel
        {
            set { startTimeLabel.Text = value; }
        }

        public string LengthLabel
        {
            set { lengthLabel.Text = value; }
        }
    }
}
