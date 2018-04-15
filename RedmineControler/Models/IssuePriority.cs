using System.Runtime.Serialization;

namespace RedmineControler
{
    public class IssuePriority
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }

        [DataMember( Name = "is_default" )]
        public bool IsDefault { get; set; }
    }
}
