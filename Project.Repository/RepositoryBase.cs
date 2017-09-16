using Project.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        NorthwindEntities entities;
        public NorthwindEntities Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = new NorthwindEntities();
                }
                return entities;
            }
            set { entities = value; }
        }



        public IEnumerable<T> GetAllData()
        {
            return Entities.Set<T>().ToList();
        }

        public T GetDataById(object id)
        {
            return Entities.Set<T>().Find(id);
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> condition)
        {
            return Entities.Set<T>().Where(condition);
        }

        public T Add(T entity)
        {
            Entities.Set<T>().Add(entity);
            Entities.SaveChanges();
            entities = new NorthwindEntities();

            return entity;
        }
       
        public T Update(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
            Entities.SaveChanges();
            entities = new NorthwindEntities();
            return entity;
        }

        public void Delete(T entity)
        {
            Entities.Entry(entity).State = EntityState.Deleted;
            Entities.SaveChanges();
            entities = new NorthwindEntities();
        }
    }
}
