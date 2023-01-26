using ScriptPortal.Vegas;
using System;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public bool ActivateDockView(string dockName)
        {
            return Vegas.ActivateDockView(dockName);
        }

        public void LoadDockView(DockableControl dockView)
        {
            Vegas.LoadDockView(dockView);
        }

        public bool FindDockView(string dockName)
        {
            return Vegas.FindDockView(dockName);
        }

        public bool FindDockView(string dockname, ref IDockView dockView)
        {
            return Vegas.FindDockView(dockname, out dockView);
        }

        public void AddTrackEventStateChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackEventStateChanged += handler;
        }
    }
}
