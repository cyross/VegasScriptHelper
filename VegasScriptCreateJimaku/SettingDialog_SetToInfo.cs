using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        public void SetToFlags(ref Flags flags)
        {
            flags.Behavior = PrefixBehavior;
            flags.IsRemoveActorAttr = IsRemoveActorAttr;
            flags.IsCreateOneEventCheck = IsCreateOneEventCheck;
            flags.IsCollapseTrackGroup = IsCollapseTrackGroupCheck;
            flags.IsDivideTracks = DivideTracks;
        }

        public void SetToTachieInfo(ref BasicTrackStruct<VideoTrack> tachieTrack)
        {
            tachieTrack.IsCreate = IsTachieCheck;
            tachieTrack.Info.Name = TachieTrackName;
        }

        public void SetToBGInfo(ref BasicTrackStruct<VideoTrack> bgTrack)
        {
            bgTrack.IsCreate = IsBGCheck;
            bgTrack.Info.Name = BGTrackName;
        }

        public void SetToFGInfo(ref BasicTrackStruct<VideoTrack> fgTrack)
        {
            fgTrack.IsCreate = IsFGCheck;
            fgTrack.Info.Name = FGTrackName;
        }

        public void SetToBGMInfo(ref BasicTrackStruct<AudioTrack> bgmTrack)
        {
            bgmTrack.IsCreate = IsBGMCheck;
            bgmTrack.Info.Name = BGMTrackName;
        }

        public void SetToBasicTrackStructs(ref BasicTrackStructs structs)
        {
            SetToTachieInfo(ref structs.Tachie);
            SetToBGInfo(ref structs.BG);
            SetToFGInfo(ref structs.FG);
            SetToBGMInfo(ref structs.BGM);
        }
        public void SetToHypheInfo(ref HypheInfo info)
        {
            info.IsUse = UseHypheCheck;
            info.Length = HypheLength;
        }
    }
}
