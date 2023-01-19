namespace Pearogram.Repository
{
    public interface ISupplierRepository:IGenericRepository<Supplier>
    {
        Task<Supplier> GetByName(string name);
        Task<int> Update(Supplier s);
    }
}
