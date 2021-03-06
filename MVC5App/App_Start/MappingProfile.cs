﻿using AutoMapper;
using MVC5App.DTOs;
using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDTO>();
            Mapper.CreateMap<MemberShipTypeDTO, MemberShipType>();

            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MovieDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}