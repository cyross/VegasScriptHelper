using System;

namespace VegasScriptHelper
{
    public class VegasHelperException : Exception { }
    public class VegasHelperNotFoundTrackException : VegasHelperException { }
    public class VegasHelperTrackUnselectedException : VegasHelperException { }
    public class VegasHelperNoneEventsException : VegasHelperException { }
    public class VegasHelperNoneSelectedEventException : VegasHelperException { }
    public class VegasHelperNotFoundOFXParameterException : VegasHelperException { }
    public class VegasHelperNotFoundJimakuPrefixException : VegasHelperException { }
    public class VegasHelperNotFoundDockerViewException : VegasHelperException { }
}
