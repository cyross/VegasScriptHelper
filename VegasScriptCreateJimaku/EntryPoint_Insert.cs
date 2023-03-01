using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class EntryPoint : IEntryPoint
    {
        private void InsertAudioFile(
            VegasHelper helper,
            ref InsertAudioInfo audioInfo,
            SettingDialog dialog,
            ref KeyListManager manager
            )
        {
            audioInfo.Track.Name = dialog.AudioTrackName;
            audioInfo.Track.Track = GetAudioTrack(helper, audioInfo.Track.Name, manager.AudioTKV);

            audioInfo.MediaBin = CreateMediaBinInfo(helper, dialog.UseAudioMediaBin, dialog.AudioMediaBinName, ref manager);

            helper.InseretAudioInTrack(ref audioInfo);
        }

        private void InsertBackground(
            VegasHelper helper,
            ref BackgroundInfo jimakuBGInfo,
            ref BackgroundInfo actorBGInfo,
            ref InsertAudioInfo audioInfo,
            bool isCreateOne,
            bool isCreateActorTrack,
            ref List<Track> trackGroupList)
        {

            // 声優名を後ろに描画
            if (isCreateActorTrack)
            {
                helper.InsertBackground(actorBGInfo, audioInfo.Track.Track, isCreateOne);
                trackGroupList.Add(actorBGInfo.Track.Track);
            }

            helper.InsertBackground(jimakuBGInfo, audioInfo.Track.Track, isCreateOne);
            trackGroupList.Add(jimakuBGInfo.Track.Track);

            // ２つのトラックで１つのイベントを作った場合はイベントグループ作成
            if (!isCreateOne || !isCreateActorTrack) { return; }

            helper.AddTrackEventGroup(new TrackEvent[]
            {
                jimakuBGInfo.Track.Track.Events[0],
                actorBGInfo.Track.Track.Events[0]
            });
        }
    }
}
