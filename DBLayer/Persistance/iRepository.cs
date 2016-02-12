using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public interface iRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Get(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
