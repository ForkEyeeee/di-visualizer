using Renci.SshNet;
using DIVisualizer.Server.Models;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;



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
            //Start Connections
            SshClient cSSH = new SshClient(sftpConfig.Host, sftpConfig.Port, sftpConfig.UserName, sftpConfig.Password);
            SftpClient client = new SftpClient(sftpConfig.Host, sftpConfig.Port, sftpConfig.UserName, sftpConfig.Password);

            cSSH.Connect();
            client.Connect();

            SshCommand a = cSSH.RunCommand("snap install dotnet-sdk --classic");

            //Clone repo
            SshCommand x = cSSH.RunCommand($"git clone {url}");

            //Navigate to the repo
            SshCommand getSSHWorkingDirectory = cSSH.RunCommand("pwd");
            string workingDirectory = getSSHWorkingDirectory.Result.Trim() + "/di-visualizer/DIVisualizer.Server";
            client.ChangeDirectory(workingDirectory);

            //Navigate to the repo second method
            string cmdstr = "cd di-visualizer/DIVisualizer.Server";
            var cmd = cSSH.RunCommand(cmdstr);


            //Roslyn analysis
            MSBuildLocator.RegisterDefaults();


            var workspace = MSBuildWorkspace.Create();
            string analysis = "dotnet run -r roslyn --project /root/di-visualizer/DIVisualizer.Server/DIVisualizer.Server.csproj";
            SshCommand b = cSSH.RunCommand(analysis);

            var solution = await workspace.OpenSolutionAsync(client.WorkingDirectory);

            foreach (var project in solution.Projects)
            {
                Console.WriteLine(project.AssemblyName);
            }

            //Close connections
            client.ChangeDirectory("/root");
            cSSH.RunCommand("rm -r di-visualizer");
            client.Disconnect();
            cSSH.Disconnect();
        }
    }
}


