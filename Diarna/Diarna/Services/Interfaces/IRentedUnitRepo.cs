using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IRentedUnitRepo
    {
        Task<IEnumerable<TblRentedUnit>> GetAllRentedUnits();
        Task<TblRentedUnit> GetRentedUnitById(int id);
        Task<TblRentedUnit> AddRentedUnit(TblRentedUnit tblRentedUnit);
        Task<TblRentedUnit> EditRentedUnit(TblRentedUnit tblRentedUnit);
        Task<bool> DeleteRentedUnit(int id);
        Task<TblRentedUnit> CheckUnitExsist(int unitId);
    }
}
