using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.DAL.Models
{
    public class Order
    {
        public Order(WorkplaceId workplaceId, string name, DateTime start, DateTime end)
        {
            WorkplaceId = workplaceId;
            Start = start;
            End = end;
            Name = name;
        }

        public WorkplaceId WorkplaceId { get; }
        public string Name { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeSpan Length => End.Subtract(Start);


        public bool Conflicts(Order order)
        {
            if (order.WorkplaceId != WorkplaceId) { return false; }

            return order.Start < order.End && order.End > order.Start;
        }
    }
}
