using AutoMapper;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService
    {
        PersonRepository db;
        public PersonService()
        {
            Mapper.CreateMap<PersonServiceModel, Person>();
            Mapper.CreateMap<Person, PersonServiceModel>();
            Mapper.CreateMap<Phone, PhoneServiceModel>();
            Mapper.CreateMap<PhoneServiceModel, Phone>();

            Mapper.CreateMap<Address, AddressServiceModel>();
            Mapper.CreateMap<AddressServiceModel, Address>();

            Mapper.CreateMap<Street, StreetServiceModel>();
            Mapper.CreateMap<StreetServiceModel, Street>();

            Mapper.CreateMap<City, CityServiceModel>();
            Mapper.CreateMap<CityServiceModel, City>();

            Mapper.CreateMap<Country, CountryServiceModel>();
            Mapper.CreateMap<CountryServiceModel, Country>();


            db = new PersonRepository();
        }
        public void Create(PersonServiceModel item)
        {
            db.Create(Mapper.Map<PersonServiceModel, Person>(item));
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public IEnumerable<PersonServiceModel> GetAllfromUserId(string user_id)
        {
            int id = Convert.ToInt16(user_id);
            IEnumerable<Person> p = db.GetAllfromUserId(user_id);
            IEnumerable< PersonServiceModel > ret = Mapper.Map<IEnumerable<Person>, List<PersonServiceModel>>(p);
            return ret;
        }

        public IEnumerable<PersonServiceModel> GetAll()
        {
            IEnumerable<Person> item = db.GetAll();
            return Mapper.Map<IEnumerable<Person>, List<PersonServiceModel>>(item);
        }

        public PersonServiceModel GetById(int id)
        {
            return (Mapper.Map<Person, PersonServiceModel>(db.GetById(id)));
        }

        public void Save()
        {
            db.Save();
        }

        public void Update(PersonServiceModel item)
        {
            db.Update(Mapper.Map<PersonServiceModel, Person>(item));
        }

    }
}
