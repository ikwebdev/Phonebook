using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string city { get; set; }

       
        public int country_Id { get; set; }

        public virtual CountryViewModel country { get; set; }

        public virtual ICollection<StreetViewModel> Streets { get; set; }
    }
}
