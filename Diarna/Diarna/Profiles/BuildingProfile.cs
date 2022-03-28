﻿using AutoMapper;
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
    public class BuildingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public BuildingProfile()
        {
            CreateMap<CreateReservationDto, TblBuilding>();
            CreateMap<TblBuilding, ReadReservationDto>();
            CreateMap<ReadReservationDto, TblBuilding>();
        }
    }
}
