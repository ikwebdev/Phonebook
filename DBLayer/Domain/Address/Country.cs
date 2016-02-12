using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Country
    {
        public int Id { get; set; }
        public string country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
