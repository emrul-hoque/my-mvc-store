using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My.Mvc.Store.Data;
using My.Mvc.Store.Domain.Entities;
using My.Mvc.Store.Models;

namespace My.Mvc.Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductDbContext _productDbContext;
        public List<ProductModel> StoreProductModel { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, ProductDbContext productDbContext)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(productDbContext, nameof(productDbContext));

            _logger = logger;
            _productDbContext = productDbContext;

            _logger.LogInformation($"Instantiated {nameof(IndexModel)}");
        }

        public async Task OnGetAsync()
        {
            if (await _productDbContext.Products.AnyAsync())
            {
                List<Product> products = await _productDbContext.Products.Where(p => p.IsAvailable).ToListAsync();

                foreach (Product p in products)
                {
                    StoreProductModel.Add(p.ToModel());
                }
            }
        }
    }
}