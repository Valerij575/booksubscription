using AutoMapper;
using BookSubscription.Application;
using BookSubscription.Domain.Entities;

namespace BookSubscription.Infrastructure.Mapping
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<RegistrationViewModel, AppUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
