using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Rerservation;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationDto, TblReservation>();
            CreateMap<TblReservation, ReadReservationDto>();
            CreateMap<ReadReservationDto, TblReservation>();
        }
    }
}
