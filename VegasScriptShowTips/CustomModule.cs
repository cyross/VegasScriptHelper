﻿using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptShowTips
{
    public class MyDockableControl : DockableControl
    {
        public readonly static string DockName = "CyrossVegasScriptShowTips";
        public readonly static string DockDisplayName = "VEGAS Tipsの表示";
        private TipsViewForm myform = null;

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
            get { return new Size(1063, 830); }
        }

        protected override void OnLoad(EventArgs args)
        {
            myform = new TipsViewForm() { Dock = DockStyle.Fill };
            try
            {
                myform.LoadTips();
                Controls.Add(myform.MainPanel);
            }
            catch (Exception ex)
            {
                string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                Debug.WriteLine("---[Exception In Helper]---");
                Debug.WriteLine(errMessage);
                Debug.WriteLine("---------------------------");
                MessageBox.Show(errMessage);
                throw ex;
            }
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }
    }

    public class CustomModule : ICustomCommandModule
    {
        public readonly static string CommandName = "Tipsの表示";
        private Vegas myVegas;
        private VegasHelper myHelper;
        private readonly CustomCommand myCommand = new CustomCommand(CommandCategory.View, CommandName);

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
            myCommand.Checked = myVegas.FindDockView(MyDockableControl.DockName);
        }
    }
}
