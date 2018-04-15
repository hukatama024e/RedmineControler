using System.Runtime.Serialization;

namespace RedmineControler
{
    public class Trackers
    {
        [DataMember( Name = "trackers" )]
        public Tracker[] Tracker { get; set; }
    }
}
