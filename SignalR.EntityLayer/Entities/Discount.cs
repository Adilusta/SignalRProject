using SignalR.EntityLayer.Abstract;

namespace SignalR.EntityLayer.Entities
{
    public class Discount : IEntity
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
