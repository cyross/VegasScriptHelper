﻿using System.Collections.Generic;
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

        public class SupportedAudioFileSettings: IYamlSpec
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

        public class VoiceActorSetting : IYamlSpec
        {
            public Dictionary<string, Color> NameToColor = new Dictionary<string, Color>();

            public static string SanitizeKey(string org_key)
            {
                return Regex.Replace(org_key, @"[\s()\.\/:\.\[\]\\\/]+", "_");
            }

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

            public Color this[string actor_name]
            {
                get { return NameToColor[SanitizeKey(actor_name)]; }
            }

            public bool Contains(string name)
            {
                return NameToColor.ContainsKey(name);
            }
        }

        public class VoiceActorColors: VoiceActorSetting {}

        public class VoiceActorOutlineColors: VoiceActorSetting {}

        public class DefaultBinNameSetting : IYamlSpec
        {
            public Dictionary<string, string> NameToBin = new Dictionary<string, string>();

            public void Deserialize(YamlStream stream)
            {
                NameToBin = new Dictionary<string, string>();

                foreach (var document in stream.Documents)
                {
                    YamlMappingNode root = (YamlMappingNode)(document.RootNode);
                    foreach (var node in root.Children)
                    {
                        NameToBin[node.Key.ToString()] = node.Value.ToString();
                    }
                }
            }

            public string this[string bin_type]
            {
                get { return NameToBin[bin_type]; }
            }

            public bool Contains(string name)
            {
                return NameToBin.ContainsKey(name);
            }
        }
    }
}