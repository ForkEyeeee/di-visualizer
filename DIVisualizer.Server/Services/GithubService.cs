using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DIVisualizer.Server.Services
{
    public class GithubService : IGithubService
    {
        public async Task<string> GetDependencyInformation(string url)
        {
            return url;
        }
    }
}
