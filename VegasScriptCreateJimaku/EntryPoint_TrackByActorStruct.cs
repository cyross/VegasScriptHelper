using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VegasScriptCreateJimaku.EntryPoint;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public struct TrackByActorStruct
    {
        public static readonly string[] TachieTypePostfixs = new string[] { "前", "字幕後ろ", "後ろ" };

        public string Name;
        public AudioTrack Audio;
        public VideoTrack Jimaku;
        public VideoTrack Actor;
        public VideoTrack JimakuBG;
        public VideoTrack ActorBG;
        public Dictionary<string, VideoTrack> Tachie;

        public void CreateAudioTrack(VegasHelper helper, in InsertAudioInfo info, ref List<Track> groupTracks)
        {
            Audio = helper.CreateAudioTrack(GetTrackName(info.Track.Name));
            groupTracks.Add(Audio);
        }

        public void CreateJimakuTrack(VegasHelper helper, in JimakuParams info, ref List<Track> groupTracks)
        {
            Jimaku = helper.CreateVideoTrack(GetTrackName(info.Jimaku.Track.Name));
            groupTracks.Add(Jimaku);
        }

        public void CreateActorTrack(VegasHelper helper, in JimakuParams info, ref List<Track> groupTracks)
        {
            if (!info.IsCreateActorTrack) { return; }

            Actor = helper.CreateVideoTrack(GetTrackName(info.Actor.Track.Name));
            groupTracks.Add(Actor);
        }

        public void CreateTachieTrack(VegasHelper helper, TachieType type, in BasicTrackStruct<VideoTrack> track, ref List<Track> groupTracks)
        {
            if (!track.IsCreate) { return; }

            string tachieType = TachieTypePostfixs[(int)type];
            Tachie[tachieType] = helper.CreateVideoTrack(GetTrackName(string.Format("{0}_{1}", track.Info.Name, tachieType)));
            groupTracks.Add(Tachie[tachieType]);
        }

        public void CreateJimakuBGTrack(VegasHelper helper, in BackgroundInfo info, ref List<Track> groupTracks)
        {
            if (!info.IsCreate) { return; }

            JimakuBG = helper.CreateVideoTrack(GetTrackName(info.Track.Name));
            groupTracks.Add(JimakuBG);
        }

        public void CreateActorBGTrack(VegasHelper helper, in BackgroundInfo info, ref List<Track> groupTracks)
        {
            if (!info.IsCreate) { return; }

            ActorBG = helper.CreateVideoTrack(GetTrackName(info.Track.Name));
            groupTracks.Add(ActorBG);
        }

        public string GetTrackName(string orgTrackName)
        {
            return Name == "" ? orgTrackName : string.Format("{0}_{1}", orgTrackName, Name);
        }

        public string GetTrackName(string orgTrackName, TachieType type)
        {
            return Name == "" ? orgTrackName : string.Format("{0}_{1}_{2}", orgTrackName, TachieTypePostfixs[(int)type], Name);
        }
    }
}
