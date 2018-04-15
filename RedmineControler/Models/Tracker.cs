using System.Runtime.Serialization;

namespace RedmineControler
{
    public class Tracker
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }

        [DataMember( Name = "default_status" )]
        public IssueStatus DefaultStatus { get; set; }
    }
}
