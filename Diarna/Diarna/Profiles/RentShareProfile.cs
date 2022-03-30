using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Unit;
using Diarna.Data.Domain;
using Diarna.DTOs.RentShare;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class RentShareProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public RentShareProfile()
        {
            CreateMap<CreateRentSharesDto, TblShare>();
            CreateMap<TblShare, ReadRentSharesDto>()
                .ForMember(dest => dest.UserSharesName,
                opt => opt.MapFrom(src => src.UserShares.Name));
            CreateMap<ReadRentSharesDto, TblShare>();
        }
    }
}
