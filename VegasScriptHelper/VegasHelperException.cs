using System;

namespace VegasScriptHelper
{
    public class VegasHelperException : Exception { }
    public class VegasHelperNotFoundException : VegasHelperException { }
    public class VegasHelperAlreadyFoundException : VegasHelperException { }
    public class VegasHelperNotFoundTrackException : VegasHelperNotFoundException { }
    public class VegasHelperTrackUnselectedException : VegasHelperException { }
    public class VegasHelperNoneEventsException : VegasHelperNotFoundException { }
    public class VegasHelperNoneSelectedEventException : VegasHelperNotFoundException { }
    public class VegasHelperNotFoundOFXParameterException : VegasHelperNotFoundException { }
    public class VegasHelperNotFoundJimakuPrefixException : VegasHelperNotFoundException { }
    public class VegasHelperNotFoundDockerViewException : VegasHelperNotFoundException { }
    public class VegasHelperAlreadyExistedMediaBinException: VegasHelperAlreadyFoundException { }
    public class VegasHelperNotFoundMediaBinException : VegasHelperNotFoundException { }
    public class VegasHelperNoMediaException: VegasHelperNotFoundException { }
    public class VegasHelperNoMediaFilesException : VegasHelperNotFoundException { }
}
