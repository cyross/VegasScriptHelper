using System.Windows.Forms;
using VegasScriptHelper;

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
                SelectedPath = helper.Settings[SN.WdAudio.File.Folder]
            };
            float interval = helper.Settings[SN.WdAudio.Insert.Interval];
            bool isRecursive = helper.Settings[SN.WdAudio.Is.Folder.Recursive];
            bool isInsertStartPosition = helper.Settings[SN.WdAudio.Is.Insert.Standard.Position];
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowser.SelectedPath;
                helper.InseretAudioInTrack(selectedPath, interval, isInsertStartPosition, isRecursive);

                helper.Settings[SN.WdAudio.File.Folder] = selectedPath;
                helper.Settings[SN.WdAudio.Insert.Interval] = interval;
                helper.Settings[SN.WdAudio.Is.Folder.Recursive] = isRecursive;
                helper.Settings[SN.WdAudio.Is.Insert.Standard.Position] = isInsertStartPosition;
                helper.Settings.Save();
            }
        }
    }
}
