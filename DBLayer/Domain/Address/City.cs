using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class City
    {
        public int Id { get; set; }
        public string city { get; set; }

        [ForeignKey("country")]
        public int country_Id { get; set; }

        public virtual Country country { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}
