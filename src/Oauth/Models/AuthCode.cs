using Connect.Common.Enums;

namespace Connect.Oauth.Models
{
    public class AuthCode
    {
        public AuthCode(string code, App app, Scope scope = Scope.Trading, Mode mode = Mode.Live)
        {
            Code = code;
            App = app;
            Scope = scope;
            Mode = mode;
        }

        #region Properties

        public string Code { get; }
        public App App { get; }
        public Scope Scope { get; }
        public Mode Mode { get; }

        #endregion Properties
    }
}