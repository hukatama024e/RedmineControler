using Reactive.Bindings;

namespace RedmineControler
{
    public class ProjectIdSetting
    {
        public static ProjectIdSetting Instance { get; } = new ProjectIdSetting();
        public ReactiveProperty<int> Id { get; set; } = new ReactiveProperty<int>();

        private ProjectIdSetting()
        {
        }
    }
}
