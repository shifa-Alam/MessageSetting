using MessageSetting.Core.Repositories.Base;
using MessageSetting.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MessageSettingDbContext _messageSettingDbContext;

        public Repository(MessageSettingDbContext messageSettingDbContext)
        {
            _messageSettingDbContext = messageSettingDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _messageSettingDbContext.Set<T>().AddAsync(entity);
            //await _messageSettingDbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _messageSettingDbContext.Set<T>().Remove(entity);
            await _messageSettingDbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _messageSettingDbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _messageSettingDbContext.Set<T>().FindAsync(id);
        }

       

        public async Task UpdateAsync(T entity)
        {
             _messageSettingDbContext.Set<T>().Update(entity);
            await _messageSettingDbContext.SaveChangesAsync();

        }
        public async Task SaveChanges()
        {
            await _messageSettingDbContext.SaveChangesAsync();
        }
    }
}
