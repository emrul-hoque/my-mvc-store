using My.Mvc.Store.Domain.Entities;
using My.Mvc.Store.Models;

namespace My.Mvc.Store
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
