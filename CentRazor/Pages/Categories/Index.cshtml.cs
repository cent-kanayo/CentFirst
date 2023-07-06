using CentRazor.Data;
using CentRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CentRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DbConfig _db;
        public  List<Category> categoryList { get; set; }
        public IndexModel(DbConfig db)
        {
            _db = db;  
        }
        public void OnGet()
        {
            categoryList = _db.Categories.ToList();
        }
    }
}
