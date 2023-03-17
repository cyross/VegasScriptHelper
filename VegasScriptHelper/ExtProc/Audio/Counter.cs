using System.IO;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Audio
{
    public class Counter : BaseProc.BaseExtProc
    {
        public Counter(VegasHelper helper) : base(helper) { }

        public int Get(in InsertAudioInfo info, int current = 0)
        {
            return Get(info.Folder, info.IsRecursive, current);
        }

        public int Get(string audioFileDir, bool recursive, int current = 0)
        {
            if (recursive)
            {
                foreach (string childDir in Directory.GetDirectories(audioFileDir))
                {
                    current = Get(childDir, recursive, current);
                }
            }

            foreach (string filePath in Directory.GetFiles(audioFileDir))
            {
                if (myHelper.Config.AudioFileExts.Contains(Path.GetExtension(filePath)))
                {
                    current++;
                }
            }

            return current;
        }
    }
}
