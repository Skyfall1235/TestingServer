using GithubPage.Data.Skills;

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
        styleStudiosSkills.AddSkill("C#");
        styleStudiosSkills.AddSkill("Unity Engine");
        styleStudiosSkills.AddSkill("Unity Netcode");
        styleStudiosSkills.AddSkill("Unity DOTS");
        styleStudiosSkills.AddSkill("Visual Studio");
        styleStudiosSkills.AddSkill("Jira");
        styleStudiosSkills.AddSkill("GitHub");
        styleStudiosSkills.AddSkill("GitHub Actions");
        styleStudiosSkills.AddSkill("Git LFS");
        styleStudiosSkills.AddSkill("Object-Oriented Programming");
        styleStudiosSkills.AddSkill("Agile Scrum");
        styleStudiosSkills.AddSkill("DevOps");
        styleStudiosSkills.AddSkill("VR");
        styleStudiosSkills.AddSkill("VR Development");
        List<ContentBlock> styleStudiosContentBlocks = new();

        // Replicating the structure for other projects
        Project OneWeekTanks;
        SkillsAndTech oneWeekTanksSkills = new();
        
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        oneWeekTanksSkills.AddSkill("C#");
        List<ContentBlock> oneWeekTanksContentBlocks = new();

        Project ProjectVRS;
        SkillsAndTech projectVRSSkills = new();
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");


        List<ContentBlock> projectVRSContentBlocks = new();

        Project CustomGithubPagesAPI;
        SkillsAndTech customGithubPagesAPISkills = new();
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");
        projectVRSSkills.AddSkill("C#");

        List<ContentBlock> customGithubPagesAPIContentBlocks = new();

    }
}

//// Languages
//,
//            new SkillLanguage("C++", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/cplusplus/cplusplus-original.svg"),
//            new SkillLanguage("Python", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/python/python-original.svg"),
//            new SkillLanguage("XML", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/xml/xml-plain.svg"),
//            new SkillLanguage("JSON", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/json/json-plain.svg"),

//            // Frameworks and Engines
//            new SkillFrameWorkAndEngine(".NET", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain.svg"),
//            new SkillFrameWorkAndEngine("Unity Engine", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"),
//            new SkillFrameWorkAndEngine("Unity Netcode", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"),
//            new SkillFrameWorkAndEngine("Unity DOTS", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg"),

//            // Tools and Platforms
//            new SkillToolsAndPlatforms("Visual Studio", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg"),
//            new SkillToolsAndPlatforms("Jira", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/jira/jira-plain.svg"),
//            new SkillToolsAndPlatforms("GitHub", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg"),
//            new SkillToolsAndPlatforms("GitHub Actions", "https://placehold.co/64x64/2d3748/e2e8f0?text=Actions"),
//            new SkillToolsAndPlatforms("Git LFS", "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-original.svg"),

//            // Concepts and Methodologies
//            new SkillConceptsAndMethodologies("Object-Oriented Programming", "https://placehold.co/64x64/2d3748/e2e8f0?text=OOP"),
//            new SkillConceptsAndMethodologies("Agile Scrum", "https://placehold.co/64x64/2d3748/e2e8f0?text=Agile"),
//            new SkillConceptsAndMethodologies("DevOps", "https://placehold.co/64x64/2d3748/e2e8f0?text=DevOps"),

//            // Specialties
//            new SkillSpecialties("VR", "https://placehold.co/64x64/2d3748/e2e8f0?text=VR"),
//            new SkillSpecialties("VR Development", "https://placehold.co/64x64/2d3748/e2e8f0?text=VR")
//new Project
//        (
//            title: "test",
//            description: "test",
//            titleCardURL: "test",
//            skillList: new SkillsAndTech
//            {
//                Skills = new List<GenericSkill>
//                    {
//                        new GenericSkill("C#", "https://cdn.iconscout.com/icon/free/png-512/csharp-5-1175249.png", GenericSkill.Category.Languages),
//                        new GenericSkill("Unity Engine", "https://cdn.iconscout.com/icon/free/png-512/unity-34-1175109.png", GenericSkill.Category.FrameworkAndEngine),
//                        new GenericSkill("Unity Netcode", "https://unity.com/themes/unity/images/og-unity-netcode-for-gameobjects.png", GenericSkill.Category.FrameworkAndEngine),
//                        new GenericSkill("Unity ECS", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Unity_Technologies_logo.svg/1200px-Unity_Technologies_logo.svg.png", GenericSkill.Category.FrameworkAndEngine),
//                        new GenericSkill("Jira", "https://cdn.iconscout.com/icon/free/png-512/jira-35-1175184.png", GenericSkill.Category.ToolsAndPlatforms),
//                        new GenericSkill("Git & GitHub", "https://cdn.iconscout.com/icon/free/png-512/git-18-1175204.png", GenericSkill.Category.ToolsAndPlatforms),
//                        new GenericSkill("VR Development", "https://cdn.iconscout.com/icon/free/png-512/virtual-reality-1-1175196.png", GenericSkill.Category.Specialties),
//                        new GenericSkill("DevOps", "https://cdn.iconscout.com/icon/free/png-512/devops-5-1175217.png", GenericSkill.Category.ConceptsAndMethodologies)
//                    }
//            },
//            blocks: new()
//            {
//                new TextBlock(0, 0, "Role & Responsibilities",
//                    "Oversaw the integration of new features into existing game architecture. " +
//                    "Mentored junior developers, providing hands-on learning and constructive feedback. " +
//                    "Developed and maintained core game features ensuring high performance and responsiveness. " +
//                    "Implemented networking solutions using Unity Netcode for GameObjects for seamless multiplayer. " +
//                    "Enhanced performance through Unity ECS design, optimizing gameplay on Quest 2. " +
//                    "Designed scalable inventory and item systems for diverse in-game assets. " +
//                    "Created in-game tools for designers, streamlining scriptable object editing.")
//            }
//        ),

/// <summary>
/// Represents a single project for the website.
/// A project is composed of a title, description, a list of associated
/// m_skills, and a collection of content blocks.
/// </summary>
[System.Serializable]
public class Project
{
    private string title;

    /// <summary>
    /// Gets the title of the project.
    /// </summary>
    public string Title { get => title; }

    private string description;

    /// <summary>
    /// Gets the description of the project.
    /// </summary>
    public string Description { get => description; }

    private string titleCardURL;
    public string TitleCardURL => titleCardURL;

    /// <summary>
    /// Gets or sets the list of m_skills and technologies associated with the project.
    /// </summary>
    public SkillsAndTech SkillList { get; set; }

    private List<ContentBlock> Blocks = new();
    /// <summary>
    /// Gets a read-only list of informational content blocks for the project.
    /// </summary>
    public IReadOnlyList<ContentBlock> InfoBlocks => Blocks;

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <param name="skillList">The list of m_skills for the project.</param>
    /// <param name="blocks">The initial list of info blocks for the project.</param>
    /// <param name="title">The title of the project.</param>
    /// <param name="description">The description of the project.</param>
    public Project(SkillsAndTech skillList, List<ContentBlock> blocks, string title, string description, string titleCardURL)
    {
        SkillList = skillList;
        Blocks = blocks;
        this.title = title;
        this.description = description;
        this.titleCardURL = titleCardURL;
    }

    /// <summary>
    /// Adds a new informational content block to the project.
    /// </summary>
    /// <param name="block">The info block to add.</param>
    public void AddContentblock(ContentBlock block) { Blocks.Add(block); }

    /// <summary>
    /// Removes an informational content block from the project.
    /// </summary>
    /// <param name="block">The info block to remove.</param>
    public void RemoveContentBlock(ContentBlock block) { Blocks.Remove(block); }
}

/// <summary>
/// An abstract base class for a content block.
/// All specific content blocks (like text or code) should inherit from this class.
/// </summary>
[System.Serializable]
public abstract class ContentBlock
{
    /// <summary>
    /// Gets or sets the unique ID of the project this block belongs to.
    /// </summary>
    public int ProjectID { get; set; }

    /// <summary>
    /// Gets or sets the unique ID of the block within the project.
    /// </summary>
    public int blockID { get; set; }

    /// <summary>
    /// Gets or sets the name of the block.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentBlock"/> class.
    /// </summary>
    /// <param name="projectID">The ID of the parent project.</param>
    /// <param name="blockID">The ID of the block.</param>
    /// <param name="name">The name of the block.</param>
    public ContentBlock(int projectID, int blockID, string name)
    {
        this.ProjectID = projectID;
        this.blockID = blockID;
        this.Name = name;
    }
}

/// <summary>
/// Represents a content block that contains plain text.
/// </summary>
[System.Serializable]
public class TextBlock : ContentBlock
{
    /// <summary>
    /// Optional title for a text card.
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Gets or sets the text content of the block.
    /// </summary>
    public string text { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextBlock"/> class.
    /// </summary>
    /// <param name="projectID">The ID of the parent project.</param>
    /// <param name="blockID">The ID of the block.</param>
    /// <param name="name">The name of the block.</param>
    /// <param name="newText">The text content for the block.</param>
    public TextBlock(int projectID, int blockID, string name, string newText) : base(projectID, blockID, name)
    {
        text = newText;
    }
}

/// <summary>
/// Represents a content block that contains code.
/// This class inherits from <see cref="TextBlock"/> to reuse the 'text' property for the code content.
/// </summary>
[System.Serializable]
public class CodeBlock : TextBlock
{
    /// <summary>
    /// Gets or sets a subtitle for the code block.
    /// </summary>
    public string Subtitle { get; set; }

    /// <summary>
    /// Gets or sets the programming language or data type of the code.
    /// </summary>
    public string Datatype { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeBlock"/> class.
    /// </summary>
    /// <param name="projectID">The ID of the parent project.</param>
    /// <param name="blockID">The ID of the block.</param>
    /// <param name="name">The name of the block.</param>
    /// <param name="newText">The code content for the block.</param>
    /// <param name="subtitleInfo">The subtitle for the code block.</param>
    /// <param name="dataTypeInfo">The data type or language of the code block.</param>
    public CodeBlock(int projectID, int blockID, string name, string newText, string subtitleInfo, string dataTypeInfo) : base(projectID, blockID, name, newText)
    {
        text = newText;
        Subtitle = subtitleInfo;
        Datatype = dataTypeInfo;
    }
}

[System.Serializable]
public class ImageAndTextBlock : TextBlock
{
    public ImageAndTextBlock(int projectID, int blockID, string name, string newText) : base(projectID, blockID, name, newText)
    {
    }
}

