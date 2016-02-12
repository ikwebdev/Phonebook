using AutoMapper;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        UserRepository db;
        public UserService()
        {
            Mapper.CreateMap<UserServiceModel, User>();
            Mapper.CreateMap<User, UserServiceModel>();
            Mapper.CreateMap<Func<UserServiceModel, bool>, Func<User, bool>>();

           
            db = new UserRepository();


        }
        public void Create(UserServiceModel item)
        {
            db.Create(Mapper.Map<UserServiceModel, User>(item));
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public IEnumerable<UserServiceModel> GetAll()
        {
            IEnumerable<User> item = db.GetAll();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserServiceModel>>(item);
        }

        public UserServiceModel GetById(int id)
        {
            return (Mapper.Map<User, UserServiceModel>(db.GetById(id)));
        }

        public void Save()
        {
            db.Save();
        }

        public void Update(UserServiceModel item)
        {
            db.Update(Mapper.Map<UserServiceModel, User>(item));
        }

        public UserServiceModel Get(Func<UserServiceModel, bool> predicate)
        {
            return Mapper.Map <User, UserServiceModel> (db.Get(Mapper.Map <Func<UserServiceModel, bool>, Func<User, bool>> (predicate)));
        }

        public bool hasEntity(string name, string password)
        {
            User us = db.Get(u => u.Email == name && u.Password == password);
            return us == null ? false : true;
        }

        public int getUserId(string name)
        {
            UserRepository user_rep = new UserRepository();
            int user_id = -1;
            User user = user_rep.Get(u => u.Email == name);
            if (user != null)
            {
                user_id = user.Id;
            }
            return user_id;
        }
    }
}
