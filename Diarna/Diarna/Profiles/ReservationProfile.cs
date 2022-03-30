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
            CreateMap<TblReservation, ReadReservationDto>();
            CreateMap<ReadReservationDto, TblReservation>();
            CreateMap<ReserveUnitDto, CreateReservationDto>();
        }
    }
}
