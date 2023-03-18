using Markdig;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VegasScriptHelper
{
    public partial class TipsViewForm : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public TipsViewForm()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VHUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;

        }

        public Panel MainPanel { get { return mainPanel; } }

        public void LoadTips()
        {
            var markdownSource = LoadMarkdownSource();

            var pipeline = new MarkdownPipelineBuilder().UseGridTables().UseEmphasisExtras().UseEmojiAndSmiley().Build();
            string rawhtml = Markdown.ToHtml(markdownSource, pipeline);

            // 現状のMarkdigでの出力ではHTMLのヘッダがないため、WebBrowseで表示しようとすると文字化けする
            // そのため、ヘッダを明示的に取り付ける
            var html = rawhtml.ToUpper().IndexOf("<!DOCTYPE HTML>") == -1 ? FormatHTML(rawhtml) : rawhtml;

            // ブラウザで表示するためにテンポラリHTMLファイルを作る
            string tmpFilePath = Path.GetTempFileName() + ".html";
            SaveToMarkdownHTMLFile(tmpFilePath, html);

            markDownBrowser.Navigate(string.Format("file://{0}", tmpFilePath));
        }

        private string LoadMarkdownSource()
        {
            string execFilePath = VHUtility.GetExecFilepath("Tips.md");

            try
            {
                using (var markdownFile = new StreamReader(execFilePath))
                {
                    return markdownFile.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine("[ERROR]FILE NOT FOUND: filepath");
                Debug.WriteLine("CurrentPath = " + execFilePath);
                throw ex;
            }
        }

        private string FormatHTML(string source)
        {
            string[] htmls = new string[] {
                "<!DOCTYPE html>",
                "<html lang=\"ja\">",
                "    <head>",
                "        <meta charset=\"utf-8\">",
                "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">",
                "    </head>",
                "    <body>",
                source,
                "    </body>",
                "</html>"
            };

            return string.Join("\r\n", htmls);
        }

        private void SaveToMarkdownHTMLFile(string filepath, string html)
        {
            using (var markdownFile = new StreamWriter(filepath))
            {
                markdownFile.Write(html);
            }
        }
    }
}
