using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.ExtProc.Audio;
using VegasScriptHelper.Settings;

namespace VegasScriptDebug.DebugProcess
{
    /// <summary>
    /// フォルダ選択ダイアログを開き、選択したフォルダの全wavファイルを新規オーディオトラックに貼り付ける
    /// 貼り付け開始は現在のタイムルーラーの位置から。
    /// </summary>
    /// <param name="helper">VegasHelperオブジェクト</param>
    internal class InsertWaveFileInNewAudioTrack : IDebugProcess
    {
        private readonly VegasHelper helper;

        public InsertWaveFileInNewAudioTrack(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog
            {
                SelectedPath = helper.Config[Names.WdAudio.File.Folder]
            };
            float interval = helper.Config[Names.WdAudio.Insert.Interval];
            bool isRecursive = helper.Config[Names.WdAudio.Is.Folder.Recursive];
            bool isInsertStartPosition = helper.Config[Names.WdAudio.Is.Insert.Standard.Position];
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowser.SelectedPath;
                Insereter inserter = new Insereter(helper);

                inserter.Exec(selectedPath, interval, isInsertStartPosition, isRecursive);

                helper.Config[Names.WdAudio.File.Folder] = selectedPath;
                helper.Config[Names.WdAudio.Insert.Interval] = interval;
                helper.Config[Names.WdAudio.Is.Folder.Recursive] = isRecursive;
                helper.Config[Names.WdAudio.Is.Insert.Standard.Position] = isInsertStartPosition;
                helper.Config.Save();
            }
        }
    }
}
