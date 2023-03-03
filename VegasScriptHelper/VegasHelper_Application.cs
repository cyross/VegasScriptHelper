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

        public void AddTrackEventDataChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackEventDataChanged += handler;
        }

        public void AddTrackEventCountChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackEventCountChanged += handler;
        }

        public void AddTrackEventTimeChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackEventTimeChanged += handler;
        }

        public void AddTrackEventStateChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackEventStateChanged += handler;
        }

        public void AddTrackCountChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackCountChanged += handler;
        }

        public void AddTrackStateChangedEventHandler(EventHandler handler)
        {
            Vegas.TrackStateChanged += handler;
        }
    }
}
