using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Unit;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUnitDataProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public UpdateUnitDataProfile()
        {
            CreateMap<EditUpdateUnitDataDto, TblUnit>();
            CreateMap<TblUnit, ReadUpdateUnitDataDto>();
        }
    }
}
