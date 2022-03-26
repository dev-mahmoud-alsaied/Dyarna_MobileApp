using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Unit;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class UpdateUnitDataProfile : Profile
    {
        public UpdateUnitDataProfile()
        {
            CreateMap<EditUpdateUnitDataDto, TblUnit>();
            CreateMap<TblUnit, ReadUpdateUnitDataDto>();
        }
    }
}
