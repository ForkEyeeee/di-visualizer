using Microsoft.AspNetCore.Mvc;

namespace DIVisualizer.Server.Services
{
    public interface IGithubService
    {
        public Task<string> GetDependencyInformation(string url);
    }
}
