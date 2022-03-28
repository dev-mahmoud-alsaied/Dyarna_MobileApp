using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.RentUser;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class RentUserProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public RentUserProfile()
        {
            CreateMap<CreateRentUserDto, TblRentUser>();
            CreateMap<TblRentUser, ReadRentUserDto>();
            CreateMap<ReadRentUserDto, TblRentUser>();
        }
    }
}
