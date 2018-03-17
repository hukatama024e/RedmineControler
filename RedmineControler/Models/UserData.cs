using System.Runtime.Serialization;

namespace RedmineControler
{
    public class UserData
    {
        [DataMember( Name = "url" )]
        public string Url{ get; set; }

        [DataMember( Name = "api_key" )]
        public string ApiKey { get; set; }
    }
}
