using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Implementations;
using Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Data.Tests.BaseTest;

namespace Data.Tests
{
    public class CarCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _service;

        public CarCrudComplete(DbTest dbTest)
        {
            _service = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "É Possivel Executar CRUD")]
        [Trait("Data", "Car Entity")]
        public async Task E_Possivel_Realizar_Crud_Car()
        {
            using DataContext? context = _service.GetService<DataContext>();

            if (context == null) { return; }

            CarImplementation _repository = new(context);
            CarEntity _entity = new()
            {
                Cor = Faker.Name.First(),
                Marca = Faker.Name.First(),
                Modelo = Faker.Name.First(),
                Placa = Faker.Name.First()
            };

            CarEntity? _createResult = await _repository.InsertAsync(_entity);
            Assert.NotNull(_createResult);
            Assert.Equal(_entity.Cor, _createResult.Cor);
            Assert.Equal(_entity.Marca, _createResult.Marca);
            Assert.Equal(_entity.Modelo, _createResult.Modelo);
            Assert.Equal(_entity.Placa, _createResult.Placa);

            _entity.Cor = Faker.Name.Last();
            _entity.Id = _createResult.Id;
            CarEntity? _updateResult = await _repository.UpdateAsync(_entity);
            Assert.NotNull(_updateResult);
            Assert.Equal(_entity.Cor, _updateResult?.Cor);
            Assert.Equal(_entity.Marca, _updateResult?.Marca);
            Assert.Equal(_entity.Modelo, _updateResult?.Modelo);
            Assert.Equal(_entity.Placa, _updateResult?.Placa);

            if (_updateResult == null) { return; }

            var _existResult = await _repository.ExistAsync(_updateResult.Id);
            Assert.True(_existResult);

            var _selectResult = await _repository.SelectAsync(_updateResult.Id);
            Assert.NotNull(_selectResult);
            Assert.Equal(_updateResult?.Cor, _selectResult?.Cor);
            Assert.Equal(_updateResult?.Marca, _selectResult?.Marca);
            Assert.Equal(_updateResult?.Modelo, _selectResult?.Modelo);
            Assert.Equal(_updateResult?.Placa, _selectResult?.Placa);

            var _selectAllResult = await _repository.SelectAsync();
            Assert.NotNull(_selectAllResult);
            Assert.True(_selectAllResult.Any());

            if (_selectResult == null) { return; }

            var _deleteResult = await _repository.DeleteAsync(_selectResult.Id);
            Assert.True(_deleteResult);
        }
    }
}