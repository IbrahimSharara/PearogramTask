using Microsoft.EntityFrameworkCore;

namespace Pearogram.Repositoty
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public PearogramContext Db { get; }
        public GenericRepository(PearogramContext db)
        {
            Db = db;
        }
        #region Insert new Item
        public async Task<int> Add(T t)
        {
            await Db.Set<T>().AddAsync(t);
            return Db.SaveChanges();
        }
        #endregion
        #region Delete Item
        public int Delete(T t)
        {
            Db.Set<T>().Remove(t);
            return Db.SaveChanges();
        }
        #endregion
        #region Get Item
        public virtual List<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }
        public async Task<T> GetById(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }
        #endregion
        
    }
}
