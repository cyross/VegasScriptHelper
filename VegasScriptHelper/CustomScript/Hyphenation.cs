using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    /// <summary>
    /// 文字列の禁則処理
    /// </summary>
    public partial class VegasHelper
    {
        private readonly char[] EOSChrs = new char[] { '、', '。', '，', '．', ',', '.', '?', '？', '!', '！' };

        public string Hyphenation(string text)
        {
            int length = Settings[SettingName.WdHyphe.Width];

            if (text.Length < length)
            {
                return text;
            }

            List<string> lines = new List<string>();

            while (text.Length >= length)
            {
                if (text.Length == length && IsEoS(text.Last()))
                {
                    lines.Add(text);
                    break;
                }

                int p = length;

                // 文末文字が続いている場合もあるため
                while (IsEoS(text[p]) && p < text.Length) { p++; }

                lines.Add(text.Substring(0, p));

                text = text.Substring(p);
            }

            return string.Join("\n", lines);
        }

        private bool IsEoS(char chr)
        {
            return EOSChrs.Contains(chr);
        }

        private int NextLinePos(string text, int length)
        {
            return 0;
        }
    }
}
