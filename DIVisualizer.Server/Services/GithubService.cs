using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace DIVisualizer.Server.Services
{
    public class GithubService : IGithubService
    {
        public async Task<string> GetDependencyInformation(string url)
        {

            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);


            var result = Repository.Clone(url, tempDirectory);

            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(tempDirectory));

            Directory.Delete(tempDirectory, true);

            return tempDirectory;
        }

    }
}

