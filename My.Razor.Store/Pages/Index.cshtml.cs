using Microsoft.AspNetCore.Mvc.RazorPages;

namespace My.Razor.Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));

            _logger = logger;
            _logger.LogInformation($"Instantiated {nameof(IndexModel)}");
        }
    }
}