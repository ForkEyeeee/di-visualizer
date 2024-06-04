using DIVisualizer.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIVisualizer.Server.Controllers
{
    [ApiController]
    public class GithubController
    {
        private readonly ILogger<GithubController> logger;
        private readonly IGithubService githubService;

        public GithubController(ILogger<GithubController> logger, IGithubService githubService)
        {
            this.logger = logger;
            this.githubService = githubService;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<string> GetDependencyInformation([FromQuery] string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new Exception("Format your url properly.");

            var information = await githubService.GetDependencyInformation(url);

            return information;
        }
    }
}
