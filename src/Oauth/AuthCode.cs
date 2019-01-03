using Connect.Common;

namespace Connect.Oauth
{
    public class AuthCode
    {
        #region Constructor

        public AuthCode(string code, App app, Scope scope = Scope.Trading, Mode mode = Mode.Live)
        {
            Code = code;
            App = app;
            Scope = scope;
            Mode = mode;
        }

        #endregion Constructor

        #region Properties

        public string Code { get; private set; }
        public App App { get; private set; }
        public Scope Scope { get; private set; }
        public Mode Mode { get; private set; }

        #endregion Properties
    }
}