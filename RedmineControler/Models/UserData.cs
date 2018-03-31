using System.IO;
using Utf8Json;

namespace RedmineControler
{
    public class UserData
    {
        public static UserData Instance { get; } = new UserData();
        public RedmineSetting RedmineData { get; set; }

        private UserData()
        {
            this.RedmineData = JsonSerializer.Deserialize<RedmineSetting>( File.ReadAllBytes( "redmine_setting.json" ) );
        }
    }
}
