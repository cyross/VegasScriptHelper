using System;

namespace VegasScriptHelper.Errors
{
    public class VHException : Exception { }
    public class VHNotFoundException : VHException { }
    public class VHAlreadyFoundException : VHException { }
    public class VHNotFoundTrackException : VHNotFoundException { }
    public class VHTrackUnselectedException : VHException { }
    public class VHNoneEventsException : VHNotFoundException { }
    public class VHNoneSelectedEventException : VHNotFoundException { }
    public class VHNotFoundOFXParameterException : VHNotFoundException { }
    public class VHNotFoundJimakuPrefixException : VHNotFoundException { }
    public class VHNotFoundDockerViewException : VHNotFoundException { }
    public class VHAlreadyExistedMediaBinException: VHAlreadyFoundException { }
    public class VHNotFoundMediaBinException : VHNotFoundException { }
    public class VHNoMediaException: VHNotFoundException { }
    public class VHNoMediaFilesException : VHNotFoundException { }
}
