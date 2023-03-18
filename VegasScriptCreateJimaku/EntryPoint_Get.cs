using ScriptPortal.Vegas;
using System.Collections.Generic;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        public VideoTrack GetVideoTrack(VegasHelper helper, string name, Dictionary<string, VideoTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.Project.AddVideoTrack(name);
        }

        public AudioTrack GetAudioTrack(VegasHelper helper, string name, Dictionary<string, AudioTrack> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.Project.AddAudioTrack(name);
        }

        public MediaBin GetMediaBin(VegasHelper helper, string name, Dictionary<string, MediaBin> kvPairs)
        {
            return kvPairs.ContainsKey(name) ? kvPairs[name] : helper.MediaBin.Create(name, false);
        }
    }
}
