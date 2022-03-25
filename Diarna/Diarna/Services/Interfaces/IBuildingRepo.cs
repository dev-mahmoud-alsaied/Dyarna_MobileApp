using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IBuildingRepo
    {
        Task<IEnumerable<TblBuilding>> GetAllBuildings();
        Task<TblBuilding> GetBuildingById(int id);
        Task<TblBuilding> AddBuilding(TblBuilding tblBuilding);
        Task<TblBuilding> EditBuilding(TblBuilding tblBuilding);
        Task<bool> DeleteBuilding(int id);
    }
}
