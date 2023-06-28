using System;

namespace WPF.FaxGuild.Exceptions
{
    public class OrderConflictException : Exception
    {
        public DAL.Models.Order ExistingOrder { get; }
        public DAL.Models.Order IncomingOrdder { get; }
        public OrderConflictException(DAL.Models.Order existingOrder, DAL.Models.Order incomingOrdder)
        {
            ExistingOrder = existingOrder;
            IncomingOrdder = incomingOrdder;
        }
    }
}
