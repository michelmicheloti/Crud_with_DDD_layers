using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Car
{
    public class CarUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Modelo { get; set; } = string.Empty;
        [Required]
        public string Cor { get; set; } = string.Empty;
        [Required]
        public string Marca { get; set; } = string.Empty;
        [Required]
        public string Placa { get; set; } = string.Empty;
    }
}
