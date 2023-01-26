using ScriptPortal.Vegas;
using System.Linq;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public OFXStringParameter GetOFXStringParameter(Media media, bool retNull = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.String)
                {
                    return (OFXStringParameter)param;
                }
            }
            if (retNull) { return null; }
            throw new VegasHelperNotFoundOFXParameterException();
        }

        public OFXStringParameter[] GetOFXStringParameters(Media[] mediaList, bool retNull = true)
        {
            return mediaList.Select(m => GetOFXStringParameter(m, retNull)).ToList().ToArray();
        }

        public OFXStringParameter[] GetOFXStringParameters(VideoTrack track, bool retNull = true)
        {
            Media[] mediaList = GetMediaList(track.Events);
            return GetOFXStringParameters(mediaList, retNull);
        }

        /// <summary>
        /// 選択したビデオトラックから、メディジェネレータ字幕のパラメータの配列を取得する
        /// ビデオトラックを選択していなければnullを返す
        /// </summary>
        /// <returns>選択したビデオトラックから得られたメディジェネレータ文字列パラメータの配列、もしくはnull</returns>
        public OFXStringParameter[] GetOFXStringParameters(bool retNull = true)
        {
            VideoTrack selected = SelectedVideoTrack();
            return GetOFXStringParameters(selected, retNull);
        }

        public string GetOFXParameterString(OFXStringParameter param)
        {
            return param.GetValueAtTime(BaseTimecode);
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
            param.SetValueAtTime(BaseTimecode, value);
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

        public OFXRGBAParameter GetTextRGBAParameter(Media media, bool retNull = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == "TextColor")
                {
                    return (OFXRGBAParameter)param;
                }
            }
            if (retNull) { return null; }
            throw new VegasHelperNotFoundOFXParameterException();
        }

        public OFXRGBAParameter GetOutlineRGBAParameter(Media media, bool retNull = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.RGBA &&
                    param.Name == "OutlineColor")
                {
                    return (OFXRGBAParameter)param;
                }
            }
            if (retNull) { return null; }
            throw new VegasHelperNotFoundOFXParameterException();
        }

        public OFXDoubleParameter GetOutlineWidthParameter(Media media, bool retNull = true)
        {
            foreach (OFXParameter param in media.Generator.OFXEffect.Parameters)
            {
                if (param.ParameterType == OFXParameterType.Double &&
                    param.Name == "OutlineWidth")
                {
                    return (OFXDoubleParameter)param;
                }
            }
            if (retNull) { return null; }
            throw new VegasHelperNotFoundOFXParameterException();
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(Media[] mediaList, bool retNull = true)
        {
            return mediaList.Select(m => GetTextRGBAParameter(m, retNull)).ToList().ToArray();
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(VideoTrack track, bool retNull = true)
        {
            Media[] mediaList = GetMediaList(track.Events);
            return GetTextRGBAParameters(mediaList, retNull);
        }

        public OFXRGBAParameter[] GetTextRGBAParameters(bool retNull = true)
        {
            VideoTrack selected = SelectedVideoTrack();
            return GetTextRGBAParameters(selected, retNull);
        }

        public void SetRGBAParameter(OFXRGBAParameter param, OFXColor color)
        {
            param.SetValueAtTime(BaseTimecode, color);
        }

        public void SetDoubleParameter(OFXDoubleParameter param, double value)
        {
            param.SetValueAtTime(BaseTimecode, value);
        }
    }
}
