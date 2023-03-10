using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VegasScriptHelper.Properties;

namespace VegasScriptHelper
{
    public struct MediaBinInfo
    {
        public bool IsUse;
        public string Name;
        public MediaBin Bin;
    }

    public partial class VegasHelper
    {
        public bool IsExistMediaBin(string name)
        {
            return SearchMediaBinNodes(name).Any();
        }

        public MediaBin CreateMediaBin(string name, bool throwException = true)
        {
            bool isExist = IsExistMediaBin(name);

            if (throwException && isExist)
            {
                throw new VegasHelperAlreadyExistedMediaBinException();
            }
            else if(isExist)
            {
                return GetMediaBin(name, false);
            }

            return CreateMediaBinInner(name);
        }

        public MediaBin GetMediaBin(string name, bool throwException = true)
        {
            var searchResult = SearchMediaBinNodes(name);

            if(throwException && !searchResult.Any())
            {
                throw new VegasHelperNotFoundMediaBinException();
            }
            else if(!searchResult.Any())
            {
                return CreateMediaBinInner(name);
            }

            return searchResult.First();
        }

        private MediaBin CreateMediaBinInner(string name)
        {
            MediaBin newBin = new MediaBin(Vegas.Project, name);

            Vegas.Project.MediaPool.RootMediaBin.Add(newBin);

            return newBin;
        }

        public void DeleteMediaBin(string name, bool throwException = true)
        {
            var searchResult = SearchMediaBinNodes(name);

            if (throwException && !searchResult.Any())
            {
                throw new VegasHelperNotFoundMediaBinException();
            }
            else if(!searchResult.Any())
            {
                return;
            }

            MediaBin target = searchResult.First();

            Vegas.Project.MediaPool.RootMediaBin.Remove(target);
        }

        private IEnumerable<MediaBin> GetMediaBinEnuerable()
        {
            return Vegas.Project.MediaPool.RootMediaBin.
                Where(node => node.NodeType == MediaBinNodeType.Bin).
                Cast<MediaBin>().ToList();
        }

        public List<MediaBin> GetMediaBinList()
        {
            return GetMediaBinEnuerable().ToList();
        }

        public List<string> GetMediaBinNameList()
        {
            return GetMediaBinEnuerable().
                Select(bin => bin.Name).
                ToList();
        }

        public Dictionary<string, MediaBin> GetMediaBinKeyValuePairs()
        {
            return GetMediaBinKeyValuePairs(GetMediaBinList());
        }

        public Dictionary<string, MediaBin> GetMediaBinKeyValuePairs(List<MediaBin> binList)
        {
            return binList.ToDictionary(b => GetMediaBinKey(b), b => b);
        }

        public string GetMediaBinKey(MediaBin bin)
        {
            return bin.Name;
        }

        private IEnumerable<MediaBin> SearchMediaBinNodes(string name)
        {
            return Vegas.Project.MediaPool.RootMediaBin.Where(
                bin => bin.NodeType == MediaBinNodeType.Bin && ((MediaBin)bin).Name == name
                ).Cast<MediaBin>();
        }
    }
}
