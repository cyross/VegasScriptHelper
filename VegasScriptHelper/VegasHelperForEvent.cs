using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public AudioEvent CreateAudioEvent(AudioTrack track, Media media, Timecode start, double margin = 0.0f)
        {
            AudioStream stream = media.GetAudioStreamByIndex(0);

            return CreateAudioEvent(track, stream, start, stream.Length, margin);
        }

        public AudioEvent CreateAudioEvent(AudioTrack track, Media media, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioStream stream = media.GetAudioStreamByIndex(0);

            return CreateAudioEvent(track, stream, start, length, margin);
        }

        public AudioEvent CreateAudioEvent(AudioTrack track, AudioStream stream, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioEvent audioEvent = track.AddAudioEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            audioEvent.AddTake(stream);

            return audioEvent;
        }

        // 音声・声優なしパート用
        public AudioEvent CreateAudioEvent(AudioTrack track, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioEvent audioEvent = track.AddAudioEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            return audioEvent;
        }

        public VideoEvent CreateVideoEvent(VideoTrack track, Media media, Timecode start, double margin = 0.0f)
        {
            VideoStream stream = media.GetVideoStreamByIndex(0);
            return CreateVideoEvent(track, stream, start, stream.Length, margin);
        }

        public VideoEvent CreateVideoEvent(VideoTrack track, Media media, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoStream stream = media.GetVideoStreamByIndex(0);
            return CreateVideoEvent(track, stream, start, length, margin);
        }

        public VideoEvent CreateVideoEvent(VideoTrack track, VideoStream stream, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoEvent videoEvent = track.AddVideoEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            videoEvent.AddTake(stream);

            return videoEvent;
        }

        // 音声・声優なしパート用
        public VideoEvent CreateVideoEvent(VideoTrack track, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoEvent videoEvent = track.AddVideoEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            return videoEvent;
        }

        public TrackEvents GetEvents(Track track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            return track.Events;
        }

        public TrackEvents GetVideoEvents(bool throwException = true)
        {
            VideoTrack selected = SelectedVideoTrack(throwException);

            if (selected is null) { return null; }

            return GetVideoEvents(selected, throwException);
        }

        public TrackEvents GetVideoEvents(VideoTrack track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            return track.Events;
        }

        public TrackEvents GetAudioEvents(bool throwException = true)
        {
            AudioTrack selected = SelectedAudioTrack(throwException);

            if (selected is null) { return null; }

            return GetAudioEvents(selected, throwException);
        }

        public TrackEvents GetAudioEvents(AudioTrack track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            return track.Events;
        }

        public TrackEvent GetSelectedEvent(Track track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            foreach (TrackEvent e in track.Events)
            {
                if (e.Selected) { return e; }
            }

            if (throwException) { throw new VegasHelperNoneSelectedEventException(); }

            return null;
        }

        public TrackEvent GetSelectedEvent(bool throwException = true)
        {
            Track track = SelectedTrack(throwException);

            if (track is null) { return null; }

            return GetSelectedEvent(track, throwException);
        }

        public TrackEvent GetSelectedVideoEvent(bool throwException = true)
        {
            Track track = SelectedVideoTrack(throwException);

            if (track is null) { return null; }

            return GetSelectedEvent(track, throwException);
        }

        public TrackEvent GetSelectedAudioEvent(bool throwException = true)
        {
            Track track = SelectedAudioTrack(throwException);

            if (track is null) { return null; }

            return GetSelectedEvent(track, throwException);
        }

        public Timecode GetEventStartTime(TrackEvent trackEvent)
        {
            return trackEvent.Start;
        }

        public void SetEventStartTime(TrackEvent trackEvent, Timecode start)
        {
            trackEvent.Start = start;
        }

        public Timecode GetEventLength(TrackEvent trackEvent)
        {
            return trackEvent.Length;
        }

        public void SetEventLength(TrackEvent trackEvent, Timecode length)
        {
            trackEvent.Length = length;
        }

        public VegasDuration GetEventTime(TrackEvent trackEvent)
        {
            VegasDuration duration = new VegasDuration();

            duration.StartTime = trackEvent.Start;
            duration.Length = trackEvent.Length;

            return duration;
        }

        public void SetEventTime(TrackEvent trackEvent, VegasDuration duration, double margin = 0.0f, bool adjustTakes = true)
        {
            Timecode start = duration.StartTime - new Timecode(margin);
            Timecode length = duration.Length + new Timecode(margin * 2);

            trackEvent.AdjustStartLength(start, length, adjustTakes);
        }

        public TrackEvent GetFirstEvent(TrackEvents events, bool throwException = true)
        {
            if (throwException && events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            return events[0];
        }

        public TrackEvent GetLastEvent(TrackEvents events, bool throwException = true)
        {
            if (throwException && events.Count == 0) { throw new VegasHelperNoneEventsException(); }

            return events[events.Count - 1];
        }

        public List<TrackEvent> GetEventsFromSelected(TrackEvents events, TrackEvent first, TrackEvent last)
        {
            return events.Where(e => e.Start >= first.Start && e.Start <= last.Start).ToList();
        }

        public List<TrackEvent> GetRemainEvents(TrackEvents events, TrackEvent last)
        {
            return events.Where(e => e.Start > last.Start).ToList();
        }
    }
}
