using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.ReservationDate;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationDateProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ReservationDateProfile()
        {
            CreateMap<CreateReservationDateDto, TblReservationDate>();
            CreateMap<TblReservationDate, ReadReservationDateDto>();
            CreateMap<ReadReservationDateDto, TblReservationDate>();
        }
    }
}
