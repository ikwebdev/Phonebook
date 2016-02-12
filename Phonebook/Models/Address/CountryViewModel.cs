using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string country { get; set; }

        public virtual ICollection<CityViewModel> Cities { get; set; }
    }
}
