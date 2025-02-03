namespace DataManagementAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class UserManagementController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("GetAllUsers")]
    public ActionResult<List<ReadUserDataDto>> GetAllUsers()
    {
        GenericResponse<List<ReadUserDataDto>> response = _userService.GetAllUsers();
        if (response.Status == ResponseStatus.Fail)
            return BadRequest(response.ResponseText);

        return Ok(response.ResponseObject);
    }

    [HttpGet("GetUser")]
    public ActionResult<ReadUserDataDto> GetUser(int userId)
    {
        GenericResponse<ReadUserDataDto> response = _userService.GetUser(userId);
        if (response.Status == ResponseStatus.Fail)
            return BadRequest(response.ResponseText);

        return Ok(response.ResponseObject);
    }

    [HttpPost("CreateUser")]
    public ActionResult<string> CreateUser(CreateUserDto createUserDto)
    {
        GenericResponse<string> response = _userService.CreateUser(createUserDto);
        if (response.Status == ResponseStatus.Fail)
            return BadRequest(response.ResponseText);

        return Ok(response.ResponseText);
    }

    [HttpPost("UpdateUser")]
    public ActionResult<string> UpdateUser(UpdateUserDto updateUserDto)
    {
        GenericResponse<string> response = _userService.UpdateUser(updateUserDto);
        if (response.Status == ResponseStatus.Fail)
            return BadRequest(response.ResponseText);

        return Ok(response.ResponseText);
    }

    [HttpPost("DeleteUser")]
    public ActionResult<string> DeleteUser(int id)
    {
        GenericResponse<string> response = _userService.DeleteUser(id);
        if (response.Status == ResponseStatus.Fail)
            return BadRequest(response.ResponseText);

        return Ok(response.ResponseText);
    }
}
