using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Seat
    {

        [Key]
        public int SeatId { get; set; }
        [Required(ErrorMessage = "name is required"), MinLength(1, ErrorMessage = "name should be at least 1 char")]
        public string Name { get; set; }
        public string SeatNumber { get; set; }

        [Range(1, 20)]
        public int Size { get; set; }
        public int SectionFK { get; set;}


        public int PlaneFK  { get; set; }

        [ForeignKey("PlaneFK")]
        public virtual Plane plane { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        
        public virtual Section Section { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }


    }
}
