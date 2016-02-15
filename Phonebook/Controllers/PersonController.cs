using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Services;
using Phonebook.Models;
using AutoMapper;

namespace Phonebook.Controllers
{
    public class PersonController : Controller
    {
        PersonService personService = new PersonService();
        UserService userService = new UserService();

        public PersonController()
        {
            Mapper.CreateMap<PersonServiceModel, PersonViewModel>();
            Mapper.CreateMap<PersonViewModel, PersonServiceModel>();

            Mapper.CreateMap<PhoneViewModel, PhoneServiceModel>();
            Mapper.CreateMap<PhoneServiceModel, PhoneViewModel>();

            Mapper.CreateMap<AddressViewModel, AddressServiceModel>();
            Mapper.CreateMap<AddressServiceModel, AddressViewModel>();

            Mapper.CreateMap<StreetViewModel, StreetServiceModel>();
            Mapper.CreateMap<StreetServiceModel, StreetViewModel>();

            Mapper.CreateMap<CityViewModel, CityServiceModel>();
            Mapper.CreateMap<CityServiceModel, CityViewModel>();

            Mapper.CreateMap<CountryViewModel, CountryServiceModel>();
            Mapper.CreateMap<CountryServiceModel, CountryViewModel>();

        }
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllPersons()
        {    
            string user_id = getUserId().ToString();
            IEnumerable<PersonViewModel> p = Mapper.Map<  IEnumerable< PersonServiceModel >,List<PersonViewModel>> (personService.GetAllfromUserId(user_id));
            return View(p);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(PersonViewModel person)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = getUserId().ToString();
                person.User_Id = Convert.ToInt16(user_id);
                personService.Create(Mapper.Map<PersonViewModel, PersonServiceModel>( person));
                personService.Save();
                IEnumerable<PersonViewModel> p = Mapper.Map<IEnumerable<PersonServiceModel>, IEnumerable<PersonViewModel>>(personService.GetAllfromUserId(user_id));
                return RedirectToAction("AllPersons", p);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        
        public ActionResult EditPerson(int id)
        {

            return View(Mapper.Map<PersonServiceModel, PersonViewModel>( personService.GetById(id)));
        }

     
        [HttpPost]
        public string EditPerson(PersonViewModel person)
        {
            string user_id = getUserId().ToString();
            person.User_Id = Convert.ToInt16(user_id);
            personService.Update(Mapper.Map<PersonViewModel, PersonServiceModel> (person));
            personService.Save();
            return "Saved!";
        }

        public ActionResult DeletePerson(int id)
        {
            personService.Delete(id);
            personService.Save();
            string user_id = getUserId().ToString();
            IEnumerable<PersonViewModel> p = Mapper.Map<IEnumerable<PersonServiceModel>, List<PersonViewModel>>(personService.GetAllfromUserId(user_id));
            return RedirectToAction("AllPersons", p);
        }
        
        public int getUserId()
        {
            return userService.getUserId(User.Identity.Name);
        }

        public ActionResult EditAjax(int id)
        {
            return PartialView("EditPerson", Mapper.Map<PersonServiceModel, PersonViewModel>(personService.GetById(id)));
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(double latitude, double longtitude)
        {
            string user_id = getUserId().ToString();
            IEnumerable<PersonServiceModel> pers = personService.GetAllfromUserId(user_id);
            pers = pers.Where(
                a => a.Addresses.Where(
                    r => r.Latitude >= latitude - 0.05 && r.Latitude <= latitude + 0.05 && r.Longtitude >= longtitude - 0.05 && r.Longtitude <= longtitude + 0.05
                ).Any());

            if (pers.Count() > 0)
            {
                IEnumerable<PersonViewModel> p = Mapper.Map<IEnumerable<PersonServiceModel>, List<PersonViewModel>>(pers);
                return PartialView("AllPersonsSearch", p);
            }
            else
            {
                ViewBag.Message = "Nothing found!";
                return PartialView("Error");
            }
            
        }
    }
}
