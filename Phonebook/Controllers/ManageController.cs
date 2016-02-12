using AutoMapper;
using Phonebook.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.Controllers
{
    public class ManageController : Controller
    {
        public ManageController()
        {
            Mapper.CreateMap<UserViewModel, UserServiceModel>();
            Mapper.CreateMap<UserServiceModel, UserViewModel>();
        }

        UserService userService = new UserService();
        // GET: Manage
        public ActionResult Index()
        {
            return View(Mapper.Map<UserServiceModel, UserViewModel>(userService.GetById(getUserId())));
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user, HttpPostedFileBase uploadImage)
        {
            if(uploadImage!=null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                user.Image = imageData;
            }

            userService.Update(Mapper.Map<UserViewModel, UserServiceModel>(user));
            userService.Save();
            return View(Mapper.Map<UserServiceModel, UserViewModel>(userService.GetById(getUserId())));
        }



        public int getUserId()
        {
            return userService.getUserId(User.Identity.Name);
        }
    }
}