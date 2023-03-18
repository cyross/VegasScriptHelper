using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Enums;
using VegasScriptHelper.ExtProc.Duration;
using VegasScriptSetJimakuColor;

namespace VegasScriptShowTrackLength
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "ShowTrackLength";
        public readonly static string DockDisplayName = "トラックの長さ(間隔込み)";
        private readonly VegasHelper myHelper;
        private StatusView myView;
        private readonly Length length;

        public MyDockableControl(VegasHelper helper) : base(DockName)
        {
            DisplayName = DockDisplayName;
            myHelper = helper;
            length = new Length(myHelper);
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

            result += length.Get(false)?.ToString() ?? "";

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
        private readonly static string CommandName = "選択したトラックの長さを表示(間隔込み)";
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.View, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            myHelper = VegasHelper.Instance(vegas);
        }

        public ICollection GetCustomCommands()
        {
            myHelper.App.AddAppEvent[EHTarget.Track][(int)TrackEHs.CountChanged](OnTrackEventStateChanged);
            myHelper.App.AddAppEvent[EHTarget.Track][(int)TrackEHs.StateChanged](OnTrackEventStateChanged);
            myHelper.App.AddAppEvent[EHTarget.TrackEvent][(int)EventEHs.DataChanged](OnTrackEventStateChanged);
            myHelper.App.AddAppEvent[EHTarget.TrackEvent][(int)EventEHs.CountChanged](OnTrackEventStateChanged);
            myHelper.App.AddAppEvent[EHTarget.TrackEvent][(int)EventEHs.TimeChanged](OnTrackEventStateChanged);
            myHelper.App.AddAppEvent[EHTarget.TrackEvent][(int)EventEHs.StateChanged](OnTrackEventStateChanged);

            myCommand.DisplayName = MyDockableControl.DockDisplayName;
            myCommand.Invoked += HandleInvoked;
            myCommand.MenuPopup += HandleMenuPopup;

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

        void HandleMenuPopup(Object sender, EventArgs e)
        {
            myCommand.Checked = myHelper.App.FindDockView(MyDockableControl.DockName);
        }

        void OnTrackEventStateChanged(Object sender, EventArgs e)
        {
            IDockView dockView = null;

            if (myHelper.App.FindDockView(MyDockableControl.DockName, ref dockView))
            {
                MyDockableControl myDockViewControl = (MyDockableControl)dockView;
                myDockViewControl.UpdateLabel();
            }
        }
    }
}
