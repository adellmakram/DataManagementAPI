namespace DataManagementAPI.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, ReadUserDataDto>()
            .ReverseMap();

        CreateMap<CreateUserDto, User>()
            .ReverseMap();

        CreateMap<UpdateUserDto, User>()
           .ReverseMap();
    }
}
