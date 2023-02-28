using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VegasScriptHelper
{
    public struct JimakuParams
    {
        public string JimakuFilePath;
        public string[] JimakuLines;
        public string[] ActorLines;
        public HashSet<string> ActorSets;

        public TextTrackInfo Jimaku;
        public TextTrackInfo Actor;

        public bool IsDeletePrefix;
        public bool IsCreateActorTrack;
        public bool isRemoveActorAttr;

        public ColorInfo JimakuColor;
        public ColorInfo ActorColor;
    }

    public partial class VegasHelper
    {
        public int CountJimakuLines(string[] jimakuLines)
        {
            return jimakuLines.Where(l => l.Trim().Length > 0 && l.IndexOf(":") != -1).Count();
        }

        public void InsertJimaku(in JimakuParams jimakuParams, AudioTrack audioTrack, bool isGroupSerifuJimakuEvent)
        {
            List<TrackEvent> serifuEvents = audioTrack.Events.ToList();
            int serifuCounts = serifuEvents.Count;

            PlugInNode node = GetTitlePluginNode();

            for (int i=0; i<serifuCounts; i++)
            {
                List<TrackEvent> groupList = new List<TrackEvent>();

                TrackEvent serifuEvent = serifuEvents[i];

                groupList.Add(serifuEvent);

                string jimakuLine = jimakuParams.JimakuLines[i];

                int prefixSeparatorPos = jimakuLine.IndexOf(":");

                string actorName = (prefixSeparatorPos == -1) ? "" : jimakuLine.Substring(0, prefixSeparatorPos);

                if(jimakuParams.IsDeletePrefix && actorName != "")
                {
                    jimakuLine = jimakuLine.Substring(prefixSeparatorPos + 1);
                }

                Media jimakuMedia = CreateMedia(node, jimakuParams.Jimaku.PresetName, jimakuParams.Jimaku.MediaBin.Bin);
                TrackEvent jimakuEvent = CreateVideoEvent(jimakuParams.Jimaku.Track.Track, jimakuMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.Jimaku.Margin);
                ColorInfo jimakuColorInfo = new ColorInfo();

                if(actorName != "" && IsUseColorSetting(jimakuParams.JimakuColor.IsUse, actorName))
                {
                    jimakuColorInfo = jimakuParams.JimakuColor;
                }
                else // 声優なしの場合もこれ
                {
                    jimakuColorInfo.TextColor = _settings.TextColorByActor[actorName];
                    jimakuColorInfo.OutlineColor = _settings.OutlineColorByActor[actorName];
                    jimakuColorInfo.OutlineWidth = jimakuParams.JimakuColor.OutlineWidth;
                }

                SetText(jimakuMedia, jimakuLine, jimakuColorInfo);

                groupList.Add(jimakuEvent);

                if(jimakuParams.IsCreateActorTrack && actorName != "")
                {
                    Media actorMedia = CreateMedia(node, jimakuParams.Actor.PresetName, jimakuParams.Actor.MediaBin.Bin);
                    TrackEvent actorEvent = CreateVideoEvent(jimakuParams.Actor.Track.Track, actorMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.Actor.Margin);
                    ColorInfo actorColorInfo = new ColorInfo();

                    if (IsUseColorSetting(jimakuParams.ActorColor.IsUse, actorName))
                    {
                        actorColorInfo = jimakuParams.ActorColor;
                    }
                    else // 声優なしの場合もこれ
                    {
                        actorColorInfo.TextColor = _settings.TextColorByActor[actorName];
                        actorColorInfo.OutlineColor = _settings.OutlineColorByActor[actorName];
                        actorColorInfo.OutlineWidth = jimakuParams.ActorColor.OutlineWidth;
                    }

                    string realActorName = actorName;

                    if (jimakuParams.isRemoveActorAttr)
                    {
                        int attrPos = realActorName.IndexOf('(');

                        if(attrPos != -1) { realActorName = realActorName.Substring(0, attrPos); }
                    }

                    SetText(actorMedia, realActorName, actorColorInfo);

                    groupList.Add(actorEvent);
                }
                else if(jimakuParams.IsCreateActorTrack) // 声優名なし
                {
                    TrackEvent actorEvent = CreateVideoEvent(jimakuParams.Actor.Track.Track, serifuEvent.Start, serifuEvent.Length, jimakuParams.Actor.Margin);

                    groupList.Add(actorEvent);
                }

                if (isGroupSerifuJimakuEvent)
                {
                    AddTrackEventGroup(groupList.ToArray());
                }
            }
        }

        private bool IsUseColorSetting(bool isUse, string actorName)
        {
            return isUse || actorName == "" || !_settings.TextColorByActor.Contains(actorName);
        }
    }
}
