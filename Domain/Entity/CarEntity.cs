namespace Domain.Entity;

public class CarEntity : BaseEntity
{
    public string Cor { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
}
