using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Services.OrderConflictValidators
{
    public interface IOrderConflictValidator
    {
        Task<Models.Order> GetConflictOrder(Models.Order order);
    }
}
