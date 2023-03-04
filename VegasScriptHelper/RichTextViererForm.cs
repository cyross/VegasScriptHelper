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

namespace VegasScriptHelper
{
    public partial class RichTextViewForm : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public RichTextViewForm()
        {
            InitializeComponent();

            pfc.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(pfc.Families[0], 9);
            Font = f_main;
        }

        public string Rtf
        {
            get{ return richTextBox.Rtf; }
            set{ richTextBox.Rtf = value; }
        }

        public string RtfText
        {
            get { return richTextBox.Text; }
            set { richTextBox.Text = value; }
        }

        public RichTextBox RtfBox
        {
            get { return richTextBox; }
            set { richTextBox = value; }
        }
    }
}
