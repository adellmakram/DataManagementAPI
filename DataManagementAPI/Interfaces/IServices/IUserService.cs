namespace DataManagementAPI.Interfaces.IServices;

public interface IUserService
{
    GenericResponse<List<ReadUserDataDto>> GetAllUsers();
    GenericResponse<ReadUserDataDto> GetUser(int userId);
    GenericResponse<MessageResponse> CreateUser(CreateUserDto createUserDto);
    GenericResponse<MessageResponse> UpdateUser(UpdateUserDto updateUserDto);
    GenericResponse<MessageResponse> DeleteUser(int userId);
}
