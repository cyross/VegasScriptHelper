using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public class VHGen
    {
        private Vegas myVegas;

        public VHGen(Vegas vegas)
        {
            myVegas = vegas;
        }

        public PlugInNode GetChild(string uniqueID)
        {
            return myVegas.Generators.GetChildByUniqueID(uniqueID);
        }
    }
}
