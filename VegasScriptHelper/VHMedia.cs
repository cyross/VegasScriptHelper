using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper
{
    public class VHMedia
    {
        public static readonly string NoSelectMedia = "(メディアを挿入しない)";

        internal static readonly string PoolName = "ScriptPortal.Vegas.Media";

        private VegasHelper myHelper;

        public VHMedia(VegasHelper helper)
        {
            myHelper = helper;
        }

        public Media Create(string path, MediaBin mediaBin = null)
        {
            Media media = new Media(path);

            mediaBin?.Add(media);

            return media;
        }

        public Media Create(PlugInNode node, string preset = null, MediaBin mediaBin = null)
        {
            Media media = new Media(node);

            if (preset != null) { media.Generator.Preset = preset; }

            mediaBin?.Add(media);

            return media;
        }

        public Media[] GetList(Track track)
        {
            if (track is null) { return null; }

            return GetList(track.Events);
        }

        public Media[] GetVideoList()
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack();

            return GetList(selected);
        }

        public Media[] GetAudioList()
        {
            AudioTrack selected = myHelper.Project.SelectedAudioTrack();

            return GetList(selected);
        }

        public Media[] GetList(TrackEvents events)
        {
            if (events is null) { return null; }

            // テイクは考慮しない
            IEnumerable<Media> mediaList = events.Select(e => e.Takes[0].Media);
            return mediaList.ToArray();
        }

        public Media Generate(PlugInNode node, string presetName)
        {
            return new Media(node, presetName);
        }

        public List<Media> GetProjectVideoList()
        {
            return GetProjectList(m => m.HasVideo());
        }

        public Dictionary<string, Media> GetProjectVideoKeyValuePairs()
        {
            return GetKeyValuePairs(GetProjectVideoList());
        }

        public List<Media> GetProjectAudioList()
        {
            return GetProjectList(m => m.HasAudio());
        }

        public Dictionary<string, Media> GetProjectAudioKeyValuePairs()
        {
            return GetKeyValuePairs(GetProjectAudioList());
        }

        public List<Media> GetProjectList(Func<Media, bool> func)
        {
            List<Media> mediaList = new List<Media>();
            foreach (var poolElement in myHelper.Project.MediaPool)
            {
                if (poolElement.ToString() == PoolName)
                {
                    Media media = (Media)poolElement;
                    if (func(media))
                    {
                        mediaList.Add(media);
                    }
                }
            }
            return mediaList;
        }

        public Dictionary<string, Media> GetKeyValuePairs(List<Media> mediaList)
        {
            return mediaList.ToDictionary(m => GetKey(m), m => m);
        }

        public string GetKey(Media media)
        {
            return media.KeyString;
        }
    }
}
