using ScriptPortal.Vegas;
using System.Drawing;
using System.Linq;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHOFXParam
    {
        private static readonly string TextColor = "TextColor";
        private static readonly string OutlineColor = "OutlineColor";
        private static readonly string OutlineWidth = "OutlineWidth";

        private VegasHelper myHelper;

        public VHOFXParam(VegasHelper helper)
        {
            myHelper = helper;
        }

        public OFXStringParameter GetStringParam(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.String)
                {
                    return (OFXStringParameter)param;
                }
            }

            if (throwException) { throw new VHNotFoundOFXParameterException(); }

            return null;
        }

        public OFXStringParameter[] GetStringParams(Media[] mediaList, bool throwException = true)
        {
            return mediaList.Select(m => GetStringParam(m, throwException)).ToList().ToArray();
        }

        public OFXStringParameter[] GetStringParams(VideoTrack track, bool throwException = true)
        {
            Media[] mediaList = myHelper.Media.GetList(track.Events);

            return GetStringParams(mediaList, throwException);
        }

        /// <summary>
        /// 選択したビデオトラックから、メディジェネレータ字幕のパラメータの配列を取得する
        /// ビデオトラックを選択していなければnullを返す
        /// </summary>
        /// <returns>選択したビデオトラックから得られたメディジェネレータ文字列パラメータの配列、もしくはnull</returns>
        public OFXStringParameter[] GetStringParams(bool throwException = true)
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack();

            return GetStringParams(selected, throwException);
        }

        public string GetString(OFXStringParameter param)
        {
            return param.GetValueAtTime(new Timecode(0));
        }

        public string GetString(Media media)
        {
            OFXStringParameter param = GetStringParam(media);

            return GetString(param);
        }

        public string[] GetStrings(OFXStringParameter[] parameters)
        {
            return parameters.Select(p => GetString(p)).ToArray();
        }

        public string[] GetStrings()
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack();
            OFXStringParameter[] ofxParams = GetStringParams(selected);

            return GetStrings(ofxParams);
        }

        public void SetString(OFXStringParameter param, string value)
        {
            param.SetValueAtTime(new Timecode(0), value);
        }

        /// <summary>
        /// 文字列の配列の内容を、メディジェネレータOFXの文字列パラメータ配列の各要素に設定する。
        /// 各引数の要素数が同じでないと処理しない。
        /// </summary>
        /// <param name="ofxParams">メディジェネレータOFXの文字列パラメータの配列</param>
        /// <param name="values">設定する文字列（RTF）の配列</param>
        public void SetStrings(OFXStringParameter[] ofxParams, string[] values)
        {
            if (ofxParams.Length != values.Length) { return; }

            for (int i = 0; i < ofxParams.Length; i++)
            {
                SetString(ofxParams[i], values[i]);
            }
        }

        public OFXRGBAParameter GetTextRGBAParam(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == TextColor)
                {
                    return (OFXRGBAParameter)param;
                }
            }

            if (throwException) { throw new VHNotFoundOFXParameterException(); }

            return null;
        }

        public OFXRGBAParameter GetOLRGBAParam(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == OutlineColor)
                {
                    return (OFXRGBAParameter)param;
                }
            }

            if (throwException) { throw new VHNotFoundOFXParameterException(); }

            return null;
        }

        public OFXDoubleParameter GetOLWidthParam(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.Double &&
                    param.Name == OutlineWidth)
                {
                    return (OFXDoubleParameter)param;
                }
            }

            if (throwException) { throw new VHNotFoundOFXParameterException(); }

            return null;
        }

        public OFXRGBAParameter[] GetTextRGBAParams(Media[] mediaList, bool throwException = true)
        {
            return mediaList.Select(m => GetTextRGBAParam(m, throwException)).ToList().ToArray();
        }

        public OFXRGBAParameter[] GetTextRGBAParams(VideoTrack track, bool throwException = true)
        {
            Media[] mediaList = myHelper.Media.GetList(track.Events);

            return GetTextRGBAParams(mediaList, throwException);
        }

        public OFXRGBAParameter[] GetTextRGBAParams(bool throwException = true)
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack();

            return GetTextRGBAParams(selected, throwException);
        }

        public void SetRGBAParam(OFXRGBAParameter param, OFXColor color)
        {
            param.SetValueAtTime(new Timecode(0), color);
        }

        public void SetDoubleParam(OFXDoubleParameter param, double value)
        {
            param.SetValueAtTime(new Timecode(0), value);
        }

        public void SetRGBAParam(OFXRGBAParameter param, Color color)
        {
            OFXColor ofxColor = new OFXColor(
                (double)color.R / 255.0,
                (double)color.G / 255.0,
                (double)color.B / 255.0,
                (double)color.A / 255.0
            );

            param.SetValueAtTime(new Timecode(0), ofxColor);
        }
    }
}
