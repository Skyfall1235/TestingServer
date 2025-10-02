using GithubPages.Data;
using GithubPages.Data.Projects;

namespace GithubPages.Services
{
    public class SkillSaverService
    {
        private readonly IHostApplicationLifetime _appLifetime;

        public SkillSaverService(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;

            // This registers a callback that will be executed when the application is stopping.
            _appLifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        private void OnApplicationStopping()
        {
            // Example: Get your list of skills here (this would come from a data source)
            WebsiteResources.SaveSkillsToJson(WebsiteResources.SkillsAndTech.Skills.Values.ToList(), "wwwroot/Skills.json");
        }
    }
    public class ProjectSaverService
    {
        private readonly IHostApplicationLifetime _appLifetime;

        public ProjectSaverService(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;

            // This registers a callback that will be executed when the application is stopping.
            _appLifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        private void OnApplicationStopping()
        {
            // Call your static method to save the data
            WebsiteResources.SaveProjectsToJson(WebsiteResources.Projects, "wwwroot/projects.json");
        }

        public void OnManualSave()
        {
            WebsiteResources.SaveProjectsToJson(WebsiteResources.Projects, "wwwroot/projects.json");
        }
    }
}