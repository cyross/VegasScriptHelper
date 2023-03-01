using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void ReadJimaku(ref JimakuParams jimakuParams, SettingDialog dialog)
        {
            jimakuParams.JimakuFilePath = dialog.JimakuFilePath;

            using (var jimakuFile = new StreamReader(jimakuParams.JimakuFilePath))
            {
                jimakuParams.JimakuLines = jimakuFile.ReadToEnd().Split(new char[] { '\n' }).Select(s => s.Replace("\r", "")).Where(s => s.Length > 0).ToArray();
            }

            List<string> actorLines = new List<string>();
            foreach (var line in jimakuParams.JimakuLines)
            {
                int prefixSeparatorPos = line.IndexOf(":");

                string actorName = (prefixSeparatorPos == -1) ? "" : line.Substring(0, prefixSeparatorPos);

                actorLines.Add(actorName);
            }
            jimakuParams.ActorLines = actorLines.ToArray();
            jimakuParams.ActorSets = new HashSet<string>(actorLines);
        }

        private void InsertJimaku(
            ref JimakuParams jimaku,
            VegasHelper helper,
            SettingDialog dialog,
            ref InsertAudioInfo audioInfo
            )
        {
            jimaku.JimakuColor = CreateColorInfo(dialog.UseJimakuDefaultSettings,
                dialog.JimakuColor, dialog.JimakuOutlineColor, dialog.JimakuOutlineWidth);

            jimaku.ActorColor = CreateColorInfo(dialog.UseActorDefaultSettings,
                dialog.ActorColor, dialog.ActorOutlineColor, dialog.ActorOutlineWidth);

            helper.InsertJimaku(jimaku, audioInfo.Track.Track);
        }
    }
}
