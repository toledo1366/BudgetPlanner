using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Auth.Models
{
    public class UserInfo
    {
        public string? UserName { get; set; }
        public string? AccessToken {  get; set; }
        public string? RefreshToken { get; set; }
    }
}
