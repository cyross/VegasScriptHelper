using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public class VHTransport
    {
        private TransportControl transport;

        public VHTransport(Vegas vegas)
        {
            this.transport = vegas.Transport;
        }

        public Timecode CursolPosition
        {
            get { return transport.CursorPosition; }
            set { transport.CursorPosition = value; }
        }
    }
}
