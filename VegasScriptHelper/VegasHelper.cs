using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public struct VegasDuration
    {
        public Timecode StartTime;
        public Timecode Length;
    }

    /// <summary>
    /// Vegasオブジェクトを操作するヘルパクラス
    /// 本クラスはSingleton
    /// </summary>
    public partial class VegasHelper
    {
        private static VegasHelper _instance = null;

        internal Vegas Vegas { get; set; }

        internal readonly Timecode BaseTimecode = new Timecode();

        public static VegasHelper Instance(Vegas vegas)
        {
            if (_instance == null)
            {
                _instance = new VegasHelper(vegas);
            }
            else
            {
                _instance.Vegas = vegas;
            }

            return _instance;
        }

        private VegasHelper(Vegas vegas)
        {
            Vegas = vegas;
        }
    }
}
