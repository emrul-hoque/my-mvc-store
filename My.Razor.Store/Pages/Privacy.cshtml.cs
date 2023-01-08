using Microsoft.AspNetCore.Mvc.RazorPages;

namespace My.Razor.Store.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(PrivacyModel)} has been instantiated");
        }

        public void OnGet()
        {
        }
    }
}