using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CityServiceModel
    {
        public int Id { get; set; }
        public string city { get; set; }
       
        public int country_Id { get; set; }

        public virtual CountryServiceModel country { get; set; }

        public virtual ICollection<StreetServiceModel> Streets { get; set; }
    }
}
