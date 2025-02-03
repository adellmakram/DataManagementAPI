namespace DataManagementAPI.Data.Dtos;

public class GenericResponse<T> where T : class
{
    public T ResponseObject { get; set; }
    public ResponseStatus Status { get; set; }
    public string ResponseText { get; set; }
}
