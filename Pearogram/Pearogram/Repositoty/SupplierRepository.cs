using Microsoft.EntityFrameworkCore;

namespace Pearogram.Repositoty
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(PearogramContext db) : base(db)
        {
            Db = db;
        }

        public PearogramContext Db { get; }
        //#region Insert new Supplier
        //public async Task<int> Add(Supplier s)
        //{
        //    await Db.Suppliers.AddAsync(s);
        //    return Db.SaveChanges();
        //}
        //#endregion
        //#region Delete Supplier
        //public int Delete(Supplier s)
        //{
        //    Db.Suppliers.Remove(s);
        //    return Db.SaveChanges();
        //}
        //#endregion
        #region Get Supplier
        public async Task<Supplier> GetByName(string name)
        {
            Supplier supplier = await Db.Suppliers.Where(p => p.SupplierName == name).FirstOrDefaultAsync();
            return supplier;
        }
        #endregion
        //public List<Supplier> GetAll()
        //{
        //    return Db.Suppliers.ToList();
        //}
        //public async Task<Supplier> GetById(int id)
        //{
        //    return await Db.Suppliers.SingleOrDefaultAsync(s => s.SupplierID == id);
        //}
        //#endregion
        #region update Product
        public async Task<int> Update(Supplier s)
        {
            Supplier old = await Db.Suppliers.Where(p => p.SupplierID == s.SupplierID).SingleOrDefaultAsync();
            old.SupplierName = s.SupplierName;
            return Db.SaveChanges();
        }
        #endregion
    }
}