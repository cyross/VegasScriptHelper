using System.Linq;

namespace VegasScriptHelper.ExtProc.Jimaku
{
    public class EoS : BaseProc.BaseExtProc
    {
        private readonly char[] EOSChrs = new char[] { '、', '。', '，', '．', ',', '.', '?', '？', '!', '！' };

        public EoS(VegasHelper helper) : base(helper) { }

        public int Pos(string line, int pos)
        {
            while (pos < line.Length && Is(line[pos])) { pos++; }

            return pos;
        }

        public bool Is(char chr)
        {
            return EOSChrs.Contains(chr);
        }
    }
}
