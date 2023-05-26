namespace RoomsAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        ICollection<T> GetAll();
        T Get(K key);
        T Add(T item);
        T Delete(K key);
        bool Update(T item);

    }
}
