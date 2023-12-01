using AutoMapper;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DistributedServices.Models.Models.Categories;
using MonefyWeb.DistributedServices.Models.Models.Movements;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;

namespace MonefyWeb.Transversal.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountBe, AccountDto>().ReverseMap();

            CreateMap<AccountDm, AccountBe>().ReverseMap();
            CreateMap<AccountBe, AccountDm>();

            CreateMap<MovementBe, AccountMovementDto>().ReverseMap();

            CreateMap<MovementDm, MovementBe>().ReverseMap();

            CreateMap<MovementRequestDto, AccountMovementDto>().ReverseMap();

            CreateMap<MovementDm, MovementBe>().ReverseMap();

            CreateMap<MovementBe, MovementRequestDto>().ReverseMap();

            CreateMap<UserBe, UserDto>().ReverseMap();

            CreateMap<UserDm, UserBe>().ReverseMap();

            CreateMap<UserLoginResponseDto, UserLoginResponseBe>().ReverseMap();

            CreateMap<UserDataResponseDto, UserDataResponseBe>().ReverseMap();

            CreateMap<UserRegisterResponseDto, UserRegisterResponseBe>().ReverseMap();

            CreateMap<CategoryDto, CategoryBe>().ReverseMap();

            CreateMap<CategoryBe, CategoryDm>().ReverseMap();

            CreateMap<AccountConfigurationDto, AccountConfigurationBe>().ReverseMap();

            CreateMap<AccountConfigurationBe, AccountConfigurationDm>().ReverseMap();

            CreateMap<MovementDetailDto, MovementDetailBe>().ReverseMap();

            CreateMap<MovementDetailBe, MovementDetailDm>().ReverseMap();
        }
    }
}