namespace Pearogram.Repository
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T t);
        int Delete(T t);
    }
}
