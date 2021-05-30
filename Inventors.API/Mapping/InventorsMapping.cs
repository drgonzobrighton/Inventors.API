using AutoMapper;
using Inventors.API.Contracts.V1.Requests;
using Inventors.API.Contracts.V1.Responses;
using Inventors.API.Domain;

namespace Inventors.API.Mapping
{
    public class InventorsMapping : Profile
    {
        public InventorsMapping()
        {
            CreateMap<InventorRequest, Inventor>();
            CreateMap<Inventor, InventorResponse>();
        }
    }
}
