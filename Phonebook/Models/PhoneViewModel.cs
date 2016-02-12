using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class PhoneViewModel
    {
        public int Id { get; set; }

        public int Person_Id { get; set; }
        public string Mobile { get; set; }
        public string Type { get; set; }

        public PersonViewModel person { get; set; }
    }
}
