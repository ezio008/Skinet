using AutoMapper;
using Skinet.Core.DTOs;
using Skinet.Core.Entities;

namespace Skinet.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResponseDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductResponseDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
