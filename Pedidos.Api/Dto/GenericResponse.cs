using System.Text.Json.Serialization;

namespace Pedidos.Api.Dto;

public class GenericResponse<T>
{
    public GenericResponse(T msg)
    {
        Message = msg;
    }

    [JsonPropertyName("message")]
    public T Message { get; set; }
}