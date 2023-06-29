namespace WPF.FaxGuild.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly Models.Order _order;

        public string WorkplaceId => _order.WorkplaceId?.ToString();
        public string Name => _order.Name;
        public string Start => _order.Start.ToString("t");
        public string End => _order.End.ToString("t");

        public OrderViewModel(Models.Order order)
        {
            _order = order; 
        }
    }
}
