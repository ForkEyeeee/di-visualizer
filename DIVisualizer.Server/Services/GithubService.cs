using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace DIVisualizer.Server.Services
{
    public class GithubService : IGithubService
    {
        private readonly ILogger<GithubService> logger;

        public GithubService(ILogger<GithubService> logger)
        {
            this.logger = logger;
        }
        public async Task<string> GetDependencyInformation(string url)
        {
            string path = @"c:\MyDir";


            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                Directory.Delete(path, true);
            }

            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            
            var result = Repository.Clone(url, path);

            di.Delete();
            Console.WriteLine("The directory was deleted successfully.");
            return path;
        }

    }

}


