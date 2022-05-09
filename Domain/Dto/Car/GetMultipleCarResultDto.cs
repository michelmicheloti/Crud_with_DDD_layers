using Domain.Dto.Base;
using Domain.Dto.DatabaseEntities;

namespace Domain.Dto.Car
{
    public class GetMultipleCarResultDto : ResultDto
    {
        public int Count { get; set; }
        public IEnumerable<CarEntityDto>? Cars { get; set; }
    }
}
