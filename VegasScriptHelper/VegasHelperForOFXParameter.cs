using ScriptPortal.Vegas;
using System.Diagnostics;
using System.Linq;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public OFXStringParameter GetOFXStringParameter(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.String)
                {
                    return (OFXStringParameter)param;
                }
            }

            if (throwException) { throw new VegasHelperNotFoundOFXParameterException(); }

            return null;
        }

        public OFXStringParameter[] GetOFXStringParameters(Media[] mediaList, bool throwException = true)
        {
            return mediaList.Select(m => GetOFXStringParameter(m, throwException)).ToList().ToArray();
        }

        public OFXStringParameter[] GetOFXStringParameters(VideoTrack track, bool throwException = true)
        {
            Media[] mediaList = GetMediaList(track.Events);

            return GetOFXStringParameters(mediaList, throwException);
        }

        /// <summary>
        /// 選択したビデオトラックから、メディジェネレータ字幕のパラメータの配列を取得する
        /// ビデオトラックを選択していなければnullを返す
        /// </summary>
        /// <returns>選択したビデオトラックから得られたメディジェネレータ文字列パラメータの配列、もしくはnull</returns>
        public OFXStringParameter[] GetOFXStringParameters(bool throwException = true)
        {
            VideoTrack selected = SelectedVideoTrack();

            return GetOFXStringParameters(selected, throwException);
        }

        public string GetOFXParameterString(OFXStringParameter param)
        {
            return param.GetValueAtTime(new Timecode(0));
        }

        public string GetOFXParameterString(Media media)
        {
            OFXStringParameter param = GetOFXStringParameter(media);

            return GetOFXParameterString(param);
        }

        public string[] GetOFXParameterStrings(OFXStringParameter[] parameters)
        {
            return parameters.Select(p => GetOFXParameterString(p)).ToArray();
        }

        public string[] GetOFXParameterStrings()
        {
            VideoTrack selected = SelectedVideoTrack();
            OFXStringParameter[] ofxParams = GetOFXStringParameters(selected);

            return GetOFXParameterStrings(ofxParams);
        }

        public void SetStringIntoOFXParameter(OFXStringParameter param, string value)
        {
            param.SetValueAtTime(new Timecode(0), value);
        }

        /// <summary>
        /// 文字列の配列の内容を、メディジェネレータOFXの文字列パラメータ配列の各要素に設定する。
        /// 各引数の要素数が同じでないと処理しない。
        /// </summary>
        /// <param name="ofxParams">メディジェネレータOFXの文字列パラメータの配列</param>
        /// <param name="values">設定する文字列（RTF）の配列</param>
        public void SetStringsIntoOFXParameters(OFXStringParameter[] ofxParams, string[] values)
        {
            if (ofxParams.Length != values.Length) { return; }

            for (int i = 0; i < ofxParams.Length; i++)
            {
                SetStringIntoOFXParameter(ofxParams[i], values[i]);
            }
        }

        public OFXRGBAParameter GetTextRGBAParameter(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == "TextColor")
                {
                    return (OFXRGBAParameter)param;
                }
            }

            if (throwException) { throw new VegasHelperNotFoundOFXParameterException(); }

            return null;
        }

        public OFXRGBAParameter GetOutlineRGBAParameter(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == "OutlineColor")
                {
                    return (OFXRGBAParameter)param;
                }
            }

            if (throwException) { throw new VegasHelperNotFoundOFXParameterException(); }

            return null;
        }

        public OFXDoubleParameter GetOutlineWidthParameter(Media media, bool throwException = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.Double &&
                    param.Name == "OutlineWidth")
                {
                    return (OFXDoubleParameter)param;
                }
            }

            if (throwException) { throw new VegasHelperNotFoundOFXParameterException(); }

            return null;
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(Media[] mediaList, bool throwException = true)
        {
            return mediaList.Select(m => GetTextRGBAParameter(m, throwException)).ToList().ToArray();
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(VideoTrack track, bool throwException = true)
        {
            Media[] mediaList = GetMediaList(track.Events);

            return GetTextRGBAParameters(mediaList, throwException);
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(bool throwException = true)
        {
            VideoTrack selected = SelectedVideoTrack();

            return GetTextRGBAParameters(selected, throwException);
        }

        public void SetRGBAParameter(OFXRGBAParameter param, OFXColor color)
        {
            param.SetValueAtTime(new Timecode(0), color);
        }

        public void SetDoubleParameter(OFXDoubleParameter param, double value)
        {
            param.SetValueAtTime(new Timecode(0), value);
        }
    }
}
