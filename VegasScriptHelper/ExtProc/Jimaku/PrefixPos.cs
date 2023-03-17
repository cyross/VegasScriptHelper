using VegasScriptHelper.Errors;

namespace VegasScriptHelper.ExtProc.Jimaku
{
    public class PrefixPos : BaseProc.BaseExtProc
    {
        public PrefixPos(VegasHelper helper) : base(helper) { }

        public int Get(bool throwException = true)
        {
            int pos = myHelper.Rtf.Find(":");

            if (pos == -1 && throwException) { throw new VHNotFoundJimakuPrefixException(); }

            return pos;
        }

    }
}
