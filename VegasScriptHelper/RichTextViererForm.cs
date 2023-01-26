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
    public partial class RitchTextViewForm : Form
    {
        public RitchTextViewForm()
        {
            InitializeComponent();
        }

        public string RitchText
        {
            get
            {
                return richTextBox.Rtf;
            }

            set
            {
                richTextBox.Rtf = value;
            }
        }
    }
}
