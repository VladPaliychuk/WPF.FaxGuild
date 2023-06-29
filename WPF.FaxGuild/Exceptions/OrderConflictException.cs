using System;

namespace WPF.FaxGuild.Exceptions
{
    public class OrderConflictException : Exception
    {
        public Models.Order ExistingOrder { get; }
        public Models.Order IncomingOrdder { get; }
        public OrderConflictException(Models.Order existingOrder, Models.Order incomingOrdder)
        {
            ExistingOrder = existingOrder;
            IncomingOrdder = incomingOrdder;
        }
    }
}
