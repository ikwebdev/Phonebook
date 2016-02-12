using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PhoneServiceModel
    {
        public int Id { get; set; }

   
        public int Person_Id { get; set; }
        public string Mobile { get; set; }
        public string Type { get; set; }

        public PersonServiceModel person { get; set; }
    }
}
