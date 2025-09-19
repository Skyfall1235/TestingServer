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
            // Define the path to your skills.json file
            // You would get this from configuration or another injected service
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "skills.json");

            // Example: Get your list of skills here (this would come from a data source)
            var skillsToSave = new List<GenericSkill>(); // Replace with your actual skills list

            // Call your static method to save the data
            WebsiteResources.SaveSkillsToJson(skillsToSave, filePath);
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
            // Define the path to your skills.json file
            // You would get this from configuration or another injected service
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "projects.json");

            // Example: Get your list of skills here (this would come from a data source)
            var projectsToSave = new List<Project>(); // Replace with your actual skills list

            // Call your static method to save the data
            WebsiteResources.SaveProjectsToJson(projectsToSave, filePath);
        }
    }
}