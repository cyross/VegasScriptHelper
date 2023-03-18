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
using VegasScriptHelper;

namespace VegasScriptCreateInitialBin
{
    public partial class SettingDialog : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VHUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;
        }

        public string VoiroVoiceBinName
        {
            get { return voiroVoiceBox.Text; }
            set { voiroVoiceBox.Text = value; }
        }

        public string VoiroJimakuBinName
        {
            get { return voiroJimakuBox.Text; }
            set { voiroJimakuBox.Text = value; }
        }

        public string VoiroActorBinName
        {
            get { return voiroActorBox.Text; }
            set { voiroActorBox.Text = value; }
        }

        public string JimakuBackgroundBinName
        {
            get { return jimakuBackgroundBox.Text; }
            set { jimakuBackgroundBox.Text = value; }
        }

        public string ActorBackgroundBinName
        {
            get { return actorBackgroundBox.Text; }
            set { actorBackgroundBox.Text = value; }
        }

        public string TachieBinName
        {
            get { return tachieBox.Text; }
            set { tachieBox.Text = value; }
        }

        public string DLAudioBinName
        {
            get { return dlAudioBox.Text; }
            set { dlAudioBox.Text = value; }
        }

        public string CreatedAudioBinName
        {
            get { return createdAudioBox.Text; }
            set { createdAudioBox.Text = value; }
        }

        public string DLMovieBinName
        {
            get { return dlMovieBox.Text; }
            set { dlMovieBox.Text = value; }
        }

        public string CreatedMovieBinName
        {
            get { return createdMovieBox.Text; }
            set { createdMovieBox.Text = value; }
        }

        public string DLImageBinName
        {
            get { return dlImageBox.Text; }
            set { dlImageBox.Text = value; }
        }

        public string CreatedImageBinName
        {
            get { return createdImageBox.Text; }
            set { createdImageBox.Text = value; }
        }
    }
}
