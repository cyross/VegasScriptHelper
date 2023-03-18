using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHAudioTrack
    {
        private VegasHelper myHelper;

        public VHAudioTrack(VegasHelper helper)
        {
            myHelper = helper;
        }

        public TrackEvents Events(bool throwException = true)
        {
            AudioTrack selected = myHelper.Project.SelectedAudioTrack(throwException);

            if (selected is null) { return null; }

            return Events(selected, throwException);
        }

        public TrackEvents Events(AudioTrack track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VHNoneEventsException(); }

            return track.Events;
        }

        public string GetTitle(bool throwException = true)
        {
            AudioTrack track = myHelper.Project.SelectedAudioTrack(throwException);

            if (track is null) { return null; }

            return track.Name;
        }

        public void SetTitle(string title, bool throwException = true)
        {
            AudioTrack track = myHelper.Project.SelectedAudioTrack(throwException);

            if (track is null) { return; }

            track.Name = title;
        }

        public Dictionary<string, AudioTrack> GetKV(List<AudioTrack> tracks)
        {
            return myHelper.Track.GetKV(tracks);
        }

        public Dictionary<string, AudioTrack> KV
        {
            get
            {
                Dictionary<string, AudioTrack> keyValuePairs = new Dictionary<string, AudioTrack>();

                List<AudioTrack> tracks = myHelper.Project.AllAudioTracks.ToList();

                foreach (AudioTrack track in tracks)
                {
                    keyValuePairs[myHelper.Track.GetKey(track)] = track;
                }

                return keyValuePairs;
            }
        }
    }
}
