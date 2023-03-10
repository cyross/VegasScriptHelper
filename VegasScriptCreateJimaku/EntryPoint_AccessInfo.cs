using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private ColorInfo CreateColorInfo(bool isUse, Color textColor, Color outlineColor, double outlineWidth)
        {
            ColorInfo info = new ColorInfo()
            {
                IsUse = isUse,
                OutlineWidth = outlineWidth
            };

            if (!info.IsUse) { return info; }

            info.TextColor = textColor;
            info.OutlineColor = outlineColor;

            return info;
        }

        private MediaBinInfo CreateMediaBinInfo(VegasHelper helper, bool isUse, string name, ref KeyListManager manager)
        {
            MediaBinInfo info = new MediaBinInfo()
            {
                IsUse = isUse
            };

            if (!info.IsUse) { return info; }

            info.Name = name;
            info.Bin = GetMediaBin(helper, name, manager.MbKV);

            return info;
        }

        private BackgroundInfo CreateBackgroundInfo(VegasHelper helper, DialogBGInfo bgInfo, ref KeyListManager manager)
        {
            BackgroundInfo info = new BackgroundInfo()
            {
                IsCreate = bgInfo.createBG
            };

            if (!info.IsCreate) { return info; }

            info.Track.Name = bgInfo.trackName;
            info.Track.Track = GetVideoTrack(helper, info.Track.Name, manager.VideoTKV);

            if (manager.MKV.Count == 0 || bgInfo.mediaName == "")
            {
                info.Media.Name = "";
                info.Media.Media = null;
            }
            else
            {
                info.Media.Name = bgInfo.mediaName;
                info.Media.Media = manager.MKV[info.Media.Name];
            }
            info.Margin = bgInfo.margin;
            info.MediaBin = CreateMediaBinInfo(helper, bgInfo.useMediaBin, bgInfo.mediaBinName, ref manager);

            return info;
        }

        private void SetTextInfo(
            ref TextTrackInfo info,
            VegasHelper helper,
            DialogTrackInfo trackInfo,
            ref List<Track> trackGroupList,
            ref KeyListManager manager)
        {
            info.Track.Name = trackInfo.trackName;
            info.Track.Track = GetVideoTrack(helper, info.Track.Name, manager.VideoTKV);
            trackGroupList.Add(info.Track.Track);

            info.PresetName = trackInfo.presetName;
            info.MediaBin = CreateMediaBinInfo(helper, trackInfo.useMediaBin, trackInfo.mediaBinName, ref manager);
        }

    }
}
