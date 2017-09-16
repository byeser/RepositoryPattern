using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAllData();
        T GetDataById(object id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
