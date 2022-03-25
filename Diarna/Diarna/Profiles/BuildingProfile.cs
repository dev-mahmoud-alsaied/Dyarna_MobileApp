using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<CreateBuildingDto, TblBuilding>();
            CreateMap<TblBuilding, ReadBuildingDto>();
            CreateMap<ReadBuildingDto, TblBuilding>();
        }
    }
}
