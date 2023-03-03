using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptSetJimakuColor
{
    public partial class StatusView : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public StatusView()
        {
            InitializeComponent();
            
            pfc.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(pfc.Families[0], 9);
            Font = f_main;
            lengthLabel.Font = f_main;
        }

        public Panel MainPanel { get { return mainPanel; } }

        public string LengthLabel
        {
            set { lengthLabel.Text = value; }
        }
    }
}
