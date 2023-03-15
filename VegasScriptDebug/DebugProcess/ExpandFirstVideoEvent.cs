using System.Windows.Forms;
using VegasScriptHelper;

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
            double margin = helper.Settings[SN.WdVideo.Expand.Event.Margin];
            try
            {
                helper.ExpandFirstVideoEvent(margin);
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
