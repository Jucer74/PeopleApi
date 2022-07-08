using AutoMapper;
using People.Api.Requests;
using People.Domain.Entities;

namespace People.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonRequest, Person>();
        }
    }
}
