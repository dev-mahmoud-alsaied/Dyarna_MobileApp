using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Unit;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<CreateUnitDto, TblUnit>();
            CreateMap<TblUnit, ReadUnitDto>();
            CreateMap<ReadUnitDto, TblUnit>();
        }
    }
}
