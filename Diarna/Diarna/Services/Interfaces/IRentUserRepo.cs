using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IRentUserRepo
    {
        Task<IEnumerable<TblRentUser>> GetAllRentUsers();
        Task<TblRentUser> GetRentUserById(int id);
        Task<TblRentUser> GetRentUserByName(string name);
        Task<TblRentUser> GetRentUserByPhone(string phone);
        Task<TblRentUser> AddRentUser(TblRentUser tblRentUser);
        Task<TblRentUser> EditRentUser(TblRentUser tblRentUser);
        Task<bool> DeleteRentUser(int id);
    }
}
