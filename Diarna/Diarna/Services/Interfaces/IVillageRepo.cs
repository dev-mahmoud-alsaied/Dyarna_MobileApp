using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IVillageRepo
    {
        Task<IEnumerable<TblVillage>> GetAllVillages();
        Task<TblVillage> GetVillageById(int id);
        Task<TblVillage> GetVillageByName(string name);
        Task<TblVillage> AddVillage(TblVillage tblVillage);
        Task<TblVillage> EditVillage(TblVillage tblVillage);
        Task<bool> DeleteVillage(int id);
    }
}
