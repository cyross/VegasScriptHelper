﻿using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptAddMediaBinInSelectedTrack
{
    public class EntryPoint: IEntryPoint
    {
        private static BinSettingForm binSettingForm = null;

        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            Track track = null;
            TrackEvents trackEvents = null;

            try
            {
                track = helper.SelectedTrack();
                trackEvents = helper.GetEvents(track);
            }
            catch(VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("トラックが選択されていません");
                return;
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したトラックにイベントがありません。");
                return;
            }

            string binName = VegasScriptSettings.DefaultBinName["voiroJimaku"];
            List<string> binNameList = helper.GetMediaBinNameList();

            if(binSettingForm == null) { binSettingForm = new BinSettingForm(); }

            binSettingForm.BinName = binName;
            binSettingForm.ExistBinNames = binNameList;

            if(binSettingForm.ShowDialog() == DialogResult.Cancel ){ return; }

            binName = binSettingForm.BinName;

            try
            {
                using (new UndoBlock("対象トラックのメディアをビンに追加"))
                {
                    MediaBin bin = helper.IsExistMediaBin(binName) ? helper.GetMediaBin(binName) : helper.CreateMediaBin(binName);

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
