namespace VegasScriptHelper.ExtProc.Jimaku
{
    public class GetPrefix : BaseProc.BaseExtProc
    {
        private PrefixPos prefixPos;
        private DelPrefix delPrefix;

        public GetPrefix(VegasHelper helper) : base(helper) {
            prefixPos = new PrefixPos(helper);
            delPrefix = new DelPrefix(helper);
        }

        public string Get(bool withCut = true)
        {
            int pos = prefixPos.Get();
            string actor_name = Get(pos);

            if (actor_name != "" && withCut)
            {
                delPrefix.Exec(pos);
            }

            return actor_name;
        }

        public string Get(int pos)
        {
            if (pos == -1) { return ""; }

            return myHelper.Rtf.Text.Substring(0, pos);
        }
    }
}
