using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBLayer
{
    public class Person
    {
        [Key]
        public  int Id { get; set; }

        [ForeignKey("user")]
        [Required]
        public int User_Id { get; set; }
        public User user { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public virtual List<Address> Addresses { get; set; }

    }
}
