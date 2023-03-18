using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Enums;
using VegasScriptSetJimakuColor;

namespace VegasScriptShowSelectedEventTime
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "ShowEventTime";
        public readonly static string DockDisplayName = "イベントの開始位置・長さ";
        private readonly VegasHelper myHelper;
        private StatusView myView;

        public MyDockableControl(VegasHelper helper) : base(DockName)
        {
            DisplayName = DockDisplayName;
            myHelper = helper;
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
            try
            {
                string[] results = GetStartAndLength();

                myView = new StatusView() { Dock = DockStyle.Fill };
                Controls.Add(myView.MainPanel);
                myHelper.App.LoadDockView(this);
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
        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }

        private string[] GetStartAndLength()
        {
            TrackEvent ev = myHelper.Event.Get(false);

            if (ev is null) { return new string[] { "", "" }; }

            string result1 = myHelper.Event.GetStartTime(ev).ToString();
            string result2 = myHelper.Event.GetLength(ev).ToString();

            return new string[] { result1, result2 };
        }

        public void UpdateLabel()
        {
            string[] results = GetStartAndLength();

            myView.StartTimeLabel = GetStartTimeString(results[0]);
            myView.LengthLabel = GetLengthString(results[1]);
        }

        private string GetStartTimeString(string timeString)
        {
            // ウインドウをドッキングさせるとタイトルが隠れるため「イベントの」で明示
            return string.Format("イベントの開始時間:{0}", timeString);
        }

        private string GetLengthString(string timeString)
        {
            // ウインドウをドッキングさせるとタイトルが隠れるため「イベントの」で明示
            return string.Format("イベントの長さ:{0}", timeString);
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        private VegasHelper myHelper;
        private readonly static string CommandName = "選択したイベントの開始位置・長さを表示";
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.View, CommandName);

        public void InitializeModule(Vegas vegas)
        {
            myHelper = VegasHelper.Instance(vegas);
        }

        public ICollection GetCustomCommands()
        {
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
