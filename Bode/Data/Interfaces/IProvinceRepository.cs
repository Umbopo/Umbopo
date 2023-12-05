using Bode.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bode.Data.Interfaces
{
    interface IProvinceRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<List<Province>> GetProvincesFull();
    }
}
