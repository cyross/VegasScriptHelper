﻿using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        public InsertAudioInfo CreateAudioInfo()
        {
            return new InsertAudioInfo()
            {
                Folder = AudioFileFolder,
                Interval = AudioInterval,
                IsRecursive = IsRecursive,
                IsInsertFromStartPosition = IsInsertFromStartPosition,
                StandardSilenceTime = StandardSilenceTime
            };
        }

        public DialogBGInfo JimakuBGInfo
        {
            get
            {
                return CreateBGInfo(
                    CreateJimakuBackground,
                    JimakuBackgroundTrackName,
                    JimakuBackgroundMediaName,
                    JimakuBackgroundMargin,
                    UseJimakuBackgroundMediaBin,
                    JimakuBackgroundMediaBinName
                    );
            }
        }

        public DialogBGInfo ActorBGInfo
        {
            get
            {
                return CreateBGInfo(
                    CreateActorBackground,
                    ActorBackgroundTrackName,
                    ActorBackgroundMediaName,
                    ActorBackgroundMargin,
                    UseActorBackgroundMediaBin,
                    ActorBackgroundMediaBinName
                    );
            }
        }

        public DialogBGInfo CreateBGInfo(bool createBg, string trackName, string mediaName, double margin, bool useBin, string binName)
        {
            DialogBGInfo bgInfo = new DialogBGInfo()
            {
                createBG = createBg,
                trackName = trackName,
                mediaName = mediaName,
                margin = margin,
                useMediaBin = useBin,
                mediaBinName = binName
            };
            return bgInfo;
        }

        public DialogTrackInfo JimakuTrackInfo
        {
            get
            {
                return CreateTrackInfo(
                    JimakuTrackName,
                    JimakuPresetName,
                    UseJimakuMediaBin,
                    JimakuMediaBinName
                    );
            }
        }

        public DialogTrackInfo ActorTrackInfo
        {
            get
            {
                return CreateTrackInfo(
                    ActorTrackName,
                    ActorPresetName,
                    UseActorMediaBin,
                    ActorMediaBinName
                    );
            }
        }

        public DialogTrackInfo CreateTrackInfo(string trackName, string presetName, bool useBin, string binName)
        {
            DialogTrackInfo info = new DialogTrackInfo()
            {
                trackName = trackName,
                presetName = presetName,
                useMediaBin = useBin,
                mediaBinName = binName
            };
            return info;
        }
    }
}