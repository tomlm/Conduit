using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Conduit.ViewModel
{
    [ObservableObject]
    public partial class ConsoleAppViewModel 
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _repository;

        [ObservableProperty]
        private string _help;

        [ObservableProperty]
        private ObservableCollection<string>  _keywords = new ObservableCollection<string>();

        [ObservableProperty]
        private string _cmd;

        [ObservableProperty]
        private string _args;

        [ObservableProperty]
        private WindowStartLocation _startLocation;

        [ObservableProperty]
        private int _width;

        [ObservableProperty]
        private int _height;
    }
}
