namespace Connect.Protobuf
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