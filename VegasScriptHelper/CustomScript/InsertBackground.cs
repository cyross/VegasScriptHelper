using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public struct BackgroundInfo
    {
        public TrackInfo<VideoTrack> Track;
        public bool IsCreate;
        public MediaInfo Media;
        public double Margin;
        public MediaBinInfo MediaBin;
    }

    public partial class VegasHelper
    {
        public void InsertBackground(in BackgroundInfo info, AudioTrack audioTrack, bool isCreateOneEventCheck)
        {
            if (!info.IsCreate) { return; }

            if (isCreateOneEventCheck)
            {
                CreateFullSizeVideoEventWithAudioTrack(info.Track.Track, audioTrack, info.Media.Media, info.Margin);
            }
            else
            {
                CreateVideoEventWithAudioTrack(info.Track.Track, audioTrack, info.Media.Media, info.Margin);
            }
        }
    }
}
