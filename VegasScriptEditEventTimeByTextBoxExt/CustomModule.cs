using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptEditEventTimeByTextBoxExt;
using VegasScriptHelper;
using VegasScriptHelper.Enums;
using VegasScriptHelper.Settings;

namespace VegasScriptEditEventTimeByTextBox
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "EditEventTime";
        public readonly static string DockDisplayName = "イベントの開始時間と長さ";
        private TrackEvent selectedEvent = null;
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
            myView = new SettingDialog() {
                Dock = DockStyle.Fill,
                RulerFormat = rulerFormat
            };
            myView.textUpdateHandler = (Timecode startTime, Timecode timeLength) =>
            {
                using (new UndoBlock("EditEventTimeEx"))
                {
                    if (selectedEvent == null) { return; }

                    myView.SetFromDialog(selectedEvent);

                    myHelper.Config[Names.WdTime.Ruler.Format] = (int)myView.RulerFormat;
                }
            };
            if (selectedEvent != null) { myView.SetFromDialog(selectedEvent); }
            Controls.Add(myView.MainPanel);
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }

        public void GetSelectedEvent()
        {
            if (myView == null) { return; }

            foreach(var track in myHelper.Project.AllTracks)
            {
                TrackEvent selected = myHelper.Event.Get(track, false);
                if (selected != null)
                {
                    selectedEvent = selected;
                    myView.MainPanel.Enabled = true;
                    myView.SetToDialog(selectedEvent);
                    return;
                    
                }
            }

            selectedEvent = null;
            myView.StartTime = new Timecode();
            myView.TimeLength = new Timecode();
            myView.MainPanel.Enabled = false;
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        public readonly static string CommandName = "イベントの開始時間と長さを編集";
        private VegasHelper myHelper;
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.Edit, CommandName);

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
            myCommand.Checked = myHelper.App.FindDockView(MyDockableControl.DockName);
        }

        void OnTrackEventStateChanged(Object sender, EventArgs e)
        {
            IDockView dockView = null;

            if (myHelper.App.FindDockView(MyDockableControl.DockName, ref dockView))
            {
                MyDockableControl myDockViewControl = (MyDockableControl)dockView;
                myDockViewControl.GetSelectedEvent();
            }
        }
    }
}
