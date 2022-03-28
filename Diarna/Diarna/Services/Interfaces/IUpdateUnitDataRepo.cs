using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUpdateUnitDataRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblUnit> GetUnitDataById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblUnit"></param>
        /// <returns></returns>
        Task<TblUnit> EditUnitData(TblUnit tblUnit);
    }
}
