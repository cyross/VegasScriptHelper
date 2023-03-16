using VegasScriptHelper;

namespace PrescribedPattern.MainProc
{
    internal class MainProc : IMainProc
    {
        private readonly VegasHelper helper;

        public MainProc(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
        }
    }
}
