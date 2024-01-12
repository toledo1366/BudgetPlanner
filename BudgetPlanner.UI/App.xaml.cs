using BudgetPlanner.UI.Pages;

namespace BudgetPlanner.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
