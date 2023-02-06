using ScriptPortal.Vegas;

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

        public VideoTrack AddVideoTrack()
        {
            return Vegas.Project.AddVideoTrack();
        }

        public AudioTrack AddAudioTrack()
        {
            return Vegas.Project.AddAudioTrack();
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
    }
}
