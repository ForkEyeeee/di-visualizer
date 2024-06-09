using Renci.SshNet;
using DIVisualizer.Server.Models;


namespace DIVisualizer.Server.Services
{
    public class SftpService : ISftpService
    {
        private readonly ILogger<ISftpService> logger;
        private readonly SftpConfig sftpConfig;

        public SftpService(ILogger<ISftpService> logger, SftpConfig sftpConfig)
        {
            this.logger = logger;
            this.sftpConfig = sftpConfig;
        }

        public async Task GetInformation(string url)
        {
            SshClient cSSH = new SshClient(sftpConfig.Host, sftpConfig.Port, sftpConfig.UserName, sftpConfig.Password);
            cSSH.Connect();
            SshCommand x = cSSH.RunCommand($"git clone {url}");
        }
    }
}


