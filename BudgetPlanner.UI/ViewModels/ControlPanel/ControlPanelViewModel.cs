using Android.Content;
using Android.Webkit;
using BudgetPlanner.UI.Models.CashFlows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.ControlPanel
{
    public partial class ControlPanelViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CashFlow> items;

        public ControlPanelViewModel() 
        {
            
        }

        [RelayCommand]
        private void AddEntity()
        {
            Console.WriteLine("Przycisk działa.");
        }
    }
}
