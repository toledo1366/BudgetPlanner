﻿using System;
using BudgetPlanner.Auth.Services;
using BudgetPlanner.Core.Models.CashFlows;
using Firebase.Database;
using Firebase.Database.Query;

namespace BudgetPlanner.Core.Services.Db
{
	public class RemoteDatabaseConnectionService:IRemoteDatabaseConnectionService
	{
        readonly private FirebaseClient _firebaseClient = new FirebaseClient("https://budgetplanner-7ec34-default-rtdb.europe-west1.firebasedatabase.app/");
        readonly private IAuthorizationService _authorizationService;

        public RemoteDatabaseConnectionService(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        async Task<List<CashFlowDTO>> IRemoteDatabaseConnectionService.GetItems()
        {
            List<CashFlowDTO> items = new List<CashFlowDTO>();
            string user = _authorizationService.Uid;

            var data = await _firebaseClient.Child($"{user}/cash_flow").OnceAsync<CashFlowDTO>();

            foreach(var item in data)
            {
                items.Add(item.Object);
            }

            return items;
        }

        void IRemoteDatabaseConnectionService.PostItem(CashFlowDTO cashFlowDTO)
        {
            string user = _authorizationService.Uid;

            _firebaseClient.Child($"{user}/cash_flow").PostAsync<CashFlowDTO>(cashFlowDTO);
        }
    }
}
