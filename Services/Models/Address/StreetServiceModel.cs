using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StreetServiceModel
    {
        public int Id { get; set; }

        public string street { get; set; }

        public int city_Id { get; set; }

        public virtual CityServiceModel city { get; set; }

        public virtual ICollection<AddressServiceModel> Addresses { get; set; }
    }
}