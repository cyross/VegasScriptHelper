using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public class VHVideoEvent
    {
        private VegasHelper myHelper;

        public VHVideoEvent(VegasHelper helper)
        {
            myHelper = helper;
        }

        public VideoEvent Create(VideoTrack track, Media media, Timecode start, double margin = 0.0f)
        {
            VideoStream stream = media.GetVideoStreamByIndex(0);
            return Create(track, stream, start, stream.Length, margin);
        }

        public VideoEvent Create(VideoTrack track, Media media, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoStream stream = media.GetVideoStreamByIndex(0);
            return Create(track, stream, start, length, margin);
        }

        public VideoEvent Create(VideoTrack track, VideoStream stream, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoEvent videoEvent = track.AddVideoEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            videoEvent.AddTake(stream);

            return videoEvent;
        }

        // 音声・声優なしパート用
        public VideoEvent Create(VideoTrack track, Timecode start, Timecode length, double margin = 0.0f)
        {
            VideoEvent videoEvent = track.AddVideoEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            return videoEvent;
        }
        public TrackEvent Get(bool throwException = true)
        {
            Track track = myHelper.Project.SelectedVideoTrack(throwException);

            if (track is null) { return null; }

            return myHelper.Event.Get(track, throwException);
        }
    }
}
