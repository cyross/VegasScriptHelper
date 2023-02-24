using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public struct BackgroundInfo
    {
        public bool IsCreate;
        public string TrackName;
        public VideoTrack Track;
        public string MediaName;
        public Media Media;
        public double Margin;
    }

    public partial class VegasHelper
    {
        public void InsertBackground(in BackgroundInfo info, AudioTrack audioTrack, bool isCreateOneEventCheck)
        {
            if (!info.IsCreate) { return; }

            if (isCreateOneEventCheck)
            {
                CreateFullSizeVideoEventWithAudioTrack(info.Track, audioTrack, info.Media, info.Margin);
            }
            else
            {
                CreateVideoEventWithAudioTrack(info.Track, audioTrack, info.Media, info.Margin);
            }
        }
    }
}
