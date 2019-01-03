using Connect.Common;

namespace Connect.Trading.EventArgs
{
    public class ErrorEventArgs
    {
        public string Description { get; set; }

        public ErrorCode ErrorCode { get; set; }
    }
}