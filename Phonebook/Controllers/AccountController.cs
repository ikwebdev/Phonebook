using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Services;
using AutoMapper;

namespace Phonebook.Controllers
{
    public class AccountController : Controller
    {
        UserService userService = new UserService();

        public AccountController()
        {
            Mapper.CreateMap<UserViewModel, UserServiceModel>();
            Mapper.CreateMap<UserServiceModel, UserViewModel>();  
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.hasEntity(model.Name, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
           

                if (!userService.hasEntity(model.Name, model.Password))
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    userService.Create(Mapper.Map < UserViewModel, UserServiceModel > (new UserViewModel { Email = model.Name, Password = model.Password, Age = model.Age, Image = imageData }));
                    userService.Save();
                    // если пользователь удачно добавлен в бд
                    if (userService.hasEntity(model.Name, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}