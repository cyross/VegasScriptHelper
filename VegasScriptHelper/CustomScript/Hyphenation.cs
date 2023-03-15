using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace VegasScriptHelper
{
    /// <summary>
    /// 文字列の禁則処理
    /// </summary>
    public partial class VegasHelper
    {
        private readonly char[] EOSChrs = new char[] { '、', '。', '，', '．', ',', '.', '?', '？', '!', '！' };

        public string[] Hyphenation(string[] org_lines, int length)
        {
            List<string> new_lines = new List<string>();

            foreach(var line in org_lines)
            {
                List<string> hyped = LineHyphenation(line, length);
                new_lines.AddRange(hyped);
            }

            return new_lines.ToArray();
        }

        private List<string> LineHyphenation(string org_line, int length)
        {
            if (org_line.Length < length)
            {
                return new List<string> { org_line };
            }

            List<string> new_lines = new List<string>();

            while (org_line.Length >= length)
            {
                if (org_line.Length == length && IsEoS(org_line.Last()))
                {
                    new_lines.Add(org_line);
                    break;
                }

                // 文末文字が続いている場合もあるため文末位置が移動する
                int p = CountEosPos(org_line, length);

                if (p == org_line.Length)
                {
                    new_lines.Add(org_line);
                    return new_lines;
                }

                new_lines.Add(org_line.Substring(0, p));
                org_line = org_line.Substring(p);
            }

            if (org_line.Length != 0) { new_lines.Add(org_line); }

            return new_lines;
        }

        private int CountEosPos(string line, int pos)
        {
            while (pos < line.Length && IsEoS(line[pos])) { pos++; }

            return pos;
        }

        private bool IsEoS(char chr)
        {
            return EOSChrs.Contains(chr);
        }
    }
}
