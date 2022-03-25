using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.ItemType;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class ItemTypeProfile : Profile
    {
        public ItemTypeProfile()
        {
            CreateMap<CreateItemTypeDto, TblItemType>();
            CreateMap<TblItemType, ReadItemTypeDto>();
            CreateMap<ReadItemTypeDto, TblItemType>();
        }
    }
}
