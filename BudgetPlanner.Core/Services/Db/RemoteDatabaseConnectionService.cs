using System;
using BudgetPlanner.Core.Models.CashFlows;
using Firebase.Database;
using Firebase.Database.Query;

namespace BudgetPlanner.Core.Services.Db
{
	public class RemoteDatabaseConnectionService:IRemoteDatabaseConnectionService
	{
        readonly private FirebaseClient _firebaseClient = new FirebaseClient("https://budgetplanner-7ec34-default-rtdb.europe-west1.firebasedatabase.app/");

        async Task<List<CashFlowDTO>> IRemoteDatabaseConnectionService.GetItems()
        {
            List<CashFlowDTO> items = new List<CashFlowDTO>();

            var data = await _firebaseClient.Child("cache_flow").OnceAsync<CashFlowDTO>();

            foreach(var item in data)
            {
                items.Add(item.Object);
            }

            return items;
        }

        void IRemoteDatabaseConnectionService.PostItem(CashFlowDTO cashFlowDTO)
        {
            _firebaseClient.Child("cache_flow").PostAsync<CashFlowDTO>(cashFlowDTO);
        }
    }
}

