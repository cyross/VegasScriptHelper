using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public Media CreateMedia(string path)
        {
            return new Media(path);
        }

        public Media[] GetMediaList(Track track)
        {
            if (track is null) { return null; }

            return GetMediaList(track.Events);
        }

        public Media[] GetVideoMediaList()
        {
            VideoTrack selected = SelectedVideoTrack();

            return GetMediaList(selected);
        }

        public Media[] GetAudioMediaList()
        {
            AudioTrack selected = SelectedAudioTrack();

            return GetMediaList(selected);
        }

        public Media[] GetMediaList(TrackEvents events)
        {
            if (events is null) { return null; }

            // テイクは考慮しない
            IEnumerable<Media> mediaList = events.Select(e => e.Takes[0].Media);
            return mediaList.ToArray();
        }
    }
}
