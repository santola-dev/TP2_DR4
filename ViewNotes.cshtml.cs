using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace CityManager.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly string _filesDirectory;
        public List<string> NoteFiles { get; private set; } = new();
        public string SelectedContent { get; private set; }
        public string SelectedFile { get; private set; }

        public ViewNotesModel()
        {
            _filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
        }

        public void OnGet(string fileName)
        {
            if (!Directory.Exists(_filesDirectory))
            {
                Directory.CreateDirectory(_filesDirectory);
            }

            NoteFiles = Directory.GetFiles(_filesDirectory, "*.txt")
                                 .Select(Path.GetFileName)
                                 .ToList();

            if (!string.IsNullOrWhiteSpace(fileName) && NoteFiles.Contains(fileName))
            {
                var fullPath = Path.Combine(_filesDirectory, fileName);
                SelectedContent = System.IO.File.ReadAllText(fullPath);
                SelectedFile = fileName;
            }
        }
    }
}
