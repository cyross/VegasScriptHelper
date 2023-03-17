using System.Collections.Generic;
using System.Linq;
using ScriptPortal.Vegas;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHMediaBin
    {
        private VegasHelper myHelper;

        public VHMediaBin(VegasHelper helper)
        {
            myHelper = helper;
        }

        public bool IsExist(string name)
        {
            return SearchNodes(name).Any();
        }

        public MediaBin Create(string name, bool throwException = true)
        {
            bool isExist = IsExist(name);

            if (throwException && isExist)
            {
                throw new VHAlreadyExistedMediaBinException();
            }
            else if(isExist)
            {
                return Get(name, false);
            }

            return CreateInner(name);
        }

        public MediaBin Get(string name, bool throwException = true)
        {
            var searchResult = SearchNodes(name);

            if(throwException && !searchResult.Any())
            {
                throw new VHNotFoundMediaBinException();
            }
            else if(!searchResult.Any())
            {
                return CreateInner(name);
            }

            return searchResult.First();
        }

        private MediaBin CreateInner(string name)
        {
            MediaBin newBin = myHelper.Project.CreateMediaBin(name);

            myHelper.MPool.AddMediaBin(newBin);

            return newBin;
        }

        public void Delete(string name, bool throwException = true)
        {
            var searchResult = SearchNodes(name);

            if (throwException && !searchResult.Any())
            {
                throw new VHNotFoundMediaBinException();
            }
            else if(!searchResult.Any())
            {
                return;
            }

            MediaBin target = searchResult.First();

            myHelper.MPool.RemoveMediaBin(target);
        }

        private IEnumerable<MediaBin> GetEnuerable()
        {
            return myHelper.MPool.SearchMediaBin(node => node.NodeType == MediaBinNodeType.Bin);
        }

        public List<MediaBin> GetList()
        {
            return GetEnuerable().ToList();
        }

        public List<string> GetNameList()
        {
            return GetEnuerable().Select(bin => bin.Name).ToList();
        }

        public Dictionary<string, MediaBin> GetKeyValuePairs()
        {
            return GetKeyValuePairs(GetList());
        }

        public Dictionary<string, MediaBin> GetKeyValuePairs(List<MediaBin> binList)
        {
            return binList.ToDictionary(b => GetKey(b), b => b);
        }

        public string GetKey(MediaBin bin)
        {
            return bin.Name;
        }

        private IEnumerable<MediaBin> SearchNodes(string name)
        {
            return myHelper.MPool.SearchMediaBin(node => CompNode(node, name));
        }

        private bool CompNode(IMediaBinNode node, string name)
        {
            return node.NodeType == MediaBinNodeType.Bin && ((MediaBin)node).Name == name;
        }
    }
}
