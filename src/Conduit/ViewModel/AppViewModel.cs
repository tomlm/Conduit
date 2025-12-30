using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Conduit.ViewModel
{
    [ObservableObject]
    public partial class AppViewModel 
    {
        [ObservableProperty]
        private string _theme;

    }
}
