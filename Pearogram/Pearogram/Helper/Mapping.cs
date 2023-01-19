using AutoMapper;

namespace Pearogram.Helper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
