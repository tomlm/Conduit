using CommunityToolkit.Mvvm.ComponentModel;

namespace Conduit.ViewModel
{
    public partial class AppViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _theme;

        public ToolsViewModel Tools { get; init; }

        public AppViewModel()
        {
            Tools = new ToolsViewModel();
            Theme = "Light";
        }

    }
}
