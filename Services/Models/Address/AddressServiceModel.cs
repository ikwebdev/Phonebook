using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AddressServiceModel
    {
        public int Id { get; set; }

        public string House { get; set; }

        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        public int Steeet_Id { get; set; }
        public virtual StreetServiceModel street { get; set; }

        public virtual ICollection<PersonServiceModel> persons { get; set; }
    }
}
