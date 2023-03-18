using VegasScriptHelper;

namespace VegasScriptDebug.DebugProcess
{
    internal class YAMLAccess: IDebugProcess
    {
        private readonly VegasHelper helper;

        public YAMLAccess(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            helper.Config.LoadYamlFile();
        }
    }
}
