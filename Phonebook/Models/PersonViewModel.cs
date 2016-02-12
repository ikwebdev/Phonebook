using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class PersonViewModel
    {
        public  int Id { get; set; }


        public int User_Id { get; set; }
        public UserViewModel user { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<PhoneViewModel> Phones { get; set; }

        public virtual List<AddressViewModel> Addresses { get; set; }

    }
}
