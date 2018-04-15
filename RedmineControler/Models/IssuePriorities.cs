using System.Runtime.Serialization;

namespace RedmineControler
{
    public class IssuePriorities
    {
        [DataMember( Name = "issue_priorities" )]
        public IssuePriority[] IssuePriority { get; set; }
    }
}