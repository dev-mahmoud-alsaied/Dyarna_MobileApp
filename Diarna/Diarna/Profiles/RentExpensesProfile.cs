using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class RentExpensesProfile : Profile
    {
        public RentExpensesProfile()
        {
            CreateMap<CreateRentExpensesDto, TblRentExpense>();
            CreateMap<TblRentExpense, ReadRentExpensesDto>()
                .ForMember(dest => dest.UnitName,
                opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.ItemName,
                opt => opt.MapFrom(src => src.Item.Name));
            CreateMap<ReadRentExpensesDto, TblRentExpense>();
        }
    }
}
