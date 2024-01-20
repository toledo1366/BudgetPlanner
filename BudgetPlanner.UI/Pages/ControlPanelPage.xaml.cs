using BudgetPlanner.UI.ViewModels.ControlPanel;

namespace BudgetPlanner.UI.Pages;

public partial class ControlPanelPage : ContentPage
{
	public ControlPanelPage()
	{
		InitializeComponent();

		BindingContext = new ControlPanelViewModel();
	}
}