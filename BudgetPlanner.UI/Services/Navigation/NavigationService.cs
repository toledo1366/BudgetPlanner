using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        readonly IServiceProvider _serviceProvider;

        protected INavigation Navigation {
            get
            {
                INavigation navigation = Application.Current?.MainPage?.Navigation;

                return navigation is not null ? navigation : throw new NullReferenceException();
            } 
        }

        public NavigationService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task Navigate<T>()
        {
            Task navigation = null;

            try
            {
                var page = _serviceProvider.GetService<T>() as Page;

                if (page is not null)
                {
                    navigation =  Navigation.PushAsync(page, true);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);  //TODO Change it to some Logger service later.
            }

            return navigation;
        }
    }
}
