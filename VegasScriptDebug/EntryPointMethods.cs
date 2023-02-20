using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using VegasScriptHelper;

namespace VegasScriptDebug
{
    public partial class EntryPoint
    {
        /// <summary>
        /// フォルダ選択ダイアログを開き、選択したフォルダの全wavファイルを新規オーディオファイルに貼り付ける
        /// 貼り付け開始は現在のタイムルーラーの位置から。
        /// </summary>
        /// <param name="helper">VegasHelperオブジェクト</param>
        private void InsertWaveFileInNewAudioTrack(VegasHelper helper)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog
            {
                SelectedPath = VegasScriptSettings.OpenDirectory
            };
            float interval = VegasScriptSettings.AudioInsertInterval;
            bool isRecursive = VegasScriptSettings.IsRecursive;
            bool startFrom = VegasScriptSettings.StartFrom;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowser.SelectedPath;
                helper.InseretAudioInTrack(selectedPath, interval, startFrom, isRecursive);

                VegasScriptSettings.OpenDirectory = selectedPath;
                VegasScriptSettings.AudioInsertInterval = interval;
                VegasScriptSettings.IsRecursive = isRecursive;
                VegasScriptSettings.StartFrom = startFrom;
                VegasScriptSettings.Save();
            }
        }

        private void ApplyTextColorByActor(VegasHelper helper)
        {
            try
            {
                TrackEvents events = helper.GetVideoEvents();
                helper.ApplyTextColorByActor(events, 4.0, true);
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }

        private void AssignAudioTrackDurationToVideoTrack(VegasHelper helper)
        {
            try
            {
                helper.AssignAudioTrackDurationToVideoTrack(VegasScriptSettings.TargetAssignTrackName, VegasScriptSettings.AssignEventMargin);
            }
            catch (VegasHelperNotFoundTrackException)
            {
                MessageBox.Show("所定の名前のトラックが見つかりません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("所定のトラック中にイベントが存在していません。");
            }
        }

        private void AssignSelectedAudioTrackDurationToSelectedVideoTrack(VegasHelper helper)
        {
            try
            {
                helper.AssignAudioTrackDurationToVideoTrack(VegasScriptSettings.AssignEventMargin);
            }
            catch (VegasHelperNotFoundTrackException)
            {
                MessageBox.Show("所定の名前のトラックが見つかりません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("所定のトラック中にイベントが存在していません。");
            }
        }

        private void DeleteJimakuPrefix(VegasHelper helper)
        {
            try
            {
                helper.DeleteJimakuPrefix();
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }

        private void ShowTrackLength(VegasHelper helper)
        {
            try
            {
                Timecode time = helper.GetLengthFromAllEventsInTrack();
                string result = string.Format("長さ: {0}", time.ToString());
                MessageBox.Show(result);
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }

        private void ExpandFirstVideoEvent(VegasHelper helper)
        {
            double margin = VegasScriptSettings.ExpandVideoEventMargin;
            try
            {
                helper.ExpandFirstVideoEvent(margin);
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }

        private void DebugYAMLAccess(VegasHelper helper)
        {
            VegasScriptSettings.LoadYamlFile();
        }

        private void DebugGenerateMedia(VegasHelper helper)
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
            Dictionary<string, Media> videoMediaDict = helper.GetProjectVideoMediaDict();
            foreach (string mediaKey in videoMediaDict.Keys)
            {
                Debug.WriteLine(string.Format("NAME={0}", mediaKey));
            }
            Debug.WriteLine("[AUDIO MEDIA]");
            Dictionary<string, Media> audioMediaDict = helper.GetProjectAudioMediaDict();
            foreach (string mediaKey in audioMediaDict.Keys)
            {
                Debug.WriteLine(string.Format("NAME={0}", mediaKey));
            }
        }
    }
}
