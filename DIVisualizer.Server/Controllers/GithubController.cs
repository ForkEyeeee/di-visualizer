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
        public async Task<string> GetDependencyInformation([FromQuery] string repourl)
        {
            var information = await githubService.GetDependencyInformation(repourl);
            logger.LogInformation(repourl);
            return information;
        }
    }
}
