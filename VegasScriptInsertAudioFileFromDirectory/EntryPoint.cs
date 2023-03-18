using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.ExtProc.Audio;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;

namespace VegasScriptInsertAudioFileFromDirectory
{
    public class EntryPoint: IEntryPoint
    {
        private SettingDialog settingDialog = null;
        private Insereter inserter = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);
            inserter = new Insereter(helper);

            AudioTrack selectedAudioTrack;
            try
            {
                selectedAudioTrack = helper.Project.SelectedAudioTrack();
            }
            catch (VHTrackUnselectedException)
            {
                selectedAudioTrack = null;
            }

            List<AudioTrack> audioTracks = helper.Project.AllAudioTracks.ToList();

            Dictionary<string, AudioTrack> keyValuePairs = new Dictionary<string, AudioTrack>(); ;

            foreach (AudioTrack audioTrack in audioTracks)
            {
                keyValuePairs[helper.Track.GetKey(audioTrack)] = audioTrack;
            }
            List<string> keyList = keyValuePairs.Keys.ToList();

            if(settingDialog == null)
            {
                settingDialog = new SettingDialog();
            }

            settingDialog.AudioFileFolder = helper.Config[Names.WdAudio.File.Folder];
            settingDialog.AudioInterval = helper.Config[Names.WdAudio.Insert.Interval];
            settingDialog.IsRecursive = helper.Config[Names.WdAudio.Is.Folder.Recursive];
            settingDialog.StartFrom = helper.Config[Names.WdAudio.Is.Insert.From.Start.Position];
            settingDialog.UseMediaBin = helper.Config[Names.WdAudio.Use.MediaBin];
            settingDialog.MediaBinName = helper.Config[Names.WdAudio.MediaBin.Name];
            settingDialog.TrackNameDataSource = keyList;
            settingDialog.TrackName = selectedAudioTrack != null ? helper.Track.GetKey(selectedAudioTrack) : keyList.Count == 0 ? "" : keyList.First();

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
                    inserter.Exec(
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

            helper.Config[Names.WdAudio.File.Folder] = selectedPath;
            helper.Config[Names.WdAudio.Insert.Interval] = interval;
            helper.Config[Names.WdAudio.Is.Folder.Recursive] = isAudioFolderRecursive;
            helper.Config[Names.WdAudio.Is.Insert.From.Start.Position] = isInsertStartPosition;
            helper.Config[Names.WdAudio.Use.MediaBin] = useMediaBin;
            if (useMediaBin) { helper.Config[Names.WdAudio.MediaBin.Name] = settingDialog.MediaBinName; }
            helper.Config.Save();
        }
    }
}
