using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class PersonServiceModel
    {
        public  int Id { get; set; }

        public int User_Id { get; set; }
        public UserServiceModel user { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<PhoneServiceModel> Phones { get; set; }

        public virtual List<AddressServiceModel> Addresses { get; set; }

    }
}