using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Services.OrderCreators
{
    public interface IOrderCreator
    {
        Task CreateOrder(Models.Order order);
    }
}
