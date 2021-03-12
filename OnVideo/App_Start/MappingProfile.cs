using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnVideo.Dtos;
using OnVideo.Models;

namespace OnVideo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}