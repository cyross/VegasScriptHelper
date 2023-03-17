namespace VegasScriptHelper.Enums
{
    public enum EHTarget: int
    {
        Track = 0,
        TrackEvent = 1
    }

    public enum TrackEHs: int
    {
        CountChanged = 0,
        StateChanged = 1
    }

    public enum EventEHs: int
    {
        DataChanged = 0,
        CountChanged = 1,
        TimeChanged = 2,
        StateChanged = 3
    }
}
