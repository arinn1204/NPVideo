using AutoMapper;

namespace Evo.WebApi.Tests.Helpers.Models.Mapper
{
    public static class CreateMapper
    {
        public static IMapper GetMapper()
        {
            return new AutoMapper.Mapper(new MapperConfiguration(cfg => { cfg.AddMaps(typeof(Program).Assembly); }));
        }
    }
}