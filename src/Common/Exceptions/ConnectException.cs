using System;

namespace Connect.Common.Exceptions
{
    public class ConnectException : Exception
    {
        #region Fields

        private readonly ErrorCode _errorCode;

        #endregion Fields

        public ConnectException(string message) : base(message)
        {
        }

        public ConnectException(string message, ErrorCode errorCode) : base(message)
        {
            _errorCode = errorCode;
        }

        public ConnectException(string message, Exception innterException) : base(message, innterException)
        {
        }

        public ConnectException(string message, Exception innterException, ErrorCode errorCode) : base(message, innterException)
        {
            _errorCode = errorCode;
        }

        #region Properties

        public ErrorCode ErrorCode => _errorCode;

        #endregion Properties
    }
}