using System.ComponentModel;

namespace Connect.Oauth.Enums
{
    public enum Scope
    {
        None,

        [Description("trading")]
        Trading,

        [Description("accounts")]
        Accounts
    }
}