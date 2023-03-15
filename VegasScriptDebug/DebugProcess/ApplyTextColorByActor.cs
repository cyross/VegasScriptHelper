using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptDebug.DebugProcess
{
    internal class ApplyTextColorByActor : IDebugProcess
    {
        private readonly VegasHelper helper;

        public ApplyTextColorByActor(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            try
            {
                TrackEvents events = helper.GetVideoEvents();
                helper.ApplyTextColorByActor(events, 4.0, true);
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
