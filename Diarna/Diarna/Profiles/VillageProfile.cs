using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Village;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class VillageProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public VillageProfile()
        {
            CreateMap<CreateVillageDto, TblVillage>();
            CreateMap<TblVillage, ReadVillageDto>();
            CreateMap<ReadVillageDto, TblVillage>();
        }
    }
}
