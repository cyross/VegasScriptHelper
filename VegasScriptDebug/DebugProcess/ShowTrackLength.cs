using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;

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
                Timecode time = helper.GetLengthFromAllEventsInTrack();
                string result = string.Format("長さ: {0}", time.ToString());
                MessageBox.Show(result);
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
