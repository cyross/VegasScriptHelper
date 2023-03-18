using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.Errors;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;

namespace VegasScriptUpdateSpaces
{
    public class EntryPoint: IEntryPoint
    {
        // 選択したトラック・イベント間の間隔を設定
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            using (var block = new UndoBlock("UpdateSpaces"))
            {
                try
                {
                    // ヘルパクラスのオブジェクト生成は必須
                    VegasHelper helper = VegasHelper.Instance(vegas);

                    Track selected = helper.Project.SelectedTrack();

                    TrackEvents events = helper.Track.Events(selected);

                    if(events.Count == 1)
                    {
                        MessageBox.Show("トラックにイベントが一つしかありません");
                        return;
                    }

                    var selectedEvents = events.Where(e => e.Selected).ToList();
                    TrackEvent firstEvent = null;
                    TrackEvent lastEvent = null;

                    if (selectedEvents.Count() == 0) {
                        // 最初のイベントから最後のイベントまで
                        firstEvent = events.First();
                        lastEvent = events.Last();
                    }
                    else if(selectedEvents.Count() == 1) {
                        // 選択したイベント以降
                        firstEvent = selectedEvents[0];
                        lastEvent = events.Last();
                    }
                    else {
                        // 指定したイベント間
                        firstEvent = selectedEvents.First();
                        lastEvent = selectedEvents.Last();
                    }

                    List<TrackEvent> targetEvents = helper.Event.Range(events, firstEvent, lastEvent);
                    TrackEvent prevEvent = lastEvent;
                    List<RemainEventInfo> remainEventInfoList = helper.Event.Remain(events, lastEvent).Select(e =>
                    {
                        RemainEventInfo info = new RemainEventInfo()
                        {
                            trackEvent = e,
                            inrerval = e.Start - (prevEvent.Start + prevEvent.Length)
                        };
                        prevEvent = e;
                        return info;
                    }
                    ).ToList();

                    // 設定ダイアログが不要なときは削除
                    if (settingDialog == null) { settingDialog = new SettingDialog(); }
                    if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                    Timecode interval = new Timecode(settingDialog.Space);

                    Timecode currentTime = targetEvents.First().Start + targetEvents.First().Length;

                    targetEvents.RemoveAt(0); // 最初のイベントは変更不要なので外す

                    // 指定の範囲のイベントの間隔を更新
                    foreach(var currentEvent in targetEvents)
                    {
                        currentTime += interval;
                        currentEvent.Start = currentTime;
                        currentTime += currentEvent.Length;
                    }

                    // 以降のイベントの間隔を更新
                    foreach (var remainEventInfo in remainEventInfoList)
                    {
                        currentTime += remainEventInfo.inrerval;
                        remainEventInfo.trackEvent.Start = currentTime;
                        currentTime += remainEventInfo.trackEvent.Length;
                    }
                }
                catch(VHTrackUnselectedException) {
                    MessageBox.Show("トラックが選択されていません");
                }
                catch(VHNoneEventsException)
                {
                    MessageBox.Show("選択したトラックにイベントが存在していません");
                }
                catch (Exception ex)
                {
                    string errMessage = "[MESSAGE]" + ex.Message + "\n[SOURCE]" + ex.Source + "\n[STACKTRACE]" + ex.StackTrace;
                    Debug.WriteLine("---[Exception In Helper]---");
                    Debug.WriteLine(errMessage);
                    Debug.WriteLine("---------------------------");
                    MessageBox.Show(errMessage);
                    throw ex;
                }
            }
        }
    }
}
