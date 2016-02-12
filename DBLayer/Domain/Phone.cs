using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Phone
    {
        public int Id { get; set; }

        [ForeignKey("person")]
        [Required]
        public int Person_Id { get; set; }
        public string Mobile { get; set; }
        public string Type { get; set; }

        public Person person { get; set; }
    }
}
