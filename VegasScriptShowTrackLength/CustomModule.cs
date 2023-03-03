using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptSetJimakuColor;

namespace VegasScriptShowTrackLength
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "トラックの長さ(間隔込み)";
        public readonly static string DockDisplayName = "選択したトラックの長さを表示(間隔込み)";
        private readonly VegasHelper Helper;
        private StatusView myView;

        public MyDockableControl(VegasHelper helper) : base(DockName)
        {
            DisplayName = DockDisplayName;
            Helper = helper;
        }

        public override DockWindowStyle DefaultDockWindowStyle
        {
            get { return DockWindowStyle.Docked; }
        }

        public override Size DefaultFloatingSize
        {
            get { return new Size(320, 240); }
        }

        protected override void OnLoad(EventArgs args)
        {
            myView = new StatusView() { Dock = DockStyle.Fill };
            Controls.Add(myView.MainPanel);
        }
        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }

        private string GetLength()
        {
            string result = "トラックの長さ:";

            result += Helper.GetLengthFromAllEventsInTrack(false)?.ToString() ?? "";

            return result;
        }

        public void UpdateLabel()
        {
            myView.LengthLabel = GetLength();
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        private VegasHelper myHelper;
        private readonly static string CommandName = "ShowTrackLength";
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.View, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            myHelper = VegasHelper.Instance(vegas);
        }

        public ICollection GetCustomCommands()
        {
            myHelper.AddTrackCountChangedEventHandler(OnTrackEventStateChanged);
            myHelper.AddTrackStateChangedEventHandler(OnTrackEventStateChanged);
            myHelper.AddTrackEventCountChangedEventHandler(OnTrackEventStateChanged);
            myHelper.AddTrackEventDataChangedEventHandler(OnTrackEventStateChanged);
            myHelper.AddTrackEventStateChangedEventHandler(OnTrackEventStateChanged);
            myHelper.AddTrackEventTimeChangedEventHandler(OnTrackEventStateChanged);

            myCommand.DisplayName = MyDockableControl.DockDisplayName;
            myCommand.Invoked += HandleInvoked;
            myCommand.MenuPopup += HandleMenuPopup;

            return new CustomCommand[] { myCommand };
        }

        void HandleInvoked(Object sender, EventArgs e)
        {
            if (!myHelper.ActivateDockView(MyDockableControl.DockName))
            {
                MyDockableControl dock = new MyDockableControl(myHelper)
                {
                    AutoLoadCommand = myCommand,
                    PersistDockWindowState = true
                };

                myHelper.LoadDockView(dock);
            }
        }

        void HandleMenuPopup(Object sender, EventArgs e)
        {
            myCommand.Checked = myHelper.FindDockView(MyDockableControl.DockName);
        }

        void OnTrackEventStateChanged(Object sender, EventArgs e)
        {
            IDockView dockView = null;

            if (myHelper.FindDockView(MyDockableControl.DockName, ref dockView))
            {
                MyDockableControl myDockViewControl = (MyDockableControl)dockView;
                myDockViewControl.UpdateLabel();
            }
        }
    }
}
