using System;
using System.Collections;
using ScriptPortal.Vegas;
using VegasScriptExtDebug.DebugProcess;
using VegasScriptHelper;

namespace VegasScriptExtDebug
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
            if(!helper.App.ActivateDockView(DockName))
            {
                    DockableControl dock = new DockableControl(DockName);
                    ShowTime st = new ShowTime(helper, dock);

                    st.Exec();

                    helper.App.LoadDockView(dock);
            }
        }

        void HandleMenuPopup(Object sender, EventArgs e)
        {
            myCommand.Checked = helper.App.FindDockView(DockName);
        }
    }
}
