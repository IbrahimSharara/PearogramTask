using Microsoft.EntityFrameworkCore;

namespace Pearogram.Repositoty
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PearogramContext db) : base(db)
        {
            Db = db;
        }
        public PearogramContext Db { get; }
        //#region Insert new Product
        //public async Task<int> Add(Product t)
        //{
        //    await Db.Products.AddAsync(t);
        //    return Db.SaveChanges();
        //}
        //#endregion
        //#region Delete Product
        //public int Delete(Product t)
        //{
        //    Db.Products.Remove(t);
        //    return Db.SaveChanges();
        //}
        //#endregion
        #region Get Products
        public async Task<Product> GetByName(string name)
        {
            Product product = await Db.Products.Where(p => p.productName == name).FirstOrDefaultAsync();
            return product;
        }
        //public async Task<Product> GetById(int id)
        //{
        //    var product = await Db.Products.SingleOrDefaultAsync(p => p.productId == id);
        //    return product;
        //}
        public override List<Product> GetAll()
        {
            return Db.Products.Include(n => n.Supplier).ToList();
        }
        #endregion
        #region update Product
        public async Task<int> Update(Product t)
        {
            Product old = await Db.Products.SingleOrDefaultAsync(p => p.productId == t.productId);
            old.SupplierID = t.SupplierID;
            old.productName = t.productName;
            old.QuentityPerUnit = t.QuentityPerUnit;
            old.ReorderLevel = t.ReorderLevel;
            old.unitInStock = t.unitInStock;
            old.UnitsInOrder = t.UnitsInOrder;
            return Db.SaveChanges();
        }
        #endregion
    }
}