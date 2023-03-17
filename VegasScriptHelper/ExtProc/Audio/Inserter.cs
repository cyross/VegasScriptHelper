using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.IO;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Audio
{
    public class Insereter : BaseProc.BaseExtProc
    {
        public Insereter(VegasHelper helper) : base(helper) { }

        /// <summary>
        /// オーディオトラックを作り、指定したディレクトリ内のwavファイルをイベントとして挿入する
        /// オーディオファイルの検知は拡張子のみで、ファイルの中身はチェックしない
        /// 対応するファイルはVegasScriptSettings.SupportedAudioFileで指定されたもの
        /// </summary>
        /// <param name="fileDir">指定したディレクトリ名</param>
        /// <param name="interval">挿入するイベント間の間隔　単位はミリ秒　標準は0.0</param>
        /// <param name="fromStart">トラックの最初から挿入するかどうかを示すフラグ　trueのときは最初から、falseのときは現在のカーソル位置から</param>
        /// <param name="recursive">子ディレクトリのを再帰的にトラックの最初から挿入するかどうかを示すフラグ　trueのときは最初から、falseのときは現在のカーソル位置から</param>
        public Timecode Exec(
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
                audioTrack = myHelper.Project.AddAudioTrack(targetTrackName);
                audioTrack.Selected = true;
            }

            MediaBin mediaBin = null;

            if (useMediaBin && mediaBinName != null)
            {
                mediaBin = myHelper.MediaBin.IsExist(mediaBinName) ? myHelper.MediaBin.Get(mediaBinName) : myHelper.MediaBin.Create(mediaBinName);
            }

            Timecode currentPosition = fromStart ? new Timecode() : myHelper.Transport.CursolPosition;
            Timecode intervalTimecode = new Timecode(interval);

            return InsertAudio(currentPosition, intervalTimecode, fileDir, audioTrack, recursive, mediaBin);
        }

        public Timecode Exec(ref InsertAudioInfo info)
        {
            info.Track.Track.Selected = true;

            Timecode currentPosition = info.IsInsertFromStartPosition ? new Timecode() : myHelper.Transport.CursolPosition;
            Timecode intervalTimecode = new Timecode(info.Interval);

            return InsertAudio(currentPosition, intervalTimecode, info.Folder, info.Track.Track, info.IsRecursive, info.JimakuLines, info.StandardSilenceTime, info.MediaBin.Bin);
        }

        public Timecode Exec(
            string audioFileDir,
            AudioTrack audioTrack,
            float interval = 0.0f,
            bool fromStart = false,
            bool recursive = true,
            MediaBin mediaBin = null)
        {
            audioTrack.Selected = true;

            Timecode currentPosition = fromStart ? new Timecode() : myHelper.Transport.CursolPosition;
            Timecode intervalTimecode = new Timecode(interval);

            return InsertAudio(currentPosition, intervalTimecode, audioFileDir, audioTrack, recursive, mediaBin);
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
                if (myHelper.Config.AudioFileExts.Contains(Path.GetExtension(filePath)))
                {
                    Media audioMedia = myHelper.Media.Create(filePath, mediaBin);

                    AudioEvent audioEvent = myHelper.AudioEvent.Create(audioTrack, audioMedia, current);

                    current += audioEvent.Length + interval;
                }
            }
            return current;
        }

        private Timecode InsertAudio(Timecode current, Timecode interval, string audioFileDir, AudioTrack audioTrack, bool recursive, string[] jimakuLines, double stdSilentLength, MediaBin mediaBin = null)
        {
            List<Media> mediaList = new List<Media>();

            GetAudioMediaList(ref mediaList, audioFileDir, recursive, mediaBin);

            IEnumerator<Media> mediaEnumerator = mediaList.GetEnumerator();

            for(int i = 0; i< jimakuLines.Length; i++)
            {
                var line = jimakuLines[i];
                if(line.IndexOf(":") != -1 && mediaEnumerator.MoveNext())
                {
                    Media audioMedia = mediaEnumerator.Current;
                    AudioEvent audioEvent = myHelper.AudioEvent.Create(audioTrack, audioMedia, current);
                    current += audioEvent.Length + interval;
                }
                else // 声優名が見つからない
                {
                    double silentLength = stdSilentLength;
                    int sepPos = line.IndexOf(']');
                    if (line.Substring(0, 1) == "[" && sepPos != -1)
                    {
                        string silentLengthStr = line.Substring(1, sepPos - 1);
                        silentLength = double.Parse(silentLengthStr);
                        // 動画上では空白の長さを表示させない
                        jimakuLines[i] = jimakuLines[i].Substring(sepPos + 1);
                    }

                    Timecode silentTime = new Timecode(silentLength);
                    myHelper.AudioEvent.Create(audioTrack, current, silentTime);
                    current += silentTime + interval;
                }
            }
            return current;
        }

        private void GetAudioMediaList(ref List<Media> list, string audioFileDir, bool recursive, MediaBin mediaBin = null)
        {
            if (recursive)
            {
                foreach (string childDir in Directory.GetDirectories(audioFileDir))
                {
                    GetAudioMediaList(ref list, childDir, recursive, mediaBin);
                }
            }

            foreach (string filePath in Directory.GetFiles(audioFileDir))
            {
                if (myHelper.Config.AudioFileExts.Contains(Path.GetExtension(filePath)))
                {
                    list.Add(myHelper.Media.Create(filePath, mediaBin));
                }
            }
        }
    }
}
