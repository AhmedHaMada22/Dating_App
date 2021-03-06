using AutoMapper;
using Dating_App.DTOs;
using Dating_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo, PhotoDto>();
        }
       
    }
}
