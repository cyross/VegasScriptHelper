using System;
using System.Collections;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using VegasScriptHelper;

namespace VegasScriptDebug
{
    public class CustomModule : ICustomCommandModule
    {
        private VegasHelper helper;
        private readonly static string CommandName = "ShowTrackLength";
        private readonly static string DisplayName = "トラック中の全イベントの長さを表示";
        private readonly static string DockName = "全イベントの長さ";
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.Tools, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            helper = VegasHelper.Instance(vegas);
        }

        public ICollection GetCustomCommands()
        {
            myCommand.DisplayName = DisplayName;
            myCommand.Invoked += HandleInvoked;
            myCommand.MenuPopup += HandleMenuPopup;
            return new CustomCommand[] { myCommand };
        }

        void HandleInvoked(Object sender, EventArgs e)
        {
            if(!helper.ActivateDockView(DockName))
            {
                try
                {
                    long nanos = helper.GetLengthFromAllEventsInTrack() + 500000 / 1000000 * 1000000;
                    TimeSpan span = new TimeSpan(nanos);
                    string result = string.Format("長さ: {0}", span.ToString("g"));

                    DockableControl dock = new DockableControl(DockName);
                    Label label1 = new Label
                    {
                        Dock = DockStyle.Fill,
                        Text = result,
                        TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    };
                    dock.Controls.Add(label1);
                    helper.LoadDockView(dock);
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

        void HandleMenuPopup(Object sender, EventArgs e)
        {
            myCommand.Checked = helper.FindDockView(DockName);
        }
    }
}
