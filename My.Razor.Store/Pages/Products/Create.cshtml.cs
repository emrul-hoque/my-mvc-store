using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Razor.Store.Data;
using My.Razor.Store.Domain.Entities;

namespace My.Razor.Store.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductDbContext _context;

        public CreateModel(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            _ = _context.Products.Add(Product);
            _ = await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
