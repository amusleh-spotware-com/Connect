using Newtonsoft.Json;

namespace Connect.RESTful.Models
{
    public class Profile
    {
        #region Properties

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        #endregion Properties

        #region Methods

        public static bool operator !=(Profile obj1, Profile obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator ==(Profile obj1, Profile obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Profile))
            {
                return false;
            }

            return Equals((Profile)obj);
        }

        public bool Equals(Profile other) => other?.UserId == UserId && other.NickName.Equals(
            NickName, System.StringComparison.InvariantCultureIgnoreCase);

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 31) + UserId.GetHashCode();
            hash = !string.IsNullOrEmpty(NickName) ? (hash * 31) + NickName.GetHashCode() : hash;
            hash = !string.IsNullOrEmpty(Email) ? (hash * 31) + Email.GetHashCode() : hash;

            return hash;
        }

        #endregion Methods
    }
}