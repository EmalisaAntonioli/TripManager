namespace TripManager.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; } //Guide
        //The following is nice for the many side, but can be omitted
        public List<Trip> Trips { get; set; }
    }
}
