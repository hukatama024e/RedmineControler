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
        public ReactiveProperty<int> SelectedProjectId { get; set; } = new ReactiveProperty<int>();
        public ReactiveCollection<Project> RedmineProjects { get; private set; } = new ReactiveCollection<Project>();

        public ReactiveCommand ComboBoxCmd { get; private set; }
        private UserData UserInfo { get; set; }

        public MainWindowViewModel()
		{
            this.UserInfo = JsonSerializer.Deserialize<UserData>( File.ReadAllBytes( "userInfo.json" ) );

            this.ComboBoxCmd = new ReactiveCommand();
            this.ComboBoxCmd.Subscribe( _ => {
                this.ResponceMessage.Value = "";
                var issueData = RedMineApi.GetIssueAsync( this.UserInfo.Url, this.UserInfo.ApiKey, this.SelectedProjectId.Value ).Result;

                foreach( var issue in issueData.Issues ) {
                    this.ResponceMessage.Value += $"#{issue.Id} {issue.Subject} Status={issue.Status.Name}\r\n";
                }
            } );

            var projects = RedMineApi.GetProjectAsync( this.UserInfo.Url, this.UserInfo.ApiKey ).Result;
            foreach( var proj in projects.Project ) {
                this.RedmineProjects.Add( proj );
            }

            this.SelectedProjectId.Value = 1;
        }
	}
}
