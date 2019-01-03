using System.ComponentModel;

namespace Connect.Oauth
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