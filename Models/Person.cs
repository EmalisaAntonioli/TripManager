using System.ComponentModel.DataAnnotations.Schema;

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
        // This is created to easily show the full name
        // as there is no setter there will be no column in the db
        // NotMapped is not needed here but extra security to prevent a column
        [NotMapped]
        public string FullName
        {
            get
            { return $"{FirstName} {Name}"; }
        }
    }
}
