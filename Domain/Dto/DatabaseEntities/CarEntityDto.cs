using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Dto.DatabaseEntities
{
    public class CarEntityDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;

        public CarEntityDto(CarEntity entity)
        {
            if(entity != null){
                Id = entity.Id;
                Modelo = entity.Modelo;
                Cor = entity.Cor;
                Marca = entity.Marca;
                Placa = entity.Placa;
            }
        }
    }
}