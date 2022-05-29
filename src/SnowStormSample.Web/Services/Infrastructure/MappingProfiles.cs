using AutoMapper;
using SnowStormSample.Shared.Dto;
using SnowStormSample.Web.Data.Seminars;

namespace SnowStormSample.Web.Services.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Seminar, SeminarDto>();

            CreateMap<Atendee, AtendeeDto>();
        }
    }
}
