using System;
using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptDebug
{
    public partial class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            //InsertWaveFileInNewAudioTrack(helper);
            //ApplyTextColorByActor(helper);
            //AssignAudioTrackDurationToVideoTrack(helper);
            //AssignSelectedAudioTrackDurationToSelectedVideoTrack(helper);
            //DeleteJimakuPrefix(helper);
            //ShowTrackLength(helper);
            //ExpandFirstVideoEvent(helper);
            //DebugMediaBin(helper);
            DebugCreateMediaBin(helper);
        }
    }
}
