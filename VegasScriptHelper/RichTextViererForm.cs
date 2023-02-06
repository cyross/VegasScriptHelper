using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptHelper
{
    public partial class RichTextViewForm : Form
    {
        public RichTextViewForm()
        {
            InitializeComponent();
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
