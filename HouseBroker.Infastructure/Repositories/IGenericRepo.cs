using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Infastructure.Repositories
{
    public interface IGenericRepo
    {
        Task<List<T>> GetAll<T>(Expression<Func<T, bool>> ForUser) where T : class; 
        Task<T> GetById<T>(Expression<Func<T, bool>> ForUser) where T : class;
        Task<T> AddInfo<T>(T tObj) where T : class;
        Task UpdateInfo<T>(T tObj) where T : class;
        Task DeleteInfo<T>(T tObj) where T : class;
    }
}
