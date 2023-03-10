using ScriptPortal.Vegas;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VegasScriptHelper
{
    public struct MediaInfo
    {
        public string Name;
        public Media Media;
    }

    public partial class VegasHelper
    {
        public static readonly string NoSelectMedia = "(メディアを挿入しない)";

        public Media CreateMedia(string path, MediaBin mediaBin = null)
        {
            Media media = new Media(path);

            mediaBin?.Add(media);

            return media;
        }

        public Media CreateMedia(PlugInNode node, string preset = null, MediaBin mediaBin = null)
        {
            Media media = new Media(node);

            if (preset != null) { media.Generator.Preset = preset; }

            mediaBin?.Add(media);

            return media;
        }

        public Media[] GetMediaList(Track track)
        {
            if (track is null) { return null; }

            return GetMediaList(track.Events);
        }

        public Media[] GetVideoMediaList()
        {
            VideoTrack selected = SelectedVideoTrack();

            return GetMediaList(selected);
        }

        public Media[] GetAudioMediaList()
        {
            AudioTrack selected = SelectedAudioTrack();

            return GetMediaList(selected);
        }

        public Media[] GetMediaList(TrackEvents events)
        {
            if (events is null) { return null; }

            // テイクは考慮しない
            IEnumerable<Media> mediaList = events.Select(e => e.Takes[0].Media);
            return mediaList.ToArray();
        }

        public PlugInNode GetTitlePluginNode()
        {
            return Vegas.Generators.GetChildByUniqueID("{Svfx:com.vegascreativesoftware:titlesandtext}");
        }

        public PlugInNode GetSolidColorPluginNode()
        {
            return Vegas.Generators.GetChildByUniqueID("{Svfx:com.vegascreativesoftware:solidcolor}");
        }

        public List<string> GetTitlePluginPresetNames()
        {
            return GetPluginPresetNames(GetTitlePluginNode());
        }

        public List<string> GetSolidColorPluginPresetNames()
        {
            return GetPluginPresetNames(GetSolidColorPluginNode());
        }

        public List<string> GetPluginPresetNames(PlugInNode node)
        {
            return node.Presets.Select(p => p.Name).ToList();
        }

        public Media GenerateMedia(PlugInNode node, string presetName)
        {
            return new Media(node, presetName);
        }

        public List<Media> GetProjectVideoMediaList()
        {
            return GetProjectMediaList(m => m.HasVideo());
        }

        public Dictionary<string, Media> GetProjectVideoMediaKeyValuePairs()
        {
            return GetProjectMediaKeyValuePairs(GetProjectVideoMediaList());
        }

        public List<Media> GetProjectAudioMediaList()
        {
            return GetProjectMediaList(m => m.HasAudio());
        }

        public Dictionary<string, Media> GetProjectAudioMediaKeyValuePairs()
        {
            return GetProjectMediaKeyValuePairs(GetProjectAudioMediaList());
        }

        public List<Media> GetProjectMediaList(Func<Media, bool> func)
        {
            List<Media> mediaList = new List<Media>();
            foreach (var poolElement in Vegas.Project.MediaPool)
            {
                if (poolElement.ToString() == "ScriptPortal.Vegas.Media")
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

        public Dictionary<string, Media> GetProjectMediaKeyValuePairs(List<Media> mediaList)
        {
            return mediaList.ToDictionary(m => GetProjectMediaKey(m), m => m);
        }

        public string GetProjectMediaKey(Media media)
        {
            return media.KeyString;
        }
    }
}
