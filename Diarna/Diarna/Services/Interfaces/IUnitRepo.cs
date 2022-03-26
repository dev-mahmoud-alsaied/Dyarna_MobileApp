using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IUnitRepo
    {
        Task<IEnumerable<TblUnit>> GetAllUnits();
        Task<TblUnit> GetUnitById(int id);
        Task<TblUnit> GetUnitByName(string Name);
        Task<TblUnit> AddUnit(TblUnit tblUnit);
        Task<TblUnit> EditUnit(TblUnit tblUnit);
        Task<bool> DeleteUnit(int id);
    }
}
