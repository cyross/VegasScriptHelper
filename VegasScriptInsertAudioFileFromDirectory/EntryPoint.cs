﻿using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasInsertAudioFileFromDirectory
{
    public class EntryPoint: IEntryPoint
    {
        private Setting settingDialog = null;

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
                settingDialog = new Setting();
            }

            settingDialog.AudioFileFolder = VegasScriptSettings.OpenDirectory;
            settingDialog.AudioInterval = VegasScriptSettings.AudioInsertInterval;
            settingDialog.IsRecursive = VegasScriptSettings.IsRecursive;
            settingDialog.StartFrom = VegasScriptSettings.StartFrom;
            settingDialog.MediaBinName = VegasScriptSettings.DefaultBinName["voiroVoice"];
            settingDialog.TrackNameDataSource = keyList;
            settingDialog.TrackName = selectedAudioTrack != null ? helper.GetTrackKey(selectedAudioTrack) : keyList.First();

            if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

            string selectedPath = settingDialog.AudioFileFolder;
            float interval = settingDialog.AudioInterval;
            bool isRecursive = settingDialog.IsRecursive;
            bool startFrom = settingDialog.StartFrom;

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
                        startFrom,
                        isRecursive,
                        settingDialog.UseMediaBin,
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

            VegasScriptSettings.OpenDirectory = selectedPath;
            VegasScriptSettings.AudioInsertInterval = interval;
            VegasScriptSettings.IsRecursive = isRecursive;
            VegasScriptSettings.StartFrom = startFrom;
            VegasScriptSettings.Save();
        }
    }
}
