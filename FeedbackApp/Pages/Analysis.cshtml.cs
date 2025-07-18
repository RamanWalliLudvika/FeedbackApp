using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FeedbackApp.Pages
{
    public class AnalysisModel : PageModel
    {
        private readonly ILogger<AnalysisModel> _logger;

        public AnalysisModel(ILogger<AnalysisModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
