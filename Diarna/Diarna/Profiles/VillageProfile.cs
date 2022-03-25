using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class VillageProfile : Profile
    {
        public VillageProfile()
        {
            CreateMap<CreateVillageDto, TblVillage>();
            CreateMap<TblVillage, ReadVillageDto>();
            CreateMap<ReadVillageDto, TblVillage>();
        }
    }
}
