using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper.Properties;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public MediaBin CreateMediaBin(string name)
        {
            var searchResult = SearchMediaBinNodes(name);
            if (searchResult.Count() > 0)
            {
                throw new VegasHelperAlreadyExistedMediaBinException();
            }
            MediaBin newBin = new MediaBin(Vegas.Project, name);
            Vegas.Project.MediaPool.RootMediaBin.Add(newBin);
            return newBin;
        }

        public MediaBin GetMediaBin(string name)
        {
            var searchResult = SearchMediaBinNodes(name);
            if(searchResult.Count() == 0)
            {
                throw new VegasHelperNotFoundMediaBinException();
            }
            return searchResult.First();
        }

        public void DeleteMediaBin(string name)
        {
            var searchResult = SearchMediaBinNodes(name);
            if(searchResult.Count() == 0)
            {
                throw new VegasHelperNotFoundMediaBinException();
            }
            MediaBin target = searchResult.First();
            Vegas.Project.MediaPool.RootMediaBin.Remove(target);
        }

        private IEnumerable<MediaBin> SearchMediaBinNodes(string name)
        {
            return Vegas.Project.MediaPool.RootMediaBin.Where(
                bin => bin.NodeType == MediaBinNodeType.Bin && ((MediaBin)bin).Name == name
                ).Cast<MediaBin>();
        }
    }
}
