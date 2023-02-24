using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VegasScriptHelper
{
    public struct ColorInfo
    {
        public bool IsUse;
        public Color TextColor;
        public Color OutlineColor;
        public double OutlineWidth;
    }

    public struct MediaBinInfo
    {
        public bool IsUse;
        public string Name;
        public MediaBin Bin;
    }

    public struct TextTrackInfo
    {
        public string TrackName;
        public VideoTrack Track;
        public string PresetName;
        public double Margin;
        public MediaBinInfo MediaBinInfo;
    }

    public struct JimakuParams
    {
        public string JimakuFilePath;
        public string[] JimakuLines;

        public TextTrackInfo JimakuInfo;
        public TextTrackInfo ActorInfo;

        public bool IsDeletePrefix;
        public bool IsCreateActorTrack;

        public ColorInfo JimakuColorInfo;

        public ColorInfo ActorColorInfo;
    }

    public partial class VegasHelper
    {
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

                int pos = jimakuLine.IndexOf(":");

                string actorName = (pos == -1) ? "" : jimakuLine.Substring(0, pos);

                if(jimakuParams.IsDeletePrefix)
                {
                    jimakuLine = jimakuLine.Substring(pos + 1);
                }

                Media jimakuMedia = CreateMedia(node, jimakuParams.JimakuInfo.PresetName, jimakuParams.JimakuInfo.MediaBinInfo.Bin);
                TrackEvent jimakuEvent = CreateVideoEvent(jimakuParams.JimakuInfo.Track, jimakuMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.JimakuInfo.Margin);
                ColorInfo jimakuColorInfo = new ColorInfo();

                if(IsUseColorSetting(jimakuParams.JimakuColorInfo.IsUse, actorName))
                {
                    jimakuColorInfo = jimakuParams.JimakuColorInfo;
                }
                else
                {
                    jimakuColorInfo.TextColor = _settings.TextColorByActor[actorName];
                    jimakuColorInfo.OutlineColor = _settings.OutlineColorByActor[actorName];
                    jimakuColorInfo.OutlineWidth = jimakuParams.JimakuColorInfo.OutlineWidth;
                }

                SetText(jimakuMedia, jimakuLine, jimakuColorInfo);

                groupList.Add(jimakuEvent);

                if(actorName != "" && jimakuParams.IsCreateActorTrack)
                {
                    Media actorMedia = CreateMedia(node, jimakuParams.ActorInfo.PresetName, jimakuParams.ActorInfo.MediaBinInfo.Bin);
                    TrackEvent actorEvent = CreateVideoEvent(jimakuParams.ActorInfo.Track, actorMedia, serifuEvent.Start, serifuEvent.Length, jimakuParams.ActorInfo.Margin);
                    ColorInfo actorColorInfo = new ColorInfo();

                    if (IsUseColorSetting(jimakuParams.ActorColorInfo.IsUse, actorName))
                    {
                        actorColorInfo = jimakuParams.ActorColorInfo;
                    }
                    else
                    {
                        actorColorInfo.TextColor = _settings.TextColorByActor[actorName];
                        actorColorInfo.OutlineColor = _settings.OutlineColorByActor[actorName];
                        actorColorInfo.OutlineWidth = jimakuParams.ActorColorInfo.OutlineWidth;
                    }

                    SetText(actorMedia, actorName, actorColorInfo);

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
