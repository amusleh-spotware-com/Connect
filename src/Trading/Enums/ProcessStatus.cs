namespace Connect.Trading
{
    public enum ProcessStatus
    {
        None,
        WaitingToRun,
        Running,
        WaitingToStop,
        Stopped,
        Error
    }
}