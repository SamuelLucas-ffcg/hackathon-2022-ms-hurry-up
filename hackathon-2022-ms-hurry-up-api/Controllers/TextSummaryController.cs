using hackathon_2022_ms_hurry_up_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_2022_ms_hurry_up_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextSummaryController : ControllerBase
    {
        
        private readonly ILogger<TextSummaryController> _logger;

        public TextSummaryController(ILogger<TextSummaryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Summarize")]
        public async Task<IActionResult> Get(string textInput)
        {
            var summarizedText = await SummarizeService.TextSummarizationExample(textInput);
            return Ok(summarizedText);
        }
    }
}
