using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Rerservation;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ReservationProfile()
        {
            CreateMap<CreateReservationDto, TblReservation>();
            CreateMap<TblReservation, ReadReservationDto>()
                .ForMember(dest => dest.RentUserName,
                opt => opt.MapFrom(src => src.RentUser.Name))
                .ForMember(dest => dest.UnitName,
                opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.Date.StartDate))
                .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.Date.EndDate));
            CreateMap<ReadReservationDto, TblReservation>();
            CreateMap<ReserveUnitDto, CreateReservationDto>();
        }
    }
}
