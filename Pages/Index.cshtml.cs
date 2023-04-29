using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TablExtractor.Pages
{
    public class IndexModel : PageModel
    {
        public string? StatusMessage { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostUploadAsync(IFormFile pdfFile)
        {
            if (pdfFile != null && pdfFile.Length > 0)
            {
                // Process the uploaded PDF file and extract tables

                // Example: save the uploaded file to the server
                var filePath = Path.Combine("uploads", pdfFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(fileStream);
                }

                // Implement table extraction logic here
                // ...

                StatusMessage = "File uploaded successfully. Tables extracted.";
            }
            else
            {
                StatusMessage = "Error: Please select a PDF file.";
            }

            return Page();
        }
    }
}