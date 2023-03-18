using ScriptPortal.Vegas;
using System.Web;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Event;

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
                ColorApplier applier = new ColorApplier(helper);
                TrackEvents events = helper.VideoTrack.Events();
                applier.Exec(events, 4.0, true);
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
