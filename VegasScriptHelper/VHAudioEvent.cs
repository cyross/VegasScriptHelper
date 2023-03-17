using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public class VHAudioEvent
    {
        private VegasHelper myHelper;

        public VHAudioEvent(VegasHelper helper)
        {
            myHelper = helper;
        }

        public AudioEvent Create(AudioTrack track, Media media, Timecode start, double margin = 0.0f)
        {
            AudioStream stream = media.GetAudioStreamByIndex(0);

            return Create(track, stream, start, stream.Length, margin);
        }

        public AudioEvent Create(AudioTrack track, Media media, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioStream stream = media.GetAudioStreamByIndex(0);

            return Create(track, stream, start, length, margin);
        }

        public AudioEvent Create(AudioTrack track, AudioStream stream, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioEvent audioEvent = track.AddAudioEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            audioEvent.AddTake(stream);

            return audioEvent;
        }

        // 音声・声優なしパート用
        public AudioEvent Create(AudioTrack track, Timecode start, Timecode length, double margin = 0.0f)
        {
            AudioEvent audioEvent = track.AddAudioEvent(
                start - new Timecode(margin),
                length + new Timecode(margin * 2)
                );

            return audioEvent;
        }

        public TrackEvent Get(bool throwException = true)
        {
            Track track = myHelper.Project.SelectedAudioTrack(throwException);

            if (track is null) { return null; }

            return myHelper.Event.Get(track, throwException);
        }
    }
}
