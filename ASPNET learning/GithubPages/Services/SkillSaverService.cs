using System.Diagnostics;

namespace GithubPages.Services
{
    public class SkillSaverService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly string skillJsonLocation;

        public SkillSaverService(IHostApplicationLifetime appLifetime, IConfiguration configuration)
        {
            _appLifetime = appLifetime;
            skillJsonLocation = configuration["SkillsJsonLocalPath"] ?? throw new InvalidOperationException("skillJsonLocation configuration setting is missing or empty.");
            Debug.WriteLine(skillJsonLocation);
            _appLifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        private void OnApplicationStopping()
        {
            WebsiteResources.SaveSkillsToJson(WebsiteResources.SkillsAndTech.Skills.Values.ToList(), "wwwroot/ActiveData/projects.json");
        }
    }
    public class ProjectSaverService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly string projectJsonLocation;

        public ProjectSaverService(IHostApplicationLifetime appLifetime, IConfiguration configuration)
        {
            _appLifetime = appLifetime;
            projectJsonLocation = configuration["ProjectJsonLocalPath"] ?? throw new InvalidOperationException("skillJsonLocation configuration setting is missing or empty.");
            _appLifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        private void OnApplicationStopping()
        {
            WebsiteResources.SaveProjectsToJson(WebsiteResources.Projects, "wwwroot/ActiveData/projects.json");
        }

        public void OnManualSave()
        {
            WebsiteResources.SaveProjectsToJson(WebsiteResources.Projects, "wwwroot/ActiveData/projects.json");
        }
    }
}