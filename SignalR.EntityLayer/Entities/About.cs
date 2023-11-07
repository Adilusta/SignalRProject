using SignalR.EntityLayer.Abstract;

namespace SignalR.EntityLayer.Entities
{
    public class About : IEntity
    {
        public int AboutID { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
