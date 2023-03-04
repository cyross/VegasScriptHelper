using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptSetJimakuColor;

namespace VegasScriptShowSelectedEventTime
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "ShowEventTime";
        public readonly static string DockDisplayName = "イベントの開始位置・長さ";
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
            try
            {
                string[] results = GetStartAndLength();

                myView = new StatusView() { Dock = DockStyle.Fill };
                Controls.Add(myView.MainPanel);
                Helper.LoadDockView(this);
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
            TrackEvent ev = Helper.GetSelectedEvent(false);

            if (ev is null) { return new string[] { "", "" }; }

            string result1 = Helper.GetEventStartTime(ev).ToString();
            string result2 = Helper.GetEventLength(ev).ToString();

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
