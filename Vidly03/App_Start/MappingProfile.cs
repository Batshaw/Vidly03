using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly03.Dtos;
using Vidly03.Models;

namespace Vidly03.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDto>();//.ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customers>();
            Mapper.CreateMap<Movies, MovieDto>();//.ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movies>();
            Mapper.CreateMap<MembershipTypes, MembershipTypeDto>();
            Mapper.CreateMap<Genres, GenreDto>();
        }
    }
}