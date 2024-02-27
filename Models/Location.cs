namespace TripManager.Models
{
    public class Location
    {
        //PK
        public int ID { get; set; } // automatically becomes PK (also works for LocationID or LocationId)
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
