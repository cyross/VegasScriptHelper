namespace VegasScriptHelper
{
    public class VHRtf
    {
        private static readonly RichTextViewForm box = new RichTextViewForm();

        public string Body
        {
            get { return box.Rtf; }
            set { box.Rtf = value; }
        }

        public string Text
        {
            get { return box.RtfText; }
            set { box.RtfText = value; }
        }

        public int Find(string word)
        {
            return box.RtfBox.Find(word);
        }

        public void Update()
        {
            box.RtfBox.Update();
        }
    }
}
