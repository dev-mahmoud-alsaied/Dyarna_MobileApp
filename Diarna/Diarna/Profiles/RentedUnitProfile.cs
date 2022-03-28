using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Unit;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class RentedUnitProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public RentedUnitProfile()
        {
            CreateMap<CreateRentedUnitDto, TblRentedUnit>();
            CreateMap<TblRentedUnit, ReadRentedUnitDto>()
                .ForMember(dest => dest.UnitName,
                opt => opt.MapFrom(src => src.Unit.Name));
            CreateMap<ReadRentedUnitDto, TblRentedUnit>();
        }
    }
}
