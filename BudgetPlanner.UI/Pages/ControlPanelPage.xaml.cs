using BudgetPlanner.UI.ViewModels.ControlPanel;

namespace BudgetPlanner.UI.Pages;

public partial class ControlPanelPage : ContentPage
{
	public ControlPanelPage(ControlPanelViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}