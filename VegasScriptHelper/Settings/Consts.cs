namespace VegasScriptHelper.Settings
{
    public class Names
    {
        private static readonly Names all = new Names("All");
        private static readonly Names jimaku = new Names("Jimaku");
        private static readonly Names actor = new Names("Actor");
        private static readonly Names audio = new Names("Audio");
        private static readonly Names video = new Names("Video");
        private static readonly Names tachie = new Names("Tachie");
        private static readonly Names bg = new Names("BG");
        private static readonly Names fg = new Names("FG");
        private static readonly Names bgm = new Names("BGM");
        private static readonly Names time = new Names("Time");
        private static readonly Names hyphenation = new Names("Hyphenation");
        private readonly string str;

        public Names(string value)
        {
            this.str = value;
        }

        public Names Pre(string v)
        {
            return new Names(v + str);
        }

        public Names Post(string v)
        {
            return new Names(str + v);
        }

        public static implicit operator string(Names sn)
        {
            return sn.ToString();
        }

        public override string ToString()
        {
            return str;
        }

        public static Names WdAll { get { return all; } }
        public static Names WdJimaku { get { return jimaku; } }
        public static Names WdActor { get { return actor; } }
        public static Names WdAudio { get { return audio; } }
        public static Names WdVideo { get { return video; } }
        public static Names WdTachie { get { return tachie; } }
        public static Names WdBG { get { return bg; } }
        public static Names WdFG { get { return fg; } }
        public static Names WdBGM { get { return bgm; } }
        public static Names WdTime { get { return time; } }
        public static Names WdHyphe { get { return hyphenation; } }
        public Names Create { get { return Pre("Create"); } }
        public Names Use { get { return Pre("Use"); } }
        public Names Is { get { return Pre("Is"); } }
        public Names Expand { get { return Pre("Expand"); } }
        public Names Remove { get { return Pre("Remove"); } }
        public Names Divide { get { return Pre("Divide"); } }
        public Names BG { get { return Post("BG"); } }
        public Names Media { get { return Post("Media"); } }
        public Names Bin { get { return Post("Bin"); } }
        public Names MediaBin { get { return Post("MediaBin"); } }
        public Names Name { get { return Post("Name"); } }
        public Names Track { get { return Post("Track"); } }
        public Names Tracks { get { return Post("Tracks"); } }
        public Names Preset { get { return Post("Preset"); } }
        public Names Margin { get { return Post("Margin"); } }
        public Names Setting { get { return Post("Setting"); } }
        public Names Settings { get { return Post("Settings"); } }
        public Names Color { get { return Post("Color"); } }
        public Names Outline { get { return Post("Outline"); } }
        public Names Width { get { return Post("Width"); } }
        public Names File { get { return Post("File"); } }
        public Names Folder { get { return Post("Folder"); } }
        public Names Path { get { return Post("Path"); } }
        public Names Insert { get { return Post("Insert"); } }
        public Names Interval { get { return Post("Interval"); } }
        public Names Recursive { get { return Post("Recursive"); } }
        public Names Check { get { return Post("Check"); } }
        public Names Group { get { return Post("Group"); } }
        public Names From { get { return Post("From"); } }
        public Names Start { get { return Post("Start"); } }
        public Names Position { get { return Post("Position"); } }
        public Names Event { get { return Post("Event"); } }
        public Names Serifu { get { return Post("Serifu"); } }
        public Names One { get { return Post("One"); } }
        public Names Collapse { get { return Post("Collapse"); } }
        public Names Silence { get { return Post("Silence"); } }
        public Names Standard { get { return Post("Standard"); } }
        public Names Time { get { return Post("Time"); } }
        public Names Attribute { get { return Post("Attribute"); } }
        public Names Prefix { get { return Post("Prefix"); } }
        public Names Behavior { get { return Post("Behavior"); } }
        public Names Ruler { get { return Post("Ruler"); } }
        public Names Format { get { return Post("Format"); } }
        public Names Length { get { return Post("Length"); } }
    }
}
