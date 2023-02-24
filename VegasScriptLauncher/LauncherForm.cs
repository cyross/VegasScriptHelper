using System;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using VegasScriptHelper;
using System.Diagnostics;

namespace VegasScriptLauncher
{
    public partial class LauncherForm : Form
    {
        private readonly Vegas Vegas = null;
        private readonly static VegasScriptCreateInitialBin.EntryPoint vscib = new VegasScriptCreateInitialBin.EntryPoint();
        private readonly static VegasScriptInsertAudioFileFromDirectory.EntryPoint viaffd = new VegasScriptInsertAudioFileFromDirectory.EntryPoint();
        private readonly static VegasScriptApplySerifuColor.EntryPoint vsassc = new VegasScriptApplySerifuColor.EntryPoint();
        private readonly static VegasScriptSetJimakuColor.EntryPoint vssjc = new VegasScriptSetJimakuColor.EntryPoint();
        private readonly static VegasScriptRemoveJimakuPrefix.EntryPoint vsrjp = new VegasScriptRemoveJimakuPrefix.EntryPoint();
        private readonly static VegasScriptAssignVideoEventFromAudioEvent.EntryPoint vsavefae = new VegasScriptAssignVideoEventFromAudioEvent.EntryPoint();
        private readonly static VegasScriptExpandFirstVideoEvent.EntryPoint efve = new VegasScriptExpandFirstVideoEvent.EntryPoint();
        private readonly static VegasScriptEditEventTime.EntryPoint vseet = new VegasScriptEditEventTime.EntryPoint();
        private readonly static VegasScriptAddMediaBinInSelectedTrack.EntryPoint vsambist = new VegasScriptAddMediaBinInSelectedTrack.EntryPoint();
        private readonly static VegasScriptUpdateSpaces.EntryPoint vsus = new VegasScriptUpdateSpaces.EntryPoint();
        private readonly static VegasScriptCreateJimaku.EntryPoint vscj = new VegasScriptCreateJimaku.EntryPoint();

        public LauncherForm(Vegas vegas)
        {
            Vegas = vegas;
            InitializeComponent();
        }

        public Panel InnerPanel
        {
            get { return panel1; }
        }

        private void ClickEvent(IEntryPoint entryPoint)
        {
            try
            {
                entryPoint.FromVegas(Vegas);
            }
            catch (Exception ex)
            {
                string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                Debug.WriteLine("---[Exception In EntryPoint]---");
                Debug.WriteLine(errMessage);
                Debug.WriteLine("-------------------------------");
                MessageBox.Show(errMessage);
                throw ex;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClickEvent(vscib);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClickEvent(viaffd);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ClickEvent(vsassc);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ClickEvent(vssjc);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ClickEvent(vsrjp);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ClickEvent(vsavefae);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ClickEvent(efve);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ClickEvent(vseet);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ClickEvent(vsambist);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClickEvent(vsus);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClickEvent(vscj);
        }
    }
}
