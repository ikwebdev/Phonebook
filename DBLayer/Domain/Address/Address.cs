using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Address
    {
        public int Id { get; set; }

        public string House { get; set; }

        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        [ForeignKey("street")]
        public int Steeet_Id { get; set; }
        public virtual Street street { get; set; }

        public virtual ICollection<Person> persons { get; set; }
    }
}
