namespace HotelAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        T Get(K key);
        ICollection<T> GetAll();
        bool Add(T item);
        T Delete(K key);
        bool Update(T item);    
    }
}
