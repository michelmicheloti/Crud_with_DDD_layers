using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Base;

namespace Domain.Dto.Car
{
    public class CarDto : ResultDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
    }
}