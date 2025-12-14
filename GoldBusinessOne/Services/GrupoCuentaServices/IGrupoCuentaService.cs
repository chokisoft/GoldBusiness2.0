using GoldBusiness.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldBusinessOne.Services.GrupoCuentaServices
{
    public interface IGrupoCuentaService
    {
        Task<List<GrupoCuenta>> GetAllAsync();
        Task<GrupoCuenta> GetByIdAsync(int id);
        Task CreateAsync(GrupoCuenta grupoCuenta);
        Task UpdateAsync(GrupoCuenta grupoCuenta);
        Task DeleteAsync(int id);
    }
}