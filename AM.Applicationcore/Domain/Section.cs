using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Section
    {
        [Key]
        public int IdSection { get; set; }

        [Required(ErrorMessage = "name is required"), MinLength(1, ErrorMessage = "name should be at least 1 char")]
        public string Name { get; set; }
        public virtual IList<Seat>Seats { get; set; }

    }
}
