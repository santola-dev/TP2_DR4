using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityManager.Models;

namespace CityManager.Pages.CountryManager
{
    public class CreateMultipleCountriesModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Inputs { get; set; }

        public List<Country> SubmittedCountries { get; private set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "O código é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; }
        }

        public void OnGet()
        {
            Inputs = new List<InputModel>();

            for (int i = 0; i < 5; i++)
                Inputs.Add(new InputModel());
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            SubmittedCountries = Inputs
                .Where(i => !string.IsNullOrWhiteSpace(i.CountryName) && !string.IsNullOrWhiteSpace(i.CountryCode))
                .Select(i => new Country
                {
                    CountryName = i.CountryName,
                    CountryCode = i.CountryCode
                })
                .ToList();
        }
    }
}
