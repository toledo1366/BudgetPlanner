﻿using BudgetPlanner.Core.Models.CashFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.Services
{
    public interface IGetExpensesService
    {
        List<CashFlowDTO> getItems();
    }
}