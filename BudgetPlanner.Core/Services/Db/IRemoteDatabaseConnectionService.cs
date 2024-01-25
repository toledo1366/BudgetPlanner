using System;
using BudgetPlanner.Core.Models.CashFlows;

namespace BudgetPlanner.Core.Services.Db
{
	public interface IRemoteDatabaseConnectionService
	{
		Task<List<CashFlowDTO>> GetItems();
		void PostItem(CashFlowDTO cashFlowDTO);
	}
}

