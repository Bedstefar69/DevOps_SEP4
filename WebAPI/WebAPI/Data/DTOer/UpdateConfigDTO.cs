namespace WebAPI.WebAPI.Data.DTOer;

public class UpdateConfigDTO
{
    public string Plant { get; set; }
    public double MinTemperature { get; set; }
    public double MaxTemperature { get; set; }
    public double MinHumidity { get; set; }
    public double MaxHumidity { get; set; }
    public int MinCo2 { get; set; }
    public int MaxCo2 { get; set; }
}