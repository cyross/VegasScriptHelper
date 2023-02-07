using ScriptPortal.Vegas;
using System.Diagnostics;
using System;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptEditEventTime
{
    public class EntryPoint: IEntryPoint
    {
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            try
            {
                TrackEvent trackEvent = helper.GetSelectedEvent();
                VegasDuration duration = helper.GetEventTime(trackEvent);

                if(settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.StartTime = duration.StartTime.Nanos;
                settingDialog.TimeLength = duration.Length.Nanos;

                if(settingDialog.ShowDialog() == DialogResult.OK)
                {
                    duration.StartTime.Nanos = settingDialog.StartTime;
                    duration.Length.Nanos = settingDialog.TimeLength;

                    using (new UndoBlock("イベントの開始時間・長さを編集"))
                    {
                        helper.SetEventTime(trackEvent, duration);
                    }
                }
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("トラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したトラック中にイベントが存在していません。");
            }
            catch(VegasHelperNoneSelectedEventException)
            {
                MessageBox.Show("イベントを選択していません。");
            }
            catch (Exception ex)
            {
                string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                Debug.WriteLine("---[Exception In Helper]---");
                Debug.WriteLine(errMessage);
                Debug.WriteLine("---------------------------");
                MessageBox.Show(
                    errMessage,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw ex;
            }
        }
    }
}
