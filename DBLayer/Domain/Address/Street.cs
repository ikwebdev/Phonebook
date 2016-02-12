using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Street
    {
        public int Id { get; set; }

        public string street { get; set; }

        [ForeignKey("city")]
        public int city_Id { get; set; }

        public virtual City city { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}