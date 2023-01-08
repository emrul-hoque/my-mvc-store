using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My.Razor.Store.Data;
using My.Razor.Store.Domain.Entities;

namespace My.Razor.Store.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductDbContext _context;

        public DeleteModel(ProductDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            Product? product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                Product = product;
                _ = _context.Products.Remove(Product);
                _ = await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
