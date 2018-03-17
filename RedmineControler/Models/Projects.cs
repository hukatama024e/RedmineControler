using System;
using System.Runtime.Serialization;

namespace RedmineControler
{
    public class Projects
    {
        [DataMember( Name = "projects" )]
        public Project[] Project { get; set; }

        [DataMember( Name = "total_count" )]
        public int TotalCount { get; set; }

        [DataMember( Name = "offset" )]
        public int Offset { get; set; }

        [DataMember( Name = "limit" )]
        public int Limit { get; set; }
    }
}