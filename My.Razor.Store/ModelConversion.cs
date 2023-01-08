using My.Razor.Store.Domain.Entities;
using My.Razor.Store.Models;

namespace My.Razor.Store
{
    public static class ModelConversion
    {
        public static ProductModel ToModel(this Product product)
        {
            ArgumentNullException.ThrowIfNull(product, nameof(product));

            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
