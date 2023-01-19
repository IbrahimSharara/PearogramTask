namespace Pearogram.Repository
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task<Product> GetByName(string name);
        Task<int> Update(Product t);
        List<Product> GetAll();
      
    }
}
