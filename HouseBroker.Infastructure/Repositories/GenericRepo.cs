using HouseBroker.Infastructure.Data.DataDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HouseBroker.Infastructure.Repositories
{
    public class GenericRepo : IGenericRepo
    {
        private readonly HouseBrokerDbContext _context;
        public GenericRepo(HouseBrokerDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> ForUser) where T : class
        {
            return await this._context.Set<T>().Where(ForUser).ToListAsync();

        }
        public async Task<T> GetById<T>(Expression<Func<T, bool>> ForUser) where T : class
        {
            if (_context.Set<T>() == null)
            {
                throw new Exception("Not Found");
            }

            return await this._context.Set<T>().Where(ForUser).FirstOrDefaultAsync();
        }
        public async Task<T> AddInfo<T>(T tObj) where T : class
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }
            _context.Set<T>().Add(tObj);
            await _context.SaveChangesAsync();
            return tObj;
        }

        public async Task UpdateInfo<T>(T tObj) where T : class
        {
            if (_context.Set<T>() == null)
            {
                throw new Exception("Bad Request");
            }
            _context.Set<T>().Update(tObj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInfo<T>(T tObj) where T : class
        {
            if (_context.Set<T>() == null)
            {
                throw new Exception("Bad Request");
            }
            _context.Set<T>().Remove(tObj);
            await _context.SaveChangesAsync();
        }

    }
}
