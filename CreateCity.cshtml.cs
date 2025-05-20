using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityManager.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string SubmittedCityName { get; private set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
            public string CityName { get; set; }
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            SubmittedCityName = Input.CityName;
        }
    }
}