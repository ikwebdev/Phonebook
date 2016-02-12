using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class UserRepository : iRepository<User>
    {
        UserContext _db = new UserContext();
        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Delete(int id)
        {

            _db.Users.Remove(GetById(id));
      
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.Find(id);
        }

        public User Get(Func<User, bool> predicate)
        {
            return _db.Users.FirstOrDefault(predicate);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }
    }
}
