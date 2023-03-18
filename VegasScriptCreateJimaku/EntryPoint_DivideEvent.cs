using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void DivideTracks(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            ref JimakuParams jimakuParams,
            ref BackgroundInfo jimakuBG,
            ref BackgroundInfo actorBG,
            ref Flags flags,
            ref BasicTrackStruct<VideoTrack> tachieTrack,
            Dictionary<string, List<Track>> trackGroupingKeyValue)
        {
            Dictionary<string, TrackByActorStruct> tracksByActor = new Dictionary<string, TrackByActorStruct>();

            // 振り分けるトラックを作成
            // 立ち絵は作るだけ
            foreach (var actorName in jimakuParams.ActorSets.ToArray())
            {
                List<Track> groupTracks = new List<Track>();

                TrackByActorStruct actorStruct = new TrackByActorStruct()
                {
                    Name = actorName,
                    Tachie = new Dictionary<string, VideoTrack>()
                };

                actorStruct.CreateAudioTrack(helper, audioInfo, ref groupTracks);

                actorStruct.CreateTachieTrack(helper, TachieType.Back, tachieTrack, ref groupTracks);

                if (!flags.IsCreateOneEventCheck)
                {
                    actorStruct.CreateJimakuBGTrack(helper, jimakuBG, ref groupTracks);
                    if (jimakuParams.IsCreateActorTrack) { actorStruct.CreateActorBGTrack(helper, actorBG, ref groupTracks); }
                }

                actorStruct.CreateTachieTrack(helper, TachieType.JimakuBack, tachieTrack, ref groupTracks);

                actorStruct.CreateJimakuTrack(helper, jimakuParams, ref groupTracks);

                if (jimakuParams.IsCreateActorTrack) { actorStruct.CreateActorTrack(helper, jimakuParams, ref groupTracks); }

                actorStruct.CreateTachieTrack(helper, TachieType.Front, tachieTrack, ref groupTracks);

                tracksByActor[actorName] = actorStruct;

                trackGroupingKeyValue[actorName] = groupTracks;
            }

            foreach (string actorName in jimakuParams.ActorLines)
            {
                TrackByActorStruct actorStruct = tracksByActor[actorName];
                List<TrackEvent> trackEvents = new List<TrackEvent>();

                trackEvents.Add(DivideAudioEvent(audioInfo.Track.Track, actorStruct.Audio));

                if (!flags.IsCreateOneEventCheck)
                {
                    if (jimakuBG.IsCreate && jimakuBG.Track.CountEvents() > 0) { trackEvents.Add(DivideVideoEvent(jimakuBG.Track.Track, actorStruct.JimakuBG)); }
                    if (jimakuParams.IsCreateActorTrack && actorBG.IsCreate && actorBG.Track.CountEvents() > 0) { trackEvents.Add(DivideVideoEvent(actorBG.Track.Track, actorStruct.ActorBG)); }
                }

                trackEvents.Add(DivideVideoEvent(jimakuParams.Jimaku.Track.Track, actorStruct.Jimaku));
                if (jimakuParams.IsCreateActorTrack) { trackEvents.Add(DivideVideoEvent(jimakuParams.Actor.Track.Track, actorStruct.Actor)); }

                helper.Project.AddTrackEventGroup(trackEvents.ToArray());
            }
        }

        private AudioEvent DivideAudioEvent(AudioTrack src, AudioTrack dst)
        {
            AudioEvent srcEvent = (AudioEvent)src.Events.First();
            AudioEvent dstEvent = dst.AddAudioEvent(srcEvent.Start, srcEvent.Length);
            dstEvent.Name = srcEvent.Name;
            foreach (var take in srcEvent.Takes)
            {
                dstEvent.AddTake(take.MediaStream);
            }
            src.Events.Remove(srcEvent);
            return dstEvent;
        }

        private VideoEvent DivideVideoEvent(VideoTrack src, VideoTrack dst)
        {
            VideoEvent srcEvent = (VideoEvent)src.Events.First();
            VideoEvent dstEvent = dst.AddVideoEvent(srcEvent.Start, srcEvent.Length);
            dstEvent.Name = srcEvent.Name;
            foreach (var take in srcEvent.Takes)
            {
                dstEvent.AddTake(take.MediaStream);
            }
            src.Events.Remove(srcEvent);
            return dstEvent;
        }
    }
}
