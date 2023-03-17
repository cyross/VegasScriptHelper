using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public class VHPlugInNode
    {
        internal static readonly string PNTitleName = "{Svfx:com.vegascreativesoftware:titlesandtext}";
        internal static readonly string PNSolidColorName = "{Svfx:com.vegascreativesoftware:solidcolor}";

        private VegasHelper myHelper;

        public VHPlugInNode(VegasHelper helper)
        {
            myHelper = helper;
        }

        public PlugInNode GetTitle()
        {
            return Get(PNTitleName);
        }

        public PlugInNode GetSolidColor()
        {
            return Get(PNSolidColorName);
        }

        private PlugInNode Get(string name)
        {
            return myHelper.Gen.GetChild(name);
        }

        public List<string> GetTitlePresetNames()
        {
            return GetPresetNames(GetTitle());
        }

        public List<string> GetSolidColorPresetNames()
        {
            return GetPresetNames(GetSolidColor());
        }

        public List<string> GetPresetNames(PlugInNode node)
        {
            return node.Presets.Select(p => p.Name).ToList();
        }
    }
}
