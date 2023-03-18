using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public struct KeyListManager
    {
        public Dictionary<string, AudioTrack> AudioTKV;
        public Dictionary<string, VideoTrack> VideoTKV;
        public Dictionary<string, Media> MKV;
        public Dictionary<string, MediaBin> MbKV;
        public KeyListInfo Audio;
        public KeyListInfo Jimaku;
        public KeyListInfo Actor;
        public KeyListInfo JimakuBG;
        public KeyListInfo ActorBG;
        public KeyListInfo JimakuPlugin;
        public KeyListInfo ActorPlugin;
        public KeyListInfo JimakuBGMedia;
        public KeyListInfo ActorBGMedia;
        public KeyListInfo AudioMBin;
        public KeyListInfo JimakuMBin;
        public KeyListInfo ActorMBin;
        public KeyListInfo JimakuBGMBin;
        public KeyListInfo ActorBGMBin;

        public void SetupAudio(VegasHelper helper, List<AudioTrack> audioTracks)
        {
            AudioTKV = helper.AudioTrack.GetKV(audioTracks);
            Audio = CreateAudioTrackKL(helper, "Audio");
        }

        public void SetupVideo(VegasHelper helper, List<VideoTrack> videoTracks)
        {
            VideoTKV = helper.VideoTrack.GetKV(videoTracks);
            Jimaku = CreateVideoTrackKL(helper, "Jimaku");
            Actor = CreateVideoTrackKL(helper, "Actor");
            JimakuBG = CreateVideoTrackKL(helper, "JimakuBG");
            ActorBG = CreateVideoTrackKL(helper, "ActorBG");
        }

        public void SetupPlugin(VegasHelper helper)
        {
            JimakuPlugin = CreatePluginKL(helper, "Jimaku");
            ActorPlugin = CreatePluginKL(helper, "Actor");
        }

        public void SetupMedia(VegasHelper helper, List<Media> mediaList)
        {
            MKV = helper.Media.GetKV(mediaList);
            JimakuBGMedia = CreateMediaKL(helper, "JimakuBG");
            ActorBGMedia = CreateMediaKL(helper, "ActorBG");
        }

        public void SetupMediaBin(VegasHelper helper, List<MediaBin> mediaBinList)
        {
            MbKV = helper.MediaBin.GetKV(mediaBinList);
            AudioMBin = CreateMediaBinKL(helper, "Audio");
            JimakuMBin = CreateMediaBinKL(helper, "Jimaku");
            ActorMBin = CreateMediaBinKL(helper, "Actor");
            JimakuBGMBin = CreateMediaBinKL(helper, "JimakuBG");
            ActorBGMBin = CreateMediaBinKL(helper, "ActorBG");
        }

        private KeyListInfo CreateAudioTrackKL(VegasHelper helper, string namePrefix)
        {
            return KeyListInfo.Instance(helper, AudioTKV, namePrefix + "TrackName");
        }

        private KeyListInfo CreateVideoTrackKL(VegasHelper helper, string namePrefix)
        {
            return KeyListInfo.Instance(helper, VideoTKV, namePrefix + "TrackName");
        }

        private KeyListInfo CreatePluginKL(VegasHelper helper, string namePrefix)
        {
            return new KeyListInfo(helper, helper.PlugInNode.GetTitlePresetNames(), namePrefix + "PresetName");
        }

        private KeyListInfo CreateMediaKL(VegasHelper helper, string namePrefix)
        {
            return KeyListInfo.Instance(helper, MKV, namePrefix + "MediaName");
        }

        private KeyListInfo CreateMediaBinKL(VegasHelper helper, string namePrefix)
        {
            return KeyListInfo.Instance(helper, MbKV, namePrefix + "MediaBinName");
        }
    }
}
