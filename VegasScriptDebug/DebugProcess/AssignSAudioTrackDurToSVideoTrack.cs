using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptDebug.DebugProcess
{
    internal class AssignSAudioTrackDurToSVideoTrack : IDebugProcess
    {
        private readonly VegasHelper helper;

        public AssignSAudioTrackDurToSVideoTrack(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            try
            {
                helper.AssignAudioTrackDurationToVideoTrack(helper.Settings[SN.WdJimaku.Margin]);
            }
            catch (VegasHelperNotFoundTrackException)
            {
                MessageBox.Show("所定の名前のトラックが見つかりません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("所定のトラック中にイベントが存在していません。");
            }
        }
    }
}
