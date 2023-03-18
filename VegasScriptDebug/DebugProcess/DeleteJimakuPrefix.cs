using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Jimaku;

namespace VegasScriptDebug.DebugProcess
{
    internal class DeleteJimakuPrefix : IDebugProcess
    {
        private readonly VegasHelper helper;

        public DeleteJimakuPrefix(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            try
            {
                DelPrefix delPrefix = new DelPrefix(helper);
                delPrefix.Exec();
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
