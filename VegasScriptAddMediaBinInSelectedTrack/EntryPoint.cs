using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.VegasHelperYamlSpecs;

namespace VegasScriptAddMediaBinInSelectedTrack
{
    public class EntryPoint: IEntryPoint
    {
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            Track track = null;
            TrackEvents trackEvents = null;

            try
            {
                track = helper.Project.SelectedTrack();
                trackEvents = helper.Track.Events(track);
            }
            catch(VHTrackUnselectedException)
            {
                MessageBox.Show("トラックが選択されていません");
                return;
            }
            catch (VHNoneEventsException)
            {
                MessageBox.Show("選択したトラックにイベントがありません。");
                return;
            }

            string binName = helper.Config.DefBinName[DefaultBinName.voiroJimaku];
            List<string> binNameList = helper.MediaBin.GetNameList();

            if(settingDialog == null) { settingDialog = new SettingDialog(); }

            settingDialog.BinName = binName;
            settingDialog.ExistBinNames = binNameList;

            if(settingDialog.ShowDialog() == DialogResult.Cancel ){ return; }

            binName = settingDialog.BinName;

            try
            {
                using (new UndoBlock("対象トラックのメディアをビンに追加"))
                {
                    MediaBin bin = helper.MediaBin.IsExist(binName) ? helper.MediaBin.Get(binName) : helper.MediaBin.Create(binName);

                    foreach (TrackEvent trackEvent in trackEvents)
                    {
                        foreach (Take take in trackEvent.Takes)
                        {
                            bin.Add(take.Media);
                        }
                    }
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
        }
    }
}
