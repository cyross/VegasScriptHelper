using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using VegasScriptHelper.Enums;

namespace VegasScriptHelper
{
    public class VHApp
    {
        private Vegas vegas;
        private Dictionary<EHTarget, Dictionary<int, Action<EventHandler>>> events;

        public VHApp(Vegas vegas) {
            this.vegas = vegas;
            events = new Dictionary<EHTarget, Dictionary<int, Action<EventHandler>>>();
            AddEventDict(EHTarget.Track, (int)TrackEHs.CountChanged, AddTrackCountChanged);
            AddEventDict(EHTarget.Track, (int)TrackEHs.StateChanged, AddTrackStateChanged);
            AddEventDict(EHTarget.TrackEvent, (int)EventEHs.DataChanged, AddTrackEventDataChanged);
            AddEventDict(EHTarget.TrackEvent, (int)EventEHs.CountChanged, AddTrackEventCountChanged);
            AddEventDict(EHTarget.TrackEvent, (int)EventEHs.TimeChanged, AddTrackEventTimeChanged);
            AddEventDict(EHTarget.TrackEvent, (int)EventEHs.StateChanged, AddTrackEventStateChanged);
        }

        public bool ActivateDockView(string dockName)
        {
            return vegas.ActivateDockView(dockName);
        }

        public void LoadDockView(DockableControl dockView)
        {
            vegas.LoadDockView(dockView);
        }

        public bool FindDockView(string dockName)
        {
            return vegas.FindDockView(dockName);
        }

        public bool FindDockView(string dockname, ref IDockView dockView)
        {
            return vegas.FindDockView(dockname, out dockView);
        }

        public Dictionary<EHTarget, Dictionary<int, Action<EventHandler>>> AddAppEvent
        {
            get { return events; }
        }

        private void AddEventDict(EHTarget targetType, int idx, Action<EventHandler> eh) {
            if (!events.ContainsKey(targetType)) { events[targetType] = new Dictionary<int, Action<EventHandler>>(); }
            events[targetType][idx] = eh;
        }

        private void AddTrackCountChanged(EventHandler handler)
        {
            vegas.TrackCountChanged += handler;
        }

        public void AddTrackStateChanged(EventHandler handler)
        {
            vegas.TrackStateChanged += handler;
        }

        private void AddTrackEventDataChanged(EventHandler handler)
        {
            vegas.TrackEventDataChanged += handler;
        }

        private void AddTrackEventCountChanged(EventHandler handler)
        {
            vegas.TrackEventCountChanged += handler;
        }

        private void AddTrackEventTimeChanged(EventHandler handler)
        {
            vegas.TrackEventTimeChanged += handler;
        }

        private void AddTrackEventStateChanged(EventHandler handler)
        {
            vegas.TrackEventStateChanged += handler;
        }
    }
}
