using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using Reactive.Bindings;
using System.Net.Http;
using Utf8Json;

namespace RedmineControler
{
	class NewTicketDialogViewModel
    {
        public ReactiveCollection<Tracker> RedmineTrackers { get; private set; } = new ReactiveCollection<Tracker>();
        public ReactiveCollection<IssueStatus> RedmineStatuses { get; private set; } = new ReactiveCollection<IssueStatus>();
        public ReactiveCollection<IssuePriority> RedminePriorities { get; private set; } = new ReactiveCollection<IssuePriority>();

        public ReactiveProperty<int> SelectedTrackerId { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> SelectedStatusId { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> SelectedPriorityId { get; set; } = new ReactiveProperty<int>();

        public NewTicketDialogViewModel()
		{
            var trackers = RedMineApi.GetTrackerAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey ).Result;
            foreach( var trac in trackers.Tracker ) {
                this.RedmineTrackers.Add( trac );
            }
            this.SelectedTrackerId.Value = trackers.Tracker[ 0 ].Id;

            var statuses = RedMineApi.GetIssueStatusAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey ).Result;
            foreach( var status in statuses.IssueStatus ) {
                this.RedmineStatuses.Add( status );
            }
            this.SelectedStatusId.Value = statuses.IssueStatus[ 0 ].Id;

            var priorities = RedMineApi.GetIssuePriorityAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey ).Result;
            foreach( var priority in priorities.IssuePriority ) {
                this.RedminePriorities.Add( priority );
            }
            this.SelectedPriorityId.Value = priorities.IssuePriority[ 0 ].Id;
        }
    }
}
