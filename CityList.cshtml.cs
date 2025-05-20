using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CityManager.Pages
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; } = new()
        {
            "Rio", "São Paulo", "Brasília"
        };

        public void OnGet()
        {
        }
    }
}