using ScriptPortal.Vegas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptEditEventTimeByTextBox
{
    public enum ExecMode
    {
        Script = 0,
        Extension = 1
    }

    public partial class SettingDialog : Form
    {
        private readonly PrivateFontCollection myFontCollection = new PrivateFontCollection();
        private RulerFormat rulerFormat = RulerFormat.Time;
        private ExecMode execMode = ExecMode.Script;

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;
        }

        public ExecMode EMode { set { execMode = value; } }

        public Action<Timecode, Timecode> textUpdateHandler = (s1, s2) => { };

        public Panel MainPanel { get { return mainPanel; } }

        public RulerFormat RulerFormat
        {
            get { return rulerFormat; }
            set { 
                rulerFormat = value; 
                switch(rulerFormat)
                {
                    case RulerFormat.Time:
                        hmsmsFormat.Checked = true;
                        break;
                    case RulerFormat.TimeAndFrames:
                        hmsfFormat.Checked = true;
                        break;
                }
            }
        }

        public Timecode StartTime
        {
            get { return GetStartTime(); }
            set { SetStartTime(value); }
        }

        public Timecode TimeLength
        {
            get { return GetTimeLength(); }
            set { SetTimeLength(value); }
        }

        public void SetToDialog(TrackEvent trackEvent)
        {
            SetStartTime(trackEvent.Start);
            SetTimeLength(trackEvent.Length);
        }

        public void SetFromDialog(TrackEvent trackEvent)
        {
            trackEvent.Start = GetStartTime();
            trackEvent.Length = GetTimeLength();
        }

        private void SetStartTime(Timecode time)
        {
            SetTime(startTimeBox, time);
        }

        private void SetTimeLength(Timecode time)
        {
            SetTime(timeLengthBox, time);
        }

        private void SetTime(TextBox box, Timecode time)
        {
            box.Text = FromTimecode(time, rulerFormat);
        }

        private Timecode GetStartTime()
        {
            return GetTime(startTimeBox);
        }

        private Timecode GetTimeLength()
        {
            return GetTime(timeLengthBox);
        }

        private Timecode GetTime(TextBox box)
        {
            return ToTimecode(box, rulerFormat);
        }

        private string FromTimecode(Timecode time, RulerFormat format)
        {
            return time.ToString(format);
        }

        private Timecode ToTimecode(TextBox box, RulerFormat format)
        {
            return Timecode.FromString(box.Text, format);
        }

        private void ExchangeRulerFormat(TextBox box, RulerFormat from, RulerFormat to)
        {
            Timecode orgTime = ToTimecode(box, from);
            box.Text = FromTimecode(orgTime, to);
        }

        private void ValidateTimeFormatOnly(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            e.Cancel = !ValidateTimeFormat(startTimeBox) || !ValidateTimeFormat(timeLengthBox);
        }
        
        private bool ValidateTimeFormat(TextBox box)
        {
            string timeStr = box.Text;

            // nn:nn:nn.nn 形式になっているか

            string[] timeStrs = timeStr.Split(new char[] { ':' });

            if(timeStrs.Length != 3 ) {
                return ValidateIllegalFormatError(box);
            }

            string[] secStrs = timeStrs[2].Split(new char[] { '.' });

            if (secStrs.Length != 2)
            {
                return ValidateIllegalFormatError(box);
            }

            // 値のチェック（数値・指定の値の範囲内)
            // hour
            if (!int.TryParse(timeStrs[0], out int checkHour) || checkHour < 0 || checkHour > 23)
            {
                return ValidateIllegalFormatError(box);
            }

            // minute
            if (!int.TryParse(timeStrs[1], out int checkMinute) || checkMinute < 0 || checkMinute > 59)
            {
                return ValidateIllegalFormatError(box);
            }

            // second
            if (!int.TryParse(secStrs[0], out int checkSecond) || checkSecond < 0 || checkSecond > 59)
            {
                return ValidateIllegalFormatError(box);
            }

            // msec
            if (rulerFormat == RulerFormat.Time && (!int.TryParse(secStrs[1], out int checkMsec) || checkMsec < 0 || checkMsec > 999))
            {
                return ValidateIllegalFormatError(box);
            }
            else if(rulerFormat == RulerFormat.Time)
            {
                return true;
            }

            Timecode timecodeForFrames = new Timecode();

            // frame
            if (!int.TryParse(secStrs[1], out int checkFrame) || checkFrame < 0 || checkFrame > (int)timecodeForFrames.FrameRate)
            {
                return ValidateIllegalFormatError(box);
            }

            return true;
        }

        private bool ValidateIllegalFormatError(TextBox box)
        {
            errorProvider1.SetError(box, "書式が不正です。");
            return false;
        }

        private void OnChangeFormatRadiobutton(object sender, EventArgs e)
        {
            RulerFormat org_format = rulerFormat;
            if(hmsmsFormat.Checked)
            {
                rulerFormat = RulerFormat.Time;
            }
            else // hmsfFormat.Checked
            {
                rulerFormat = RulerFormat.TimeAndFrames;
            }
            ExchangeRulerFormat(startTimeBox, org_format, rulerFormat);
            ExchangeRulerFormat(timeLengthBox, org_format, rulerFormat);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if(execMode == ExecMode.Script) {
                return;
            }

            textUpdateHandler(StartTime, TimeLength);
        }
    }
}
