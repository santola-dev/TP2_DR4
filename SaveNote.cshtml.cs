using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TP2_DR4.Pages
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string SavedFileName { get; private set; }
        public string SavedFilePath => $"/files/{SavedFileName}";

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo da nota é obrigatório.")]
            public string Content { get; set; }
        }

        public void OnGet()
        { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            
            var timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            SavedFileName = $"note-{timestamp}.txt";
            var fullPath = Path.Combine(folderPath, SavedFileName);
            
            await System.IO.File.WriteAllTextAsync(fullPath, Input.Content);

            return Page();
        }
    }
}
