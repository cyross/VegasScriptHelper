using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Event;
using VegasScriptHelper.Settings;

namespace VegasScriptDebug.DebugProcess
{
    internal class ExpandFirstVideoEvent: IDebugProcess
    {
        private readonly VegasHelper helper;

        public ExpandFirstVideoEvent(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            Expander expander = new Expander(helper);
            double margin = helper.Config[Names.WdVideo.Expand.Event.Margin];
            try
            {
                expander.Exec(margin);
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
