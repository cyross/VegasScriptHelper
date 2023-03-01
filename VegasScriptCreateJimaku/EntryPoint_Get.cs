using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        public VideoTrack GetVideoTrack(VegasHelper helper, string name, Dictionary<string, VideoTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateVideoTrack(name);
        }

        public AudioTrack GetAudioTrack(VegasHelper helper, string name, Dictionary<string, AudioTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateAudioTrack(name);
        }

        public MediaBin GetMediaBin(VegasHelper helper, string name, Dictionary<string, MediaBin> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.CreateMediaBin(name, false);
        }
    }
}
