using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels
{
    internal partial class LoginViewModel:ObservableObject
    {
        [RelayCommand]
        public void BeginLogin()
        {
            Console.WriteLine("Logowanie rozpoczęte");
        }
    }
}
