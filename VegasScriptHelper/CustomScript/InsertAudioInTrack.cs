using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public struct InsertAudioInfo
    {
        public TrackInfo<AudioTrack> Track;
        public string Folder;
        public float Interval;
        public bool IsRecursive;
        public bool IsInsertFromStartPosition;
        public MediaBinInfo MediaBin;
    }

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

            if (audioTrack is null)
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

            InsertAudio(currentPosition, intervalTimecode, fileDir, audioTrack, recursive, mediaBin);
        }

        public int CountAudioFiles(in InsertAudioInfo info, int current = 0)
        {
            return CountAudioFiles(info.Folder, info.IsRecursive, current);
        }

        public int CountAudioFiles(string audioFileDir, bool recursive, int current = 0)
        {
            if (recursive)
            {
                foreach (string childDir in Directory.GetDirectories(audioFileDir))
                {
                    current = CountAudioFiles(childDir, recursive, current);
                }
            }

            foreach (string filePath in Directory.GetFiles(audioFileDir))
            {
                if (_settings.SupportedAudioFile.Contains(Path.GetExtension(filePath)))
                {
                    current++;
                }
            }
            return current;
        }

        public void InseretAudioInTrack(ref InsertAudioInfo info)
        {
            info.Track.Track.Selected = true;

            Timecode currentPosition = info.IsInsertFromStartPosition ? new Timecode() : Vegas.Cursor;
            Timecode intervalTimecode = new Timecode(info.Interval);

            InsertAudio(currentPosition, intervalTimecode, info.Folder, info.Track.Track, info.IsRecursive, info.MediaBin.Bin);
        }

        public void InseretAudioInTrack(
            string audioFileDir,
            AudioTrack audioTrack,
            float interval = 0.0f,
            bool fromStart = false,
            bool recursive = true,
            MediaBin mediaBin = null)
        {
            audioTrack.Selected = true;

            Timecode currentPosition = fromStart ? new Timecode() : Vegas.Cursor;
            Timecode intervalTimecode = new Timecode(interval);

            InsertAudio(currentPosition, intervalTimecode, audioFileDir, audioTrack, recursive, mediaBin);
        }

        private Timecode InsertAudio(Timecode current, Timecode interval, string audioFileDir, AudioTrack audioTrack, bool recursive, MediaBin mediaBin = null)
        {
            if (recursive)
            {
                foreach (string childDir in Directory.GetDirectories(audioFileDir))
                {
                    current = InsertAudio(current, interval, childDir, audioTrack, recursive, mediaBin);
                }
            }

            foreach (string filePath in Directory.GetFiles(audioFileDir))
            {
                if (_settings.SupportedAudioFile.Contains(Path.GetExtension(filePath)))
                {
                    Media audioMedia = CreateMedia(filePath, mediaBin);

                    AudioEvent audioEvent = CreateAudioEvent(audioTrack, audioMedia, current);

                    current += audioEvent.Length + interval;
                }
            }
            return current;
        }
    }
}
