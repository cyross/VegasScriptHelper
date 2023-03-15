using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;

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
                helper.DeleteJimakuPrefix();
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
