using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    //[Owned]
    public class FullName

    {
        [MinLength(3, ErrorMessage = ">3"),
            MaxLength(25, ErrorMessage = "doit étre  <=25")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
