using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TripManager.Models
{
    public class Trip
    {

        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        //FK relations, adding the FK property is not mandatory, but easier for the future
        [Display(Name = "The destination")]
        public Location Destination { get; set; }

        [Display(Name = "Destination")]
        public int DestinationID { get; set; }

        public Person Person { get; set; }

        [Display(Name = "Guide")]
        public int PersonID { get; set; }

    }
}
