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

        public ReactiveProperty<string> ProjectName { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<int> SelectedTrackerId { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> SelectedStatusId { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> SelectedPriorityId { get; set; } = new ReactiveProperty<int>();

        public ReactiveProperty<string> Subject { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Description { get; set; } = new ReactiveProperty<string>();

        public ReactiveCommand CreateTicketCmd { get; private set; }
        public ReactiveCommand CancelCmd { get; private set; }

        private Action CloseAction { get; set; }

        public NewTicketDialogViewModel( Action closeAction )
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

            this.CloseAction = closeAction;

            this.CreateTicketCmd = new ReactiveCommand();
            this.CreateTicketCmd.Subscribe( _ => {
                this.CreateNewTicket();
                this.CloseAction();
            } );

            this.CancelCmd = new ReactiveCommand();
            this.CancelCmd.Subscribe( _ => {
                this.CloseAction();
            } );

            var projects = RedMineApi.GetProjectAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey ).Result;
            var project = projects.Project.Where( proj => proj.Id == ProjectIdSetting.Instance.Id.Value ).First();
            this.ProjectName.Value = project.Name;
        }

        private void CreateNewTicket()
        {
            var newPostIssue = new PostIssue {
                ProjectId = ProjectIdSetting.Instance.Id.Value,
                StatusId = this.SelectedStatusId.Value,
                TrackerId = this.SelectedTrackerId.Value,
                PriorityId = this.SelectedPriorityId.Value,
                Subject = this.Subject.Value,
            };

            if( this.Description.Value != null ) {
                newPostIssue.Description = this.Description.Value;
            }

            var postIssueData = new PostIssueData {
                Issue = newPostIssue
            };

            var result = RedMineApi.PostIssueAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey, postIssueData ).Result;
        }
    }
}
