using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper.ExtProc.Jimaku
{
    public class Counter : BaseProc.BaseExtProc
    {
        public Counter(VegasHelper helper) : base(helper) { }

        public int Get(string[] jimakuLines)
        {
            return jimakuLines.Where(l => l.Trim().Length > 0 && l.IndexOf(":") != -1).Count();
        }
    }
}