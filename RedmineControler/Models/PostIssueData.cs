using System;
using System.Runtime.Serialization;

namespace RedmineControler
{
    public class PostIssueData
    {
        [DataMember( Name = "issue" )]
        public PostIssue Issue { get; set; }
    }

    public class PostIssue
    {
        [DataMember( Name = "project_id" )]
        public int ProjectId { get; set; }

        [DataMember( Name = "tracker_id" )]
        public int TrackerId { get; set; }

        [DataMember( Name = "status_id" )]
        public int StatusId { get; set; }

        [DataMember( Name = "priority_id" )]
        public int PriorityId { get; set; }

        [DataMember( Name = "subject" )]
        public string Subject { get; set; }

        [DataMember( Name = "description" )]
        public string Description { get; set; }

        public PostIssue()
        {
            this.ProjectId = 0;
            this.TrackerId = -1;
            this.StatusId = -1;
            this.PriorityId = -1;
            this.Subject = "";
            this.Description = "";
        }

        public bool ShouldSerializeTrackerId() => this.TrackerId != -1;
        public bool ShouldSerializeStatusId() => this.StatusId != -1;
        public bool ShouldSerializePriorityId() => this.PriorityId != -1;
        public bool ShouldSerializeSubject() => this.Subject != "";
        public bool ShouldSerializeDescription() => this.Description != "";
    }
}
