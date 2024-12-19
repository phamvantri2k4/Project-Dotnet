using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace QLquanCafe.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly QLquanCafe.Data.DbContect _context;

        // Danh sách danh mục cho dropdown
        public SelectList Categories { get; set; } = default!;

        // Giá trị tìm kiếm
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // Lọc theo danh mục
        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        public IndexModel(QLquanCafe.Data.DbContect context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync(string? searchKeyword, int? categoryId)
        {
            // Truy vấn danh sách sản phẩm
            var products = _context.Products
                .Include(p => p.Category) // Bao gồm thông tin danh mục
                .AsQueryable();

            // Lấy danh sách danh mục cho dropdown
            var categories = await _context.Categorys.ToListAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                products = products.Where(p => p.Name.Contains(searchKeyword));
            }

            // Lọc theo danh mục
            if (categoryId.HasValue && categoryId.Value != 0) 
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            // Cập nhật danh sách sản phẩm sau khi lọc
            Product = await products.ToListAsync();
        }

    }
}