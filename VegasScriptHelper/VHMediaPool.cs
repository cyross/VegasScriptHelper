using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public class VHMediaPool
    {
        private MediaPool pool;

        public VHMediaPool(Vegas vegas)
        {
            pool = vegas.Project.MediaPool;
        }

        public void AddMediaBin(MediaBin bin)
        {
            pool.RootMediaBin.Add(bin);
        }

        public void RemoveMediaBin(MediaBin bin)
        {
            pool.RootMediaBin.Remove(bin);
        }

        public IEnumerable<MediaBin> SearchMediaBin(Func<IMediaBinNode, bool> func) {
            return pool.RootMediaBin.Where(func).Cast<MediaBin>();
        }
    }
}
