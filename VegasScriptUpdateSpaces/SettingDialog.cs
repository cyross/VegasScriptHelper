﻿using System;
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

namespace VegasScriptUpdateSpaces
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

        public double Space
        {
            get
            {
                return double.Parse(spaceBox.Text);
            }

            set
            {
                spaceBox.Text = value.ToString();
            }
        }
    }
}
