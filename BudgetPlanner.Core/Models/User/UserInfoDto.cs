using BudgetPlanner.Core.Models.CashFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.Models.User
{
    public class UserInfoDto
    {
        public string UserName { get; set; }
        public List<CashFlowDTO> Items { get; set; }
    }
}
