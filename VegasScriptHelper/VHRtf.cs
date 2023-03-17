using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public class VHRtf
    {
        private static readonly RichTextViewForm box = new RichTextViewForm();

        internal string Body
        {
            get { return box.Rtf; }
            set { box.Rtf = value; }
        }

        internal string Text
        {
            get { return box.RtfText; }
            set { box.RtfText = value; }
        }

        internal string[] Lines
        {
            get { return box.RtfLines; }
            set { box.RtfLines = value; }
        }

        internal int Find(string word)
        {
            return box.RtfBox.Find(word);
        }

        internal void Update()
        {
            box.RtfBox.Update();
        }
    }
}
