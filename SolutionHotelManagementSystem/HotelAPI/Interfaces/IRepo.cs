namespace HotelAPI.Interfaces
{

    /// <summary>
    /// Interface which has all the CRUD Functionalities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public interface IRepo<T,K>
    {
        T Get(K key);
        ICollection<T> GetAll();
        bool Add(T item);
        T Delete(K key);
        bool Update(T item);    
    }
}
