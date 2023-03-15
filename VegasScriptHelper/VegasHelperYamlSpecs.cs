using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;

namespace VegasScriptHelper
{
    namespace VegasHelperYamlSpecs
    {
        public interface IYamlSpec
        {
            void Deserialize(YamlStream stream);
            bool Contains(string name);
        }

        public class DefaultListSetting: IYamlSpec
        {
            public List<string> AudioFiles = new List<string>();

            public void Deserialize(YamlStream stream)
            {
                AudioFiles = new List<string>();

                foreach (var document in stream.Documents)
                {
                    YamlNode root = document.RootNode;
                    foreach (var node in root.AllNodes)
                    {
                        AudioFiles.Add(node.ToString());
                    }
                }
            }

            public string this[int index]
            {
                get { return AudioFiles[index]; }
            }

            public bool Contains(string name)
            {
                return AudioFiles.Contains(name);
            }
        }

        public class DefaultColorSetting : IYamlSpec
        {
            public Dictionary<string, Color> NameToColor = new Dictionary<string, Color>();
            public Color DefaultColor;

            public void Deserialize(YamlStream stream)
            {
                NameToColor = new Dictionary<string, Color>();

                foreach (var document in stream.Documents)
                {
                    YamlMappingNode root = (YamlMappingNode)(document.RootNode);
                    foreach (var node in root.Children)
                    {
                        string colorName = node.Value.ToString();

                        Color color;

                        // HTML形式かR,G,B形式かをチェックする
                        if(Regex.IsMatch(colorName, @"^#[0-9a-fA-F]{6,8}$"))
                        {
                            // HTML形式(#rrggbb / #rrggbbaa)
                            color = ColorTranslator.FromHtml(colorName);
                        }
                        else if(Regex.IsMatch(colorName, @"^\d{1,3}\s*,\s*\d{1,3}\s*,\s*\d{1,3}$"))
                        {
                            string[] color_values = colorName.Split(new char[] { ',' });
                            color_values = color_values.Select(cv => cv.Trim()).ToArray();
                            int[] rgb = color_values.Select(cv => int.Parse(cv)).ToArray();
                            color = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                        }
                        else
                        {
                            color = Color.FromName(colorName);
                        }

                        NameToColor[node.Key.ToString()] = color;
                    }
                }
            }

            public Color this[string name]
            {
                get {
                    if (!Contains(name)) { return DefaultColor; }

                    return NameToColor[name];
                }
            }

            public bool Contains(string name)
            {
                return NameToColor.ContainsKey(name);
            }

            public List<string> Keys()
            {
                return NameToColor.Keys.ToList();
            }
        }

        public class DefaultValueSetting : IYamlSpec
        {
            private Dictionary<string, string> KeyValue = new Dictionary<string, string>();

            public void Deserialize(YamlStream stream)
            {
                KeyValue = new Dictionary<string, string>();

                foreach (var document in stream.Documents)
                {
                    YamlMappingNode root = (YamlMappingNode)(document.RootNode);
                    foreach (var node in root.Children)
                    {
                        KeyValue[node.Key.ToString()] = node.Value.ToString();
                    }
                }
            }

            public string this[string bin_type]
            {
                get { return KeyValue[bin_type]; }
            }

            public bool Contains(string name)
            {
                return KeyValue.ContainsKey(name);
            }

            public List<string> Keys()
            {
                return KeyValue.Keys.ToList();
            }
        }

        public class SupportedAudioFileSettings : DefaultListSetting { }

        public class VoiceActorColors : DefaultColorSetting { }

        public class VoiceActorOutlineColors : DefaultColorSetting { }

        public class DefaultBinNameSetting : DefaultValueSetting {
            public static readonly string voiroVoice = "voiroVoice";
            public static readonly string voiroJimaku = "voiroJimaku";
            public static readonly string voiroActor = "voiroActor";
            public static readonly string jimakuBG = "jimakuBG";
            public static readonly string actorBG = "actorBG";
            public static readonly string tachie = "tachie";
            public static readonly string dlAudio = "dlAudio";
            public static readonly string createdAudio = "createdAudio";
            public static readonly string dlMovie = "dlMovie";
            public static readonly string createdMovie = "createdMovie";
            public static readonly string dlImage = "dlImage";
            public static readonly string createdImage = "createdImage";
        }

        public class DefaultTrackNameSetting : DefaultValueSetting {
            public static readonly string audioTrack = "audioTrack";
            public static readonly string jimakuTrack = "jimakuTrack";
            public static readonly string actorTrack = "actorTrack";
            public static readonly string jimakuBGTrack = "jimakuBGTrack";
            public static readonly string actorBGTrack = "actorBGTrack";
            public static readonly string tachieTrack = "tachieTrack";
        }
    }
}
