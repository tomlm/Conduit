using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Conduit.ViewModel
{
    [ObservableObject]
    public partial class ToolViewModel 
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _repository;

        [ObservableProperty]
        private string _documentation;

        [ObservableProperty]
        private string _install;

        [ObservableProperty]
        private ObservableCollection<string>  _keywords = new ObservableCollection<string>();

        [ObservableProperty]
        private string _command;

        [ObservableProperty]
        private string _args;

        [ObservableProperty]
        private int _width = 80;

        [ObservableProperty]
        private int _height = 25;

        [ObservableProperty]
        private bool _resizable = true;
    }

}
