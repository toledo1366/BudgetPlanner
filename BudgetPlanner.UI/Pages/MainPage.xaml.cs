using BudgetPlanner.UI.ViewModels.Main;

namespace BudgetPlanner.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }

}
