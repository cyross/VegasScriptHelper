using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private string GetTachiePostscript(TachieType type)
        {
            return TrackByActorStruct.TachieTypePostfixs[(int)type];
        }

        private string GetTachieTrackName(string name, TachieType type)
        {
            return string.Format("{0}_{1}", name, GetTachiePostscript(type));
        }

        private void CreateTachieTrack(VegasHelper helper, ref BasicTrackStruct<VideoTrack> tachieTrack, TachieType type, ref List<Track> groupTracks)
        {
            if (!tachieTrack.IsCreate) { return; }

            string name = GetTachieTrackName(tachieTrack.Info.Name, type);
            tachieTrack.Info.Names.Add(name);
            tachieTrack.Info.Tracks[name] = helper.CreateVideoTrack(name);
            groupTracks.Add(tachieTrack.Info.Tracks[name]);
        }
    }
}
