using SignalR.EntityLayer.Abstract;

namespace SignalR.EntityLayer.Entities
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

    }
}
