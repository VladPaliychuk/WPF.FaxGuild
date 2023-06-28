using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.DAL.Models;

namespace WPF.FaxGuild.Services.OrderCreators
{
    public interface IOrderCreator
    {
        Task CreateOrder(DAL.Models.Order order);
    }
}
