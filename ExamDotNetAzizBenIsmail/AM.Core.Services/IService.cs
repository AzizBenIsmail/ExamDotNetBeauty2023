using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T t);

        T Get(string id);
        T Get(int id);
        void Update(T t);

        void Delete(T t);
        IList<T> GetAll();
    }
}
