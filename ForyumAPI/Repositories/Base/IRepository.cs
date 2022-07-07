using ApplicationCore.Models;

namespace ForyumAPI.Repositories.Base;

public interface IRepository<T>
{
    Task<T?> GetById(int id);
    Task<T> Insert(T obj);
    Task Update(T obj);
    Task Delete(int id);
}