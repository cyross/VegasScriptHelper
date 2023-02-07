using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptShowTrackLength
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "トラックの長さ(間隔込み)";
        public readonly static string DockDisplayName = "選択したトラックの長さを表示(間隔込み)";
        private readonly VegasHelper Helper;

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
                FlowLayoutPanel panel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill
                };

                Label label1 = CreateLabel("Result", Helper.GetLengthFromAllEventsInTrack(false)?.ToString() ?? "");

                panel.Controls.Add(label1);

                Controls.Add(panel);

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

        private string GetLength()
        {
            string result = "トラックの長さ:";

            result += Helper.GetLengthFromAllEventsInTrack(false)?.ToString() ?? "";

            return result;
        }

        public void UpdateLabel()
        {
            Controls[0].Controls[0].Text = GetLength();
        }

        private Label CreateLabel(string name, string text)
        {
            Label label = new Label()
            {
                Name = name,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft
            };

            return label;
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
            myHelper.AddTrackStateChangedEventHandler(OnTrackEventStateChanged); // イベントをクリックすると自動的に表示される

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
