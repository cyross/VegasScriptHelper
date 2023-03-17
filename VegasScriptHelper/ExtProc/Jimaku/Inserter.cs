using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Jimaku
{
    public class Inserter : BaseProc.BaseExtProc
    {
        public Inserter(VegasHelper helper) : base(helper) {}

        public void Exec(in JimakuParams jimakuParams, AudioTrack audioTrack)
        {
            List<TrackEvent> serifuEvents = audioTrack.Events.ToList();
            int serifuCounts = serifuEvents.Count;

            PlugInNode node = myHelper.PlugInNode.GetTitle();

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

                Media jimakuMedia = myHelper.Media.Create(node, jimakuParams.Jimaku.PresetName, jimakuParams.Jimaku.MediaBin.Bin);
                TrackEvent jimakuEvent = myHelper.VideoEvent.Create(jimakuParams.Jimaku.Track.Track, jimakuMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.Jimaku.Margin);
                ColorInfo jimakuColorInfo = new ColorInfo();

                if(actorName != "" && IsUseColorSetting(jimakuParams.JimakuColor.IsUse, actorName))
                {
                    jimakuColorInfo = jimakuParams.JimakuColor;
                }
                else // 声優なしの場合もこれ
                {
                    jimakuColorInfo.TextColor = myHelper.Config.ActorToTextColor[actorName];
                    jimakuColorInfo.OutlineColor = myHelper.Config.ActorToOLColor[actorName];
                    jimakuColorInfo.OutlineWidth = jimakuParams.JimakuColor.OutlineWidth;
                }

                myHelper.TextParam.SetText(jimakuMedia, jimakuLine, jimakuColorInfo);

                groupList.Add(jimakuEvent);

                if(jimakuParams.IsCreateActorTrack && actorName != "")
                {
                    Media actorMedia = myHelper.Media.Create(node, jimakuParams.Actor.PresetName, jimakuParams.Actor.MediaBin.Bin);
                    TrackEvent actorEvent = myHelper.VideoEvent.Create(jimakuParams.Actor.Track.Track, actorMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.Actor.Margin);
                    ColorInfo actorColorInfo = new ColorInfo();

                    if (IsUseColorSetting(jimakuParams.ActorColor.IsUse, actorName))
                    {
                        actorColorInfo = jimakuParams.ActorColor;
                    }
                    else // 声優なしの場合もこれ
                    {
                        actorColorInfo.TextColor = myHelper.Config.ActorToTextColor[actorName];
                        actorColorInfo.OutlineColor = myHelper.Config.ActorToOLColor[actorName];
                        actorColorInfo.OutlineWidth = jimakuParams.ActorColor.OutlineWidth;
                    }

                    string realActorName = actorName;

                    if (jimakuParams.isRemoveActorAttr)
                    {
                        int attrPos = realActorName.IndexOf('(');

                        if(attrPos != -1) { realActorName = realActorName.Substring(0, attrPos); }
                    }

                    myHelper.TextParam.SetText(actorMedia, realActorName, actorColorInfo);

                    groupList.Add(actorEvent);
                }
                else if(jimakuParams.IsCreateActorTrack) // 声優名なし
                {
                    TrackEvent actorEvent = myHelper.VideoEvent.Create(jimakuParams.Actor.Track.Track, serifuEvent.Start, serifuEvent.Length, jimakuParams.Actor.Margin);

                    groupList.Add(actorEvent);
                }

                myHelper.Project.AddTrackEventGroup(groupList.ToArray());
            }
        }

        private bool IsUseColorSetting(bool isUse, string actorName)
        {
            return isUse || actorName == "" || !myHelper.Config.ActorToTextColor.Contains(actorName);
        }
    }
}
