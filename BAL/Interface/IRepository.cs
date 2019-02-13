using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
