using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptDebug.DebugProcess
{
    internal class GenerateMedia: IDebugProcess
    {
        private VegasHelper helper;

        public GenerateMedia(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            try
            {
                // テキスト生成プラグインを取得
                PlugInNode node = helper.GetTitlePluginNode();
                Debug.WriteLine("[PRESET]");
                List<string> presetNames = helper.GetPluginPresetNames(node);
                foreach (string presetName in presetNames)
                {
                    Debug.WriteLine(string.Format("NAME={0}", presetName));
                }
                Debug.WriteLine("[VIDEO MEDIA]");
                Dictionary<string, Media> videoMediaDict = helper.GetProjectVideoMediaKeyValuePairs();
                foreach (string mediaKey in videoMediaDict.Keys)
                {
                    Debug.WriteLine(string.Format("NAME={0}", mediaKey));
                }
                Debug.WriteLine("[AUDIO MEDIA]");
                Dictionary<string, Media> audioMediaDict = helper.GetProjectAudioMediaKeyValuePairs();
                foreach (string mediaKey in audioMediaDict.Keys)
                {
                    Debug.WriteLine(string.Format("NAME={0}", mediaKey));
                }
            }
            catch (FileNotFoundException ex)
            {
                string execDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
                MessageBox.Show(
                    string.Format(
                        "{0}\r\n以下の場所にファイルを置いてください。\r\n{1}",
                        ex.Message,
                        execDir
                    ));
            }
        }
    }
}
