using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptInsertAudioFileFromDirectory
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            AudioTrack selectedAudioTrack = null;
            try
            {
                selectedAudioTrack = helper.SelectedAudioTrack();
            }
            catch (VegasHelperTrackUnselectedException)
            {
                selectedAudioTrack = null;
            }

            List<AudioTrack> audioTracks = helper.AllAudioTracks.ToList();

            Dictionary<string, AudioTrack> keyValuePairs = new Dictionary<string, AudioTrack>(); ;

            foreach (AudioTrack audioTrack in audioTracks)
            {
                keyValuePairs[helper.GetTrackKey(audioTrack)] = audioTrack;
            }
            List<string> keyList = keyValuePairs.Keys.ToList();

            if(settingDialog == null)
            {
                settingDialog = new SettingDialog();
            }

            settingDialog.AudioFileFolder = helper.Settings["AudioFileFolder"];
            settingDialog.AudioInterval = helper.Settings["AudioInsertInterval"];
            settingDialog.IsRecursive = helper.Settings["IsAudioFolderRecursive"];
            settingDialog.StartFrom = helper.Settings["IsInsertStartPosition"];
            settingDialog.UseMediaBin = helper.Settings["UseAudioMediaBin"];
            settingDialog.MediaBinName = helper.Settings["AudioMediaBinName"];
            settingDialog.TrackNameDataSource = keyList;
            settingDialog.TrackName = selectedAudioTrack != null ? helper.GetTrackKey(selectedAudioTrack) : keyList.Count == 0 ? "" : keyList.First();

            if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

            string selectedPath = settingDialog.AudioFileFolder;
            float interval = settingDialog.AudioInterval;
            bool isAudioFolderRecursive = settingDialog.IsRecursive;
            bool isInsertStartPosition = settingDialog.StartFrom;
            bool useMediaBin = settingDialog.UseMediaBin;

            AudioTrack targetAudioTrack = null;
            if(keyValuePairs.ContainsKey(settingDialog.TrackName))
            {
                targetAudioTrack = keyValuePairs[settingDialog.TrackName];
            }

            try
            {
                using (new UndoBlock("オーディオトラックに音声ファイルを流し込み"))
                {
                    helper.InseretAudioInTrack(
                        selectedPath,
                        interval,
                        isInsertStartPosition,
                        isAudioFolderRecursive,
                        useMediaBin,
                        settingDialog.MediaBinName,
                        targetAudioTrack,
                        settingDialog.TrackName
                        );
                }
            }
            catch (Exception ex)
            {
                string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                Debug.WriteLine("---[Exception In Helper]---");
                Debug.WriteLine(errMessage);
                Debug.WriteLine("---------------------------");
                MessageBox.Show(
                    errMessage,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw ex;
            }

            helper.Settings["AudioFileFolder"] = selectedPath;
            helper.Settings["AudioInsertInterval"] = interval;
            helper.Settings["IsAudioFolderRecursive"] = isAudioFolderRecursive;
            helper.Settings["IsInsertStartPosition"] = isInsertStartPosition;
            helper.Settings["UseAudioMediaBin"] = useMediaBin;
            if (useMediaBin) { helper.Settings["AudioMediaBinName"] = settingDialog.MediaBinName; }
            helper.Settings.Save();
        }
    }
}
