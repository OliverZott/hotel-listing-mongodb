
using Newtonsoft.Json;

namespace HotelListingAPI.Models;

public class ErrorModel
{
    public int? Code { get; set; }
    public string? Message { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public static class ErrorModels
{
    public static ErrorModel NotFoundError(string id) =>
        new()
        {
            Code = StatusCodes.Status404NotFound,
            Message = $"Element with id '{id}' not found",
            Description = "No further information :("
        };

    public static ErrorModel InternalServerError() =>
        new()
        {
            Code = StatusCodes.Status500InternalServerError,
            Message = "Internal server error",
            Description =
        "No further information"
        };
}