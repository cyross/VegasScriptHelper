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
        public void GetTachieInfo(ref BasicTrackStruct tachieTrack)
        {
            tachieTrack.IsCreate = IsTachieCheck;
            tachieTrack.Info.Name = TachieTrackName;
        }

        public void GetBGInfo(ref BasicTrackStruct bgTrack)
        {
            bgTrack.IsCreate = IsBGCheck;
            bgTrack.Info.Name = BGTrackName;
        }
    }
}
