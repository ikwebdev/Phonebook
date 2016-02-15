using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class PersonRepository : iRepository<Person>
    {
        UserContext _db = new UserContext();

        public void Create(Person item)
        {
         /*   List<Address> add_ins = new List<Address>();

            foreach (Address addr in item.Addresses)
            {
                Address ad = _db.Addresses.FirstOrDefault(
                      a => a.House == addr.House
                      && a.street.street == addr.street.street
                      && a.street.city.city == addr.street.city.city
                      && a.street.city.country.country == addr.street.city.country.country
                      );
                if (ad == null)
                {
                    ad = new Address() { street = new Street() { city = new City() { country = new Country() } } };
                    Country co = _db.Countries.FirstOrDefault(cou => cou.country == addr.street.city.country.country);
                    if (co != null)
                    {
                        ad.street.city.country = co;
                    }
                    else
                    {
                       
                        City ci = _db.Cities.FirstOrDefault(cit => cit.city == addr.street.city.city);
                        if (ci != null)
                        {
                            ad.street.city = ci; 
                        }
                        else
                        {                         
                            Street st = _db.Streets.FirstOrDefault(str => str.street == addr.street.street);
                            if (st != null)
                            {
                                ad.street = st;
                            }
                            else
                            {
                                ad.street = addr.street;
                            }
                            ad.street.city = addr.street.city;
                        }
                        ad.street.city.country = addr.street.city.country;
                    }
                } 

                add_ins.Add(ad);
            }
            item.Addresses = add_ins;*/
            _db.Persons.Add(item);
        }

        public void Delete(int id)
        {

            _db.Persons.Remove(GetById(id));
            _db.Phones.RemoveRange(_db.Phones.Where(p => p.Person_Id == id));
        }

        public Person Get(Func<Person, bool> predicate)
        {
            return _db.Persons.FirstOrDefault(predicate);
        }

        public IEnumerable<Person> GetPersons(string user_id, string country, string city, string street)
        {
             return GetAllfromUserId(user_id).Where(p => p.Addresses.Contains(_db.Addresses.Where(i => i.street.street == street).FirstOrDefault()));
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public IEnumerable<Person> GetAllfromUserId(string user_id)
        {
            int id = Convert.ToInt16(user_id);
            return _db.Persons.Where(x => x.User_Id == id).ToList();
        }

        public Person GetById(int id)
        {
            return _db.Persons.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Person item)
        {
            foreach (Phone ph in item.Phones)
            {
                if (ph.Id != 0)
                {
                    _db.Entry<Phone>(ph).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    ph.Person_Id = item.Id;
                    _db.Phones.Add(ph);
                }

            }

            foreach (Address ad in item.Addresses)
            {
                if (ad.Id != 0)
                {
                    _db.Entry<Address>(ad).State = System.Data.Entity.EntityState.Modified;
                    _db.Entry<Street>(ad.street).State = System.Data.Entity.EntityState.Modified;
                    _db.Entry<City>(ad.street.city).State = System.Data.Entity.EntityState.Modified;
                    _db.Entry<Country>(ad.street.city.country).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    _db.Addresses.Add(ad);
                }

            }
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
