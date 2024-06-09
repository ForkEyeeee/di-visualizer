using DIVisualizer.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIVisualizer.Server.Controllers
{
    [ApiController]
    public class DependencyInjection : Controller
    {
        private readonly ILogger<DependencyInjection> logger;
        private readonly ISftpService sftpService;

        public DependencyInjection(ILogger<DependencyInjection> logger, ISftpService sftpService)
        {
            this.logger = logger;
            this.sftpService = sftpService;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task GetInformation([FromQuery] string url)
        {
            try
            {
                await sftpService.GetInformation(url);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }
        }
    }
}
