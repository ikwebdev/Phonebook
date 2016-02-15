using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        public string House { get; set; }

        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }

        public int Steeet_Id { get; set; }
        public virtual StreetViewModel street { get; set; }

        public virtual ICollection<PersonViewModel> persons { get; set; }
    }
}
