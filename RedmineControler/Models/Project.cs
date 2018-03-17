using System;
using System.Runtime.Serialization;

namespace RedmineControler
{
    public class Project
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "name" )]
        public string Name { get; set; }

        [DataMember( Name = "identifier" )]
        public string Identifier { get; set; }

        [DataMember( Name = "description" )]
        public string Description { get; set; }

        [DataMember( Name = "created_on" )]
        public DateTime CreatedOn { get; set; }

        [DataMember( Name = "updated_on" )]
        public DateTime UpdateOn { get; set; }

        [DataMember( Name = "is_public" )]
        public bool IsPublic { get; set; }
    }
}
