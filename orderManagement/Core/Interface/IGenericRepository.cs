﻿using System.Collections.Generic;
using System.Threading.Tasks;
using orderManagement.Core.Specifications;
using orderManagement.Entities;

namespace orderManagement.Core.Interface
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}