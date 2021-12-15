using AutoMapper;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeRequestDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequestDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Child, opt =>
               {
                   opt.MapFrom(src => src.SubChild);
               });
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
