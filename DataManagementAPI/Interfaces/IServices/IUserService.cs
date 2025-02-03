namespace DataManagementAPI.Interfaces.IServices;

public interface IUserService
{
    GenericResponse<List<ReadUserDataDto>> GetAllUsers();
    GenericResponse<ReadUserDataDto> GetUser(int userId);
    GenericResponse<string> CreateUser(CreateUserDto createUserDto);
    GenericResponse<string> UpdateUser(UpdateUserDto updateUserDto);
    GenericResponse<string> DeleteUser(int userId);
}
