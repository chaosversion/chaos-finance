﻿namespace ChaosFinance.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> RemoveAsync(T obj);
    }
}
