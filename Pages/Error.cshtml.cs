using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace TablExtractor.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorSource { get; set; }
        public string? StackTrace { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            if (ShowRequestId)
            {
                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionFeature != null)
                {
                    ErrorMessage = exceptionFeature.Error.Message;
                    ErrorSource = exceptionFeature.Error.Source;
                    StackTrace = exceptionFeature.Error.StackTrace;
                }
            }
        }
    }
}