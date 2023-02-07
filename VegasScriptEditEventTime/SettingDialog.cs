﻿using System.ComponentModel;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptEditEventTime
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        public long StartTime
        {
            get { return GetStartTimeNanos(); }
            set { SetStartTimeNanos(value); }
        }

        public long TimeLength
        {
            get { return GetTimeLenthNanos(); }
            set { SetTimeLengthNanos(value); }
        }

        private void SetStartTimeNanos(long nanos)
        {
            SetNanos(nanos, startTimeHour, startTimeMinute, startTimeSecond, startTimeMilliSecond);
        }

        private void SetTimeLengthNanos(long nanos)
        {
            SetNanos(nanos, timeLengthHour, timeLengthMinute, timeLengthSecond, timeLengthMilliSecond);
        }

        private void SetNanos(long nanos, TextBox hBox, TextBox mBox, TextBox sBox, TextBox msBox)
        {
            VegasTime time = new VegasTime(nanos);
            hBox.Text = time.Hour.ToString();
            mBox.Text = time.Minute.ToString();
            sBox.Text = time.Second.ToString();
            msBox.Text = time.MilliSecond.ToString();
        }

        private long GetStartTimeNanos()
        {
            return GetNanos(startTimeHour, startTimeMinute, startTimeSecond, startTimeMilliSecond);
        }

        private long GetTimeLenthNanos()
        {
            return GetNanos(timeLengthHour, timeLengthMinute, timeLengthSecond, timeLengthMilliSecond);
        }

        private long GetNanos(TextBox hBox, TextBox mBox, TextBox sBox, TextBox msBox)
        {
            VegasTime time = new VegasTime(
                long.Parse(hBox.Text),
                long.Parse(mBox.Text),
                long.Parse(sBox.Text),
                long.Parse(msBox.Text)
                );
            return time.Nanos;
        }

        private void ValidateNumberOnly(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            OKButton.Enabled = true;
            ValidateNumBox(startTimeHour, 24);
            ValidateNumBox(startTimeMinute, 60);
            ValidateNumBox(startTimeSecond, 60);
            ValidateNumBox(startTimeMilliSecond, 1000);
            ValidateNumBox(timeLengthHour, 24);
            ValidateNumBox(timeLengthMinute, 60);
            ValidateNumBox(timeLengthSecond, 60);
            ValidateNumBox(timeLengthMilliSecond, 1000);
        }
        
        private void ValidateNumBox(TextBox box, long max)
        {
            int tmp = 0;
            if (string.IsNullOrEmpty(box.Text))
            {
                box.Text = "0";
            }
            else if (!int.TryParse(box.Text, out tmp))
            {
                errorProvider1.SetError(box, "数値ではありません");
                OKButton.Enabled = false;
            }
            else if (tmp < 0 || tmp >= max)
            {
                errorProvider1.SetError(box, "範囲外の数値です");
                OKButton.Enabled = false;
            }

        }
    }
}
