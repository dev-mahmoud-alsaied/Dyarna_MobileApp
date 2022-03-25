using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IUpdateUnitDataRepo
    {
        Task<TblUnit> GetUnitDataById(int id);
        Task<TblUnit> EditUnitData(TblUnit tblUnit);
    }
}
