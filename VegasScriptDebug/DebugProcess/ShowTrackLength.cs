using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Duration;

namespace VegasScriptDebug.DebugProcess
{
    internal class ShowTrackLength : IDebugProcess
    {
        private readonly VegasHelper helper;

        public ShowTrackLength(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            try
            {
                Length length = new Length(helper);
                Timecode time = length.Get();
                string result = string.Format("長さ: {0}", time.ToString());
                MessageBox.Show(result);
            }
            catch (VHTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VHNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }
    }
}
