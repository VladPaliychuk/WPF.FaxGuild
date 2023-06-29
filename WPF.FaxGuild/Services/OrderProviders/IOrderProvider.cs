using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Services.OrderProviders
{
    public interface IOrderProvider
    {
        Task<IEnumerable<Models.Order>> GetAllOrders();
    }
}
