using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper.Structs
{
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
            get
            {
                long nanos = Hour * 60;
                nanos = (nanos + Minute) * 60;
                nanos = (nanos + Second) * 1000;
                return (nanos + MilliSecond) * 10000;
            }
        }
    }
}
