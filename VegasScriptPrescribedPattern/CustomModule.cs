using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using VegasScriptHelper;

namespace VegasScriptPrescribedPattern
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "ドック名";
        public readonly static string DockDisplayName = "メニューに表示される名称";

        public MyDockableControl() : base(DockName)
        {
            DisplayName = DockDisplayName;
        }

        public override DockWindowStyle DefaultDockWindowStyle
        {
            get { return DockWindowStyle.Docked; }
        }

        public override Size DefaultFloatingSize
        {
            get { return new Size(640, 480); }
        }

        protected override void OnLoad(EventArgs args)
        {
#if true // for update script
            using (new UndoBlock("UpdateSpaces"))
            {
                // ここに本体を実装
            }
#else
                // ここに本体を実装
#endif
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        public readonly static string CommandName = "コマンド名";
        private VegasHelper myHelper;
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.View, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            myHelper = VegasHelper.Instance(vegas);
        }

        public ICollection GetCustomCommands()
        {
            myCommand.MenuPopup += HandleMenuPopup;
            myCommand.Invoked += HandleInvoked;
            return new CustomCommand[] { myCommand };
        }

        void HandleInvoked(Object sender, EventArgs e)
        {
            if (!myHelper.App.ActivateDockView(MyDockableControl.DockName))
            {
                MyDockableControl dock = new MyDockableControl()
                {
                    AutoLoadCommand = myCommand,
                    PersistDockWindowState = true
                };
                myHelper.App.LoadDockView(dock);
            }
        }

        void HandleMenuPopup(Object sender, EventArgs args)
        {
            myCommand.Checked = myHelper.App.FindDockView(MyDockableControl.DockName);
        }
    }
}
