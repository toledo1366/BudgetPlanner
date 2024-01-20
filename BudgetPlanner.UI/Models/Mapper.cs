using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.Models
{
    public interface IMapper<D, M>
    {
        public M FromDto(D dto);
        public D ToDto(M model);
    }
}
