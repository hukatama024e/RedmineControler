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
	class MainWindowViewModel
	{
        public ReactiveProperty<string> ResponceMessage { get; private set; } = new ReactiveProperty<string>();
        public ReactiveCollection<Project> RedmineProjects { get; private set; } = new ReactiveCollection<Project>();

        public ReactiveCommand ComboBoxCmd { get; private set; }
        public ReactiveCommand AddNewTicketCmd { get; private set; }

        public MainWindowViewModel()
		{
            this.ComboBoxCmd = new ReactiveCommand();
            this.ComboBoxCmd.Subscribe( _ => {
                this.ResponceMessage.Value = "";
                var issueData = RedMineApi.GetIssueAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey, ProjectIdSetting.Instance.Id.Value ).Result;

                foreach( var issue in issueData.Issues ) {
                    this.ResponceMessage.Value += $"#{issue.Id} {issue.Subject} Status={issue.Status.Name}\r\n";
                }
            } );

            this.AddNewTicketCmd = new ReactiveCommand();
            this.AddNewTicketCmd.Subscribe( _ => {
                var newTicketDialog = new NewTicketDialog();
                newTicketDialog.ShowDialog();
            } );

            var projects = RedMineApi.GetProjectAsync( UserData.Instance.RedmineData.Url, UserData.Instance.RedmineData.ApiKey ).Result;
            foreach( var proj in projects.Project ) {
                this.RedmineProjects.Add( proj );
            }

            ProjectIdSetting.Instance.Id.Value = 1;
        }
	}
}
