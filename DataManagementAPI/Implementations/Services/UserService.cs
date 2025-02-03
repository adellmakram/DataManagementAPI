namespace DataManagementAPI.Implementations.Services;

public class UserService(IUserRepo userRepository, IMapper mapper) : IUserService
{
    private readonly IUserRepo _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public GenericResponse<List<ReadUserDataDto>> GetAllUsers()
    {
        List<User> userModels = _userRepository.GetAllUsers();
        List<ReadUserDataDto> readUserDatas = _mapper.Map<List<ReadUserDataDto>>(userModels);

        return new()
        {
            ResponseObject = readUserDatas,
            Status = ResponseStatus.Success,
            ResponseText = "All Users Returned Successfully"
        };
    }
    public GenericResponse<ReadUserDataDto> GetUser(int userId)
    {
        if (userId <= 0)
            return new()
            {
                Status = ResponseStatus.Fail,
                ResponseText = "UserId Can't be less than or equals 0"
            };

        User? userModel = _userRepository.GetUserById(userId);
        if (userModel == null)
            return new()
            {
                Status = ResponseStatus.Fail,
                ResponseText = "User not found"
            };

        ReadUserDataDto readUserData = _mapper.Map<ReadUserDataDto>(userModel);

        return new()
        {
            ResponseObject = readUserData,
            Status = ResponseStatus.Success,
            ResponseText = "User Data Returned Successfully"
        };
    }
    public GenericResponse<MessageResponse> CreateUser(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        _userRepository.AddUser(user);

        return new()
        {
            Status = ResponseStatus.Success,
            ResponseObject = new() { Messgae = "User Created Successfully" }
        };
    }
    public GenericResponse<MessageResponse> UpdateUser(UpdateUserDto updateUserDto)
    {
        User user = _mapper.Map<User>(updateUserDto);

        User? existingUser = _userRepository.GetUserById(updateUserDto.UserId);
        if (existingUser == null)
            return new()
            {
                Status = ResponseStatus.Fail,
                ResponseText = "User not found"
            };

        user.UserName ??= existingUser.UserName;
        user.FirstName ??= existingUser.FirstName;
        user.LastName ??= existingUser.LastName;
        user.Password ??= existingUser.Password;

        _userRepository.UpdateUser(user);

        return new()
        {
            Status = ResponseStatus.Success,
            ResponseObject = new()
            {
                Messgae = "User Updated Successfully"
            }
        };
    }
    public GenericResponse<MessageResponse> DeleteUser(int userId)
    {
        _userRepository.DeleteUser(userId);

        return new()
        {
            Status = ResponseStatus.Success,
            ResponseObject = new()
            {
                Messgae = "User Deleted Successfully"
            }
        };
    }
}
