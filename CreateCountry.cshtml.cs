using CityManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CityManager.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public Country CreatedCountry { get; private set; }

        public class InputModel
        {
            [Required]
            public string CountryName { get; set; }

            [Required]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (!string.IsNullOrWhiteSpace(Input.CountryName) &&
                !string.IsNullOrWhiteSpace(Input.CountryCode) &&
                char.ToUpperInvariant(Input.CountryName[0]) != char.ToUpperInvariant(Input.CountryCode[0]))
            {
                ModelState.AddModelError("Input.CountryCode",
                    "O código deve começar com a mesma letra que o nome do país.");
                return Page();
            }

            CreatedCountry = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            return Page();

        }
    }

    public class Country
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
