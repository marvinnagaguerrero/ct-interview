using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Ct.Interview.Web.Api.Profiles
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AsxListedCompanyResponse, AsxListedCompany>()
                 .ForMember(dest => dest.AsxCode, opt => opt.MapFrom(src => src.AsxCode))
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                 .ForMember(dest => dest.GicsIndustryGroup, opt => opt.Ignore())
                 ;
        }

    }
}
