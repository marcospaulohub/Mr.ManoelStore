namespace Mr.ManoelStore.Repositories
{
    public interface IRepository<T>
    {
        int Insert(T item);
        void Update(T item);
        void Delete(T item);
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
