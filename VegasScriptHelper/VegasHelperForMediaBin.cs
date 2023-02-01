using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper.Properties;

namespace VegasScriptHelper
{
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
            if (!searchResult.Any())
            {
                throw new VegasHelperNotFoundMediaBinException();
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

        private IEnumerable<MediaBin> SearchMediaBinNodes(string name)
        {
            return Vegas.Project.MediaPool.RootMediaBin.Where(
                bin => bin.NodeType == MediaBinNodeType.Bin && ((MediaBin)bin).Name == name
                ).Cast<MediaBin>();
        }

        private IEnumerable<MediaBin> SearchMediaBinNodes(uint id)
        {
            return Vegas.Project.MediaPool.RootMediaBin.Where(
                bin => bin.NodeType == MediaBinNodeType.Bin && ((MediaBin)bin).NodeID == id
                ).Cast<MediaBin>();
        }
    }
}
