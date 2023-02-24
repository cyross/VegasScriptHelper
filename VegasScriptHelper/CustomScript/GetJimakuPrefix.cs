using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public int GetJimakuPrefixSeparatorPositionFromRtf(bool throwException = true)
        {
            int pos = rtfBox.RtfBox.Find(":");

            if (pos == -1 && throwException) { throw new VegasHelperNotFoundJimakuPrefixException(); }

            return pos;
        }

        public string GetJimakuPrefixFromRtf()
        {
            int pos = GetJimakuPrefixSeparatorPositionFromRtf();

            return GetJimakuPrefixFromRtf(pos);
        }

        public string GetJimakuPrefixFromRtf(int pos)
        {
            if (pos == -1) { return ""; }

            return rtfBox.RtfText.Substring(0, pos);
        }

        public string GetJimakuPrefixFromRtf(bool withCut = true)
        {
            int pos = GetJimakuPrefixSeparatorPositionFromRtf();
            string actor_name = GetJimakuPrefixFromRtf(pos);

            if (actor_name != "" && withCut)
            {
                DeleteJimakuPrefixFromRtf(pos);
            }

            return actor_name;
        }
    }
}
