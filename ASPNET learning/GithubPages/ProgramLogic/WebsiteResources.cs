using GithubPages.Data.Skills;
using GithubPages.Data.Projects;

public class WebsiteResources
{
    /// <summary>
    /// Gets or sets the static list of projects for the website.
    /// The property is static to ensure all parts of the application
    /// access the same list.
    /// </summary>
    public static List<Project> Projects = new();
    public static SkillsAndTech SkillsAndTech = new SkillsAndTech();

    public WebsiteResources()
    {
        //this is hell but it must be done for initialization setup. yes, this sucks ass. no, i wont be fixing it any time in the near future.
        //i need to preload data, this is where it is done.
        SkillsAndTech.AddOverrideSkill(new SkillLanguage("C#", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillLanguage("C++", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/cplusplus/cplusplus-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillLanguage("Python", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/python/python-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillLanguage("XML", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/xml/xml-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillLanguage("JSON", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/json/json-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine(".NET", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine("ASP.NET", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine("", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine("Unity Engine", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine("Unity Netcode", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillFrameWorkAndEngine("Unity DOTS", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillToolsAndPlatforms("Visual Studio", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillToolsAndPlatforms("Jira", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/jira/jira-plain.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillToolsAndPlatforms("GitHub", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillToolsAndPlatforms("GitHub Actions", "https://placehold.co/64x64/2d3748/e2e8f0?text=Actions"));
        SkillsAndTech.AddOverrideSkill(new SkillToolsAndPlatforms("Git LFS", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-original.svg"));
        SkillsAndTech.AddOverrideSkill(new SkillConceptsAndMethodologies("Object-Oriented Programming", "https://placehold.co/64x64/2d3748/e2e8f0?text=OOP"));
        SkillsAndTech.AddOverrideSkill(new SkillConceptsAndMethodologies("Agile Scrum", "https://placehold.co/64x64/2d3748/e2e8f0?text=Agile"));
        SkillsAndTech.AddOverrideSkill(new SkillConceptsAndMethodologies("DevOps", "https://placehold.co/64x64/2d3748/e2e8f0?text=DevOps"));
        SkillsAndTech.AddOverrideSkill(new SkillSpecialties("VR", "https://placehold.co/64x64/2d3748/e2e8f0?text=VR"));
        SkillsAndTech.AddOverrideSkill(new SkillSpecialties("VR Development", "https://placehold.co/64x64/2d3748/e2e8f0?text=VR"));

        //part 2, electric boogaloo
        // Part 2, Electric Boogaloo
        Project styleStudioWork;
        SkillsAndTech styleStudiosSkills = new();
        List<string> styleStudiosSkillsList = new List<string>
        {
            "C#",
            "Unity Engine",
            "Unity Netcode",
            "Unity DOTS",
            "Visual Studio",
            "Jira",
            "GitHub",
            "GitHub Actions",
            "Git LFS",
            "Object-Oriented Programming",
            "Agile Scrum",
            "DevOps",
            "VR",
            "VR Development"
        };
        styleStudiosSkills.BatchAddSkills(styleStudiosSkillsList, true);
        List<ContentBlock> styleStudiosContentBlocks = new();
        styleStudioWork = new(
            styleStudiosSkills,
            styleStudiosContentBlocks,
            "One Week Tanks",
            "Developed and maintained features for multiplayer VR games, " +
            "including implementing Unity Netcode for GameObjects, " +
            "optimizing performance with Unity ECS for Quest 2, " +
            "and designing scalable inventory systems. " +
            "Also created in-game tools for designers.",
            "");
        Projects.Add(styleStudioWork);



        Project OneWeekTanks;
        SkillsAndTech oneWeekTanksSkills = new();
        List<string> oneWeekTanksSkillsList = new List<string>
        {
            "Unity Engine",
            "C#",
            "Visual Studio",
            "Unity Netcode",
            "GitHub",
            "Git LFS",
            "Event-Driven Programming",
            "Object-Oriented Programming",
            "Unity VFX & Particle System",
        };
        oneWeekTanksSkills.BatchAddSkills(oneWeekTanksSkillsList, true);
        List<ContentBlock> oneWeekTanksContentBlocks = new();
        OneWeekTanks = new(
            oneWeekTanksSkills,
            oneWeekTanksContentBlocks, 
            "One Week Tanks",
            "A collaborative personal project focused on Unity's Peer-to-Peer networking, " +
            "developed within a one-week constraint. " +
            "Features real-time tank combat, synced events, and a dynamic kill feed.", 
            "");
        Projects.Add(OneWeekTanks);


        Project ProjectVRS;
        SkillsAndTech projectVRSSkills = new();
        List<string> projectVrsSkillsList = new List<string>
        {
            "C#",
            "Unity Engine",
            "Unity DOTS",
            "Visual Studio",
            "Event-Driven Programming",
            "Object-Oriented Programming",
            "Component Driven Design",
            "Git LFS",
            "VR",
            "VR Development"
        };
        projectVRSSkills.BatchAddSkills(projectVrsSkillsList, true);
        List<ContentBlock> projectVRSContentBlocks = new();
        ProjectVRS = new(
            projectVRSSkills,
            projectVRSContentBlocks,
            "Project VRS",
            "An independent VR project featuring an immersive spacecraft flight control system with dual-joystick functionality, " +
            "real-time subsystem management, and physics-simulated 3D controls. " +
            "Includes dynamic combat environments with customizable enemy waves and positional tracking turrets.",
            "");
        Projects.Add(ProjectVRS);

        Project CustomGithubPagesAPI;
        SkillsAndTech customGithubPagesAPISkills = new();
        List<string> skillsUsed = new List<string>
        {
            "C#",
            "Visual Studio",
            "Event-Driven Programming",
            "Object-Oriented Programming",
            "ASP.NET Core",
            "Web Development",
            "API Design",
            "JSON",
            "Data Structures",
            "LINQ",
            "Git",
        };
        customGithubPagesAPISkills.BatchAddSkills(skillsUsed, true);
        List<ContentBlock> customGithubPagesAPIContentBlocks = new();
        CustomGithubPagesAPI = new(
            customGithubPagesAPISkills,
            customGithubPagesAPIContentBlocks,
            "Custom Github Pages API",
            "A minimal ASP.NET Core API developed to serve as a dynamic backend for a portfolio website. " +
            "This project provides RESTful endpoints for retrieving project details, skills, and other showcase content. " +
            "It's designed to allow for easy content updates without requiring a full website redeployment, " +
            "enabling efficient management of the portfolio's data.",
            "");
        Projects.Add(CustomGithubPagesAPI);

    }
}



