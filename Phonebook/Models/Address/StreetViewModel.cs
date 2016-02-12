using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class StreetViewModel
    {
        public int Id { get; set; }

        public string street { get; set; }

  
        public int city_Id { get; set; }

        public virtual CityViewModel city { get; set; }

        public virtual ICollection<AddressViewModel> Addresses { get; set; }
    }
}