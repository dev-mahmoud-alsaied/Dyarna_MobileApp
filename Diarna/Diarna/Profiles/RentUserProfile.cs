using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.RentUser;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class RentUserProfile : Profile
    {
        public RentUserProfile()
        {
            CreateMap<CreateRentUserDto, TblRentUser>();
            CreateMap<TblRentUser, ReadRentUserDto>();
            CreateMap<ReadRentUserDto, TblRentUser>();
        }
    }
}
