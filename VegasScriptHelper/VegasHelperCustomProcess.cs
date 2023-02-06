using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        /// <summary>
        /// オーディオトラックを作り、指定したディレクトリ内のwavファイルをイベントとして挿入する
        /// オーディオファイルの検知は拡張子のみで、ファイルの中身はチェックしない
        /// 対応するファイルはVegasScriptSettings.SupportedAudioFileで指定されたもの
        /// </summary>
        /// <param name="fileDir">指定したディレクトリ名</param>
        /// <param name="interval">挿入するイベント間の間隔　単位はミリ秒　標準は0.0</param>
        /// <param name="fromStart">トラックの最初から挿入するかどうかを示すフラグ　trueのときは最初から、falseのときは現在のカーソル位置から</param>
        /// <param name="recursive">子ディレクトリのを再帰的にトラックの最初から挿入するかどうかを示すフラグ　trueのときは最初から、falseのときは現在のカーソル位置から</param>
        public void InseretAudioInTrack(
            string fileDir,
            float interval = 0.0f,
            bool fromStart = false,
            bool recursive = true,
            bool useMediaBin = true,
            string mediaBinName = null,
            AudioTrack targetTrack = null,
            string targetTrackName = "Subtitles")
        {
            AudioTrack audioTrack = targetTrack;

            if (audioTrack == null)
            {
                audioTrack = AddAudioTrack();
                SetTrackTitle(audioTrack, targetTrackName);
                audioTrack.Selected = true;
            }

            MediaBin mediaBin = null;

            if (useMediaBin && mediaBinName != null)
            {
                mediaBin = IsExistMediaBin(mediaBinName) ? GetMediaBin(mediaBinName) : CreateMediaBin(mediaBinName);
            }

            Timecode currentPosition = fromStart ? new Timecode() : Vegas.Cursor;
            Timecode intervalTimecode = new Timecode(interval);

            _InsertAudio(currentPosition, intervalTimecode, fileDir, audioTrack, recursive, mediaBin);
        }

        public Timecode _InsertAudio(Timecode current, Timecode interval, string fileDir, AudioTrack audioTrack, bool recursive, MediaBin mediaBin = null)
        {
            if (recursive)
            {
                foreach (string childDir in Directory.GetDirectories(fileDir))
                {
                    current = _InsertAudio(current, interval, childDir, audioTrack, recursive, mediaBin);
                }
            }
            foreach (string filePath in Directory.GetFiles(fileDir))
            {
                if (VegasScriptSettings.SupportedAudioFile.Contains(Path.GetExtension(filePath)))
                {
                    Media audioMedia = new Media(filePath);

                    if(mediaBin != null)
                    {
                        mediaBin.Add(audioMedia);
                    }

                    AudioStream audioStream = audioMedia.GetAudioStreamByIndex(0);

                    AudioEvent audioEvent = audioTrack.AddAudioEvent(current, audioStream.Length);
                    audioEvent.AddTake(audioStream);

                    current += audioStream.Length + interval;
                }
            }
            return current;
        }

        public void AssignAudioTrackDurationToVideoTrack(VideoTrack videoTrack, AudioTrack audioTrack, double margin = 0.0f, bool adjustTakes = true, bool group = true)
        {
            TrackEvents videoEvents = videoTrack.Events;
            TrackEvents audioEvents = audioTrack.Events;

            if (videoEvents.Count != audioEvents.Count) { return; }

            // TrackEventsのまま処理をするとリストの内容が勝手に入れ替わって不具合の原因になるため、
            // 別のListを作ってそこにTrackEventを挿入する
            List<TrackEvent> tmpVideoEvents = VegasHelperUtility.RefillTrackEvents(videoEvents);
            List<TrackEvent> tmpAudioEvents = VegasHelperUtility.RefillTrackEvents(audioEvents);

            for (int i = 0; i < videoEvents.Count; i++)
            {
                VegasDuration duration = GetEventTime(audioEvents[i]);
                SetEventTime(tmpVideoEvents[i], duration, margin, adjustTakes);

                if (group) { AddTrackEventGroup(tmpAudioEvents[i], tmpVideoEvents[i]); }
            }
        }

        public void AssignAudioTrackDurationToVideoTrack(string trackName, double margin = 0, bool adjustTakes = true, bool group = true)
        {
            VideoTrack videoTrack = SearchVideoTrackByName(trackName);
            AudioTrack audioTrack = SearchAudioTrackByName(trackName);
            AssignAudioTrackDurationToVideoTrack(videoTrack, audioTrack, margin, adjustTakes, group);
        }

        public void AssignAudioTrackDurationToVideoTrack(double margin = 0, bool adjustTakes = true, bool group = true)
        {
            VideoTrack videoTrack = SelectedVideoTrack();
            AudioTrack audioTrack = SelectedAudioTrack();
            AssignAudioTrackDurationToVideoTrack(videoTrack, audioTrack, margin, adjustTakes, group);
        }

        public void DeleteJimakuPrefix()
        {
            VideoTrack track = SelectedVideoTrack();
            DeleteJimakuPrefix(track);
        }
        public void DeleteJimakuPrefix(string title)
        {
            VideoTrack track = SearchVideoTrackByName(title);
            DeleteJimakuPrefix(track);
        }

        public void DeleteJimakuPrefix(VideoTrack track)
        {
            DeleteJimakuPrefix(track.Events);
        }

        public void DeleteJimakuPrefix(TrackEvents trackEvents)
        {
            foreach (TrackEvent trackEvent in trackEvents)
            {
                DeleteJimakuPrefix(trackEvent);
            }
        }

        /// <summary>
        /// 選択したトラック内のイベントの開始位置と流さを求める。
        /// 最初のイベントの開始位置から最後のイベントの終点までをその長さとする。
        /// また、引数としてマージンもセット可能
        /// </summary>
        /// <param name="margin">設定するマージン。初期値は0.0</param>
        /// <returns></returns>
        public VegasDuration GetDuretionFromAllEventsInTrack(double margin = 0.0f)
        {
            Track selected = SelectedTrack();
            return GetDuretionFromAllEventsInTrack(selected, margin);
        }

        public VegasDuration GetDuretionFromAllEventsInTrack(Track track, double margin = 0.0f)
        {
            TrackEvents events = GetEvents(track);
            return GetDuretionFromAllEventsInTrack(events);
        }

        public VegasDuration GetDuretionFromAllEventsInTrack(TrackEvents events, double margin = 0.0f)
        {
            TrackEvent firstEvent = GetFirstEvent(events);
            TrackEvent lastEvent = GetLastEvent(events);

            Timecode singleMaraginTimecode = new Timecode(margin);
            Timecode doubleMaraginTimecode = new Timecode(margin * 2);

            VegasDuration duration = new VegasDuration()
            {
                StartTime = firstEvent.Start - singleMaraginTimecode,
                Length = lastEvent.Start + lastEvent.Length - firstEvent.Start + doubleMaraginTimecode
            };
            return duration;
        }

        public Timecode GetLengthFromAllEventsInTrack()
        {
            Track selected = SelectedTrack();

            return GetLengthFromAllEventsInTrack(selected);
        }

        public Timecode GetLengthFromAllEventsInTrack(Track track)
        {
            VegasDuration duration = GetDuretionFromAllEventsInTrack(track);

            return duration.Length;
        }

        public void ExpandFirstVideoEvent(double margin = 0.0)
        {
            TrackEvents videoEvents = GetVideoEvents();
            TrackEvents audioEvents = GetAudioEvents();
            ExpandFirstVideoEvent(videoEvents, audioEvents, margin);
        }
        public void ExpandFirstVideoEvent(VideoTrack videoTrack, AudioTrack audioTrack, double margin = 0.0)
        {
            ExpandFirstVideoEvent(GetVideoEvents(videoTrack), GetAudioEvents(audioTrack), margin);
        }

        public void ExpandFirstVideoEvent(TrackEvents videoEvents, TrackEvents audioEvents, double margin = 0.0)
        {
            VegasDuration duration = GetDuretionFromAllEventsInTrack(audioEvents, margin);
            SetEventTime(GetFirstEvent(videoEvents), duration);
        }

        public void SetTextParameterInTrack(VideoTrack track, Color textColor, Color outlineColor, double outlineWidth)
        {
            TrackEvents events = GetEvents(track);

            foreach (TrackEvent e in events)
            {
                foreach (Take take in GetTakes(e))
                {
                    Media media = take.Media;

                    if(media == null) { continue; }

                    OFXStringParameter ofxStringParam = GetOFXStringParameter(media);
                    if (ofxStringParam is null) { continue; }

                    OFXRGBAParameter ofxTextRGBAParam = GetTextRGBAParameter(media);
                    if (ofxTextRGBAParam is null) { continue; }

                    OFXDoubleParameter ofxOutlineWidthParam = GetOutlineWidthParameter(media);
                    if (ofxOutlineWidthParam is null) { continue; }

                    OFXRGBAParameter ofxOutlineRGBAParam = GetOutlineRGBAParameter(media);
                    if (ofxOutlineRGBAParam is null) { continue; }

                    SetRGBAParameter(ofxTextRGBAParam, textColor);
                    SetRGBAParameter(ofxOutlineRGBAParam, outlineColor);
                    SetDoubleParameter(ofxOutlineWidthParam, outlineWidth);
                }
            }
        }
    }
}
