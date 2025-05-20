using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CityManager.Pages
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; } = new()
        {
            "Rio", "S�o Paulo", "Bras�lia"
        };

        public void OnGet()
        {
        }
    }
}