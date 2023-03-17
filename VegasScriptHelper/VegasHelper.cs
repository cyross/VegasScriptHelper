using ScriptPortal.Vegas;
using VegasScriptHelper.Settings;

namespace VegasScriptHelper
{
    /// <summary>
    /// Vegasオブジェクトを操作するヘルパクラス
    /// 本クラスはSingleton
    /// </summary>
    public partial class VegasHelper
    {
        public const string FONT_FILENAME = "MPLUS1-VariableFont_wght.ttf";

        private static VegasHelper instance = null;
        private static Config config = null;

        private VHApp app;
        private VHProject project;
        private VHTransport transport;
        private VHGen gen;
        private VHMediaPool pool;

        private VHEvent ev;
        private VHAudioEvent aev;
        private VHVideoEvent vev;
        private VHMedia media;
        private VHMediaBin mediaBin;
        private VHOFXParam ofxParam;
        private VHTake take;
        private VHTrack track;
        private VHAudioTrack atrack;
        private VHVideoTrack vtrack;
        private VHTextParam textParam;
        private VHPlugInNode plugInNode;

        private VHRtf rtf;

        public static VegasHelper Instance(Vegas vegas)
        {
            config = Config.Instance;
            config.Load();
            if (instance == null)
            {
                instance = new VegasHelper(vegas);
            }
            else
            {
                instance.Vegas = vegas;
            }

            return instance;
        }

        private VegasHelper(Vegas vegas)
        {
            Vegas = vegas;

            app = new VHApp(vegas);
            project = new VHProject(vegas);
            transport = new VHTransport(vegas);
            gen = new VHGen(vegas);
            pool = new VHMediaPool(vegas);

            ev = new VHEvent(this);
            aev = new VHAudioEvent(this);
            vev = new VHVideoEvent(this);
            media = new VHMedia(this);
            mediaBin = new VHMediaBin(this);
            ofxParam = new VHOFXParam(this);
            take = new VHTake(this);
            track = new VHTrack(this);
            atrack = new VHAudioTrack(this);
            vtrack = new VHVideoTrack(this);
            textParam = new VHTextParam(this);
            plugInNode = new VHPlugInNode(this);

            rtf = new VHRtf();
        }

        internal Vegas Vegas { get; set; }

        public Config Config { get { return config; } }

        public VHApp App { get { return app; } }

        public VHProject Project { get { return project; } }

        public VHTransport Transport { get { return transport; } }

        public VHGen Gen { get { return gen; } }

        public VHMediaPool MPool { get { return pool; } }

        public VHEvent Event { get { return ev; } }

        public VHAudioEvent AudioEvent { get { return aev; } }

        public VHVideoEvent VideoEvent { get { return vev; } }

        public VHMedia Media { get { return media; } }

        public VHMediaBin MediaBin { get { return mediaBin; } }

        public VHOFXParam OFXParam { get { return ofxParam; } }
        
        public VHTake Take { get { return take; } }

        public VHTrack Track { get { return track; } }

        public VHAudioTrack AudioTrack { get { return atrack; } }

        public VHVideoTrack VideoTrack { get { return vtrack; } }

        public VHTextParam TextParam { get { return textParam; } }

        public VHPlugInNode PlugInNode { get { return plugInNode; } }

        public VHRtf Rtf { get { return rtf; } }
    }
}
