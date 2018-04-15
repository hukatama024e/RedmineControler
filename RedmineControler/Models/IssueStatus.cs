using System.Runtime.Serialization;

namespace RedmineControler
{
    public class IssueStatus
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }

        [DataMember( Name = "is_default" )]
        public bool IsDefault { get; set; }

        [DataMember( Name = "is_closed" )]
        public bool IsClosed { get; set; }
    }
}
