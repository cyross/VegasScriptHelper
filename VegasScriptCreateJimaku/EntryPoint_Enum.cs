using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        public enum TachieType
        {
            Front = 0,
            JimakuBack = 1,
            Back = 2
        }
    }
}
