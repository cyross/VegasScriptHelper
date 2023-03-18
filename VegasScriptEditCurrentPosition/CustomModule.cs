using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Settings;

namespace VegasScriptEditCurrentPosition
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "EditCurrentPosition";
        public readonly static string DockDisplayName = "カーソル位置";
        private readonly VegasHelper myHelper;
        private SettingDialog myView;

        public MyDockableControl(VegasHelper helper) : base(DockName)
        {
            myHelper = helper;
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
            RulerFormat rulerFormat = (RulerFormat)myHelper.Config[Names.WdTime.Ruler.Format];
            myView = new SettingDialog(myHelper)
            {
                Dock = DockStyle.Fill,
                RulerFormat = rulerFormat,
                Current = new Timecode()
            };
            myView.textUpdateHandler = (Timecode current) =>
            {
                using (new UndoBlock("EditCurrentPosition"))
                {
                    myView.SetFromDialog(myHelper);

                    myHelper.Config[Names.WdTime.Ruler.Format] = (int)myView.RulerFormat;
                }
            };
            myView.SetFromDialog(myHelper);
            Controls.Add(myView.MainPanel);
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }

        public void UpdateCurrent()
        {
            if (myView == null) { return; }

            myView.SetToDialog(myHelper);
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        public readonly static string CommandName = "カーソル位置を編集";
        private Vegas myVegas;
        private VegasHelper myHelper;
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.Edit, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            myVegas = vegas;
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
                MyDockableControl dock = new MyDockableControl(myHelper)
                {
                    AutoLoadCommand = myCommand,
                    PersistDockWindowState = true
                };
                myHelper.App.LoadDockView(dock);
            }
        }

        void HandleMenuPopup(Object sender, EventArgs args)
        {
            myCommand.Checked = myVegas.FindDockView(MyDockableControl.DockName);
        }

        void OnTrackEventStateChanged(Object sender, EventArgs e)
        {
            IDockView dockView = null;

            if (myHelper.App.FindDockView(MyDockableControl.DockName, ref dockView))
            {
                MyDockableControl myDockViewControl = (MyDockableControl)dockView;
                myDockViewControl.UpdateCurrent();
            }
        }
    }
}
