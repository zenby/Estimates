using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IBaseRepository <T> where T:class
    {
        IEnumerable<T> GetAll();
        void Add(ref T item);
        void Delete(T item);
        void Update(T item);
    }
}
