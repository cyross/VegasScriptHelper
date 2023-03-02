using ScriptPortal.Vegas;
using System.Collections.Generic;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        /// <summary>
        /// 現在VEGASが開いているプロジェクトを取得する
        /// </summary>
        public Project Project
        {
            get
            {
                return Vegas.Project;
            }
        }

        public void AddTrackEventGroup(params TrackEvent[] events)
        {
            // Vegas.Project.TrackEventGroups.Addメソッドを先に呼ばいないと、
            // group.Addする際に例外が発生する
            TrackEventGroup group = new TrackEventGroup(Vegas.Project);

            Vegas.Project.TrackEventGroups.Add(group);

            foreach (TrackEvent trackEvent in events)
            {
                group.Add(trackEvent);

            }
        }

        public void AddTrackGroup(List<Track> tracks, string name = null, bool isCollapse = true)
        {
            // トラックグループを作るには、まずトラックを選択する必要がある。
            UnselectAllTrack();

            foreach(var track in tracks)
            {
                track.Selected = true;
            }

            TrackGroup group = Vegas.Project.GroupSelectedTracks();

            if (name != null){ group.Name = name; }

            if (isCollapse) { group.CollapseTrackGroup(); }

            UnselectAllTrack();
        }

        public void UnselectAllTrack()
        {
            foreach (var track in Vegas.Project.Tracks)
            {
                track.Selected = false;
            }
        }
    }
}
