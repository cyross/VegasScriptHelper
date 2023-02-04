using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public interface IEntryPoint
    {
        void FromVegas(Vegas vegas);
    }

    public struct VegasDuration
    {
        public Timecode StartTime;
        public Timecode Length;

        public VegasDuration(Timecode startTime, Timecode length)
        {
            StartTime = startTime;
            Length = length;
        }
    }

    public struct VegasTime
    {
        public long OrgNanos;
        public long MilliSecond;
        public long Second;
        public long Minute;
        public long Hour;

        public VegasTime(long nanos)
        {
            OrgNanos = nanos;
            nanos = nanos / 10000;
            MilliSecond = nanos % 1000;
            nanos /= 1000;
            Second = nanos % 60;
            nanos /= 60;
            Minute = nanos % 60;
            Hour = nanos / 60;
        }

        public VegasTime(long hour, long minute, long second, long millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            MilliSecond = millisecond;
            OrgNanos = 0;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}:{1}:{2}.{3}",
                Hour,
                Minute,
                Second,
                MilliSecond);
        }

        public long Nanos
        {
            get {
                long nanos = Hour * 60;
                nanos = (nanos + Minute) * 60;
                nanos = (nanos + Second) * 1000;
                return (nanos + MilliSecond) * 10000;
            }
        }
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
            VegasScriptSettings.Load();
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
