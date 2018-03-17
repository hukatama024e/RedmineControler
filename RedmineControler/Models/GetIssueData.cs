using System;
using System.Runtime.Serialization;

namespace RedmineControler
{
    public class GetIssueData
    {
        [DataMember( Name = "issues" )]
        public Issue[] Issues { get; set; }

        [DataMember( Name = "total_count" )]
        public int TotalCount { get; set; }

        [DataMember( Name = "offset" )]
        public int Offset { get; set; }

        [DataMember( Name = "limit" )]
        public int Limit { get; set; }
    }

    public class Issue
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "project" )]
        public Project Project { get; set; }

        [DataMember( Name = "tracker" )]
        public Tracker Tracker { get; set; }

        [DataMember( Name = "status" )]
        public Status Status { get; set; }

        [DataMember( Name = "priority" )]
        public Priority Priority { get; set; }

        [DataMember( Name = "author" )]
        public Author Author { get; set; }

        [DataMember( Name = "assigned_to" )]
        public Assigned_To AssignedTo { get; set; }

        [DataMember( Name = "category" )]
        public Category Category { get; set; }

        [DataMember( Name = "subject" )]
        public string Subject { get; set; }

        [DataMember( Name = "description" )]
        public string Description { get; set; }

        [DataMember( Name = "start_date" )]
        public string StartDate { get; set; }

        [DataMember( Name = "done_ratio" )]
        public int DoneRatio { get; set; }

        [DataMember( Name = "created_on" )]
        public DateTime CreatedOn { get; set; }

        [DataMember( Name = "updated_on" )]
        public DateTime UpdatedOn { get; set; }

        [DataMember( Name = "parent" )]
        public Parent Parent { get; set; }
    }

    public class Tracker
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Status
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Priority
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Author
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Assigned_To
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Category
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }
    }

    public class Parent
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }
    }
}
