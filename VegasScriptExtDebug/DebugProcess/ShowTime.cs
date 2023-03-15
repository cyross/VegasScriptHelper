using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptExtDebug.DebugProcess
{
    internal class ShowTime : IDebugProcess
    {
        private readonly VegasHelper helper;
        private readonly DockableControl dock;

        public ShowTime(VegasHelper helper, DockableControl dock)
        {
            this.helper = helper;
            this.dock = dock;
        }

        public void Exec()
        {
            try
            {
                Timecode time = helper.GetLengthFromAllEventsInTrack();
                string result = string.Format("長さ: {0}", time.ToString(RulerFormat.Time));

                Label label1 = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = result,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                };
                dock.Controls.Add(label1);
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }
    }
}
