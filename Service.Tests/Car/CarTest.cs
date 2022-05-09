using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Car;
using Domain.Dto.DatabaseEntities;
using Domain.Entity;

namespace Service.Tests.Car
{
    public class CarTest
    {
        public int IdCar { get; set; }
        public string CorCar { get; set; }
        public string MarcaCar { get; set; }
        public string ModeloCar { get; set; }
        public string PlacaCar { get; set; }
        public string MessageCar { get; set; }
        public bool SuccessCar { get; set; }

        public string CorCarAlterado { get; set; }
        public string MarcaCarAlterado { get; set; }
        public string ModeloCarAlterado { get; set; }
        public string PlacaCarAlterado { get; set; }

        public CarDto carDto;
        public CarCreateDto carCreateDto;
        public CarCreateResultDto carCreateResultDto;
        public CarUpdateDto carUpdateDto;
        public CarUpdateResultDto carUpdateResultDto;

        public List<CarEntity> listCarEntity = new();
        public IEnumerable<CarEntityDto> listCarEntityDto = Enumerable.Empty<CarEntityDto>();
        public GetMultipleCarResultDto getMultipleCarResultDto = new();
        public CarTest()
        {
            IdCar = Faker.RandomNumber.Next();
            CorCar = Faker.Name.First();
            MarcaCar = Faker.Name.FullName();
            ModeloCar = Faker.Name.Last();
            PlacaCar = Faker.Name.Middle();
            MessageCar = Faker.Address.City();
            SuccessCar = Faker.Boolean.Random();
            CorCarAlterado = Faker.Name.First();
            MarcaCarAlterado = Faker.Name.FullName();
            ModeloCarAlterado = Faker.Name.Last();
            PlacaCarAlterado = Faker.Name.Middle();

            for (int i = 0; i < 10; i++)
            {
                CarEntity entity = new()
                {
                    Id = Faker.RandomNumber.Next(),
                    Cor = Faker.Name.First(),
                    Marca = Faker.Name.FullName(),
                    Modelo = Faker.Name.Last(),
                    Placa = Faker.Name.Middle(),
                };

                listCarEntity.Add(entity);
            }

            listCarEntityDto = listCarEntity
                                .Select(car => new CarEntityDto(car))
                                .ToList();
            
            getMultipleCarResultDto = new()
            {
                Message = MessageCar,
                Success = SuccessCar,
                Cars = listCarEntityDto,
                Count = listCarEntity.Count,
            };

            carDto = new()
            {
                Id = IdCar,
                Cor = CorCar,
                Marca = MarcaCar,
                Modelo = ModeloCar,
                Placa = PlacaCar
            };

            carCreateDto = new()
            {
                Cor = CorCar,
                Marca = MarcaCar,
                Modelo = ModeloCar,
                Placa = PlacaCar
            };

            carCreateResultDto = new()
            {
                Message = MessageCar,
                Success = SuccessCar
            };

            carUpdateDto = new()
            {
                Cor = CorCarAlterado,
                Id = IdCar,
                Marca = MarcaCarAlterado,
                Modelo = ModeloCarAlterado,
                Placa = PlacaCarAlterado
            };

            carUpdateResultDto = new()
            {
                Message = MessageCar,
                Success = SuccessCar
            };
        }


    }
}