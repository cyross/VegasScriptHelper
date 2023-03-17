using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper.ExtProc.Jimaku
{
    /// <summary>
    /// 文字列の禁則処理
    /// </summary>
    public class Hyphenazer : BaseProc.BaseExtProc
    {
        private EoS eos;

        public Hyphenazer(VegasHelper helper) : base(helper) {
            eos = new EoS(helper);
        }

        public string Exec(string org_line, int length)
        {
            if (org_line.Length < length)
            {
                return org_line;
            }

            List<string> new_lines = new List<string>();

            while (org_line.Length >= length)
            {
                if (org_line.Length == length && eos.Is(org_line.Last()))
                {
                    new_lines.Add(org_line);
                    break;
                }

                // 文末文字が続いている場合もあるため文末位置が移動する
                int p = eos.Pos(org_line, length);

                if (p == org_line.Length)
                {
                    new_lines.Add(org_line);
                    return string.Join("\n", new_lines);
                }

                new_lines.Add(org_line.Substring(0, p));
                org_line = org_line.Substring(p);
            }

            if (org_line.Length != 0) { new_lines.Add(org_line); }

            return string.Join("\n", new_lines);
        }
    }
}
