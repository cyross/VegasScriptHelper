using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Duration;
using VegasScriptHelper.Settings;

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
                Assigner assigner = new Assigner(helper);
                assigner.Exec(helper.Config[Names.WdJimaku.Margin]);
            }
            catch (VHNotFoundTrackException)
            {
                MessageBox.Show("所定の名前のトラックが見つかりません。");
            }
            catch (VHNoneEventsException)
            {
                MessageBox.Show("所定のトラック中にイベントが存在していません。");
            }
        }
    }
}
