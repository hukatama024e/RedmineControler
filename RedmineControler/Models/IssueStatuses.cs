using System.Runtime.Serialization;

namespace RedmineControler
{
    public class IssueStatuses
    {
        [DataMember( Name = "issue_statuses" )]
        public IssueStatus[] IssueStatus { get; set; }
    }
}