using ScriptPortal.Vegas;
using System.Collections.Generic;
using VegasScriptHelper;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Structs;

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
            VegasScriptHelper.ExtProc.Audio.Insereter inserter = new VegasScriptHelper.ExtProc.Audio.Insereter( helper );

            audioInfo.Track.Name = dialog.AudioTrackName;
            audioInfo.Track.Track = GetAudioTrack(helper, audioInfo.Track.Name, manager.AudioTKV);

            audioInfo.MediaBin = CreateMediaBinInfo(helper, dialog.UseAudioMediaBin, dialog.AudioMediaBinName, ref manager);

            inserter.Exec(ref audioInfo);
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
            VegasScriptHelper.ExtProc.BG.Inserter inserter = new VegasScriptHelper.ExtProc.BG.Inserter(helper);

            // 声優名を後ろに描画
            if (isCreateActorTrack)
            {
                inserter.Exec(actorBGInfo, audioInfo.Track.Track, isCreateOne);
                if (actorBGInfo.Track.Track != null) trackGroupList.Add(actorBGInfo.Track.Track);
            }

            inserter.Exec(jimakuBGInfo, audioInfo.Track.Track, isCreateOne);
            if(jimakuBGInfo.Track.Track != null) trackGroupList.Add(jimakuBGInfo.Track.Track);

            // ２つのトラックで１つのイベントを作った場合はイベントグループ作成
            if (!isCreateOne || jimakuBGInfo.Track.CountEvents() == 0 || actorBGInfo.Track.CountEvents() == 0) return;

            helper.Project.AddTrackEventGroup(new TrackEvent[]
            {
                jimakuBGInfo.Track.Track.Events[0],
                actorBGInfo.Track.Track.Events[0]
            });
        }
    }
}
