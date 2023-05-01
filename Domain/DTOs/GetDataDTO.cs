namespace Domain.DTOs;

public class GetDataDTO
{
    public string? BodyContains { get; }

    public GetDataDTO(string? bodyContains)
    {
        BodyContains = bodyContains;
    }
}