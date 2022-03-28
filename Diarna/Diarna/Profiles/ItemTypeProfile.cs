using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.ItemType;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemTypeProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemTypeProfile()
        {
            CreateMap<CreateItemTypeDto, TblItemType>();
            CreateMap<TblItemType, ReadItemTypeDto>();
            CreateMap<ReadItemTypeDto, TblItemType>();
        }
    }
}
