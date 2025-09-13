public class SkillsAndTech
{
    private List<string> stringListOfSkillsAndTech = new List<string>();
    bool isInitialized = false;
    /// <summary>
    /// Gets a combined, ordered list of all skills as strings.
    /// </summary>
    public List<string> SkillsAsStrings
    {
        get
        {
            //caching the result of this so we dont need to run it again. 
            if(!isInitialized)
            {
                InitializeStringList();
                isInitialized = true;
            }
            return stringListOfSkillsAndTech;
        }
    }

    private void InitializeStringList()
    {
        // Iterate over each enum value and add to the list if the flag is set.
        foreach (Languages lang in Enum.GetValues(typeof(Languages)))
        {
            if (lang != Languages.None && _languages.HasFlag(lang))
            {
                stringListOfSkillsAndTech.Add(lang.ToString());
            }
        }

        foreach (FrameworksAndEngines framework in Enum.GetValues(typeof(FrameworksAndEngines)))
        {
            if (framework != FrameworksAndEngines.None && _frameworksAndEngines.HasFlag(framework))
            {
                stringListOfSkillsAndTech.Add(framework.ToString());
            }
        }

        foreach (ToolsAndPlatforms tool in Enum.GetValues(typeof(ToolsAndPlatforms)))
        {
            if (tool != ToolsAndPlatforms.None && _toolsAndPlatforms.HasFlag(tool))
            {
                stringListOfSkillsAndTech.Add(tool.ToString());
            }
        }

        foreach (ConceptsAndMethodologies concept in Enum.GetValues(typeof(ConceptsAndMethodologies)))
        {
            if (concept != ConceptsAndMethodologies.None && _concepts.HasFlag(concept))
            {
                stringListOfSkillsAndTech.Add(concept.ToString());
            }
        }

        foreach (Specialties specialty in Enum.GetValues(typeof(Specialties)))
        {
            if (specialty != Specialties.None && _specialties.HasFlag(specialty))
            {
                stringListOfSkillsAndTech.Add(specialty.ToString());
            }
        }
    }
    private Languages _languages { get; set; }
    private FrameworksAndEngines _frameworksAndEngines { get;  set; }
    private ToolsAndPlatforms _toolsAndPlatforms { get;  set; }
    private ConceptsAndMethodologies _concepts { get;  set; }
    private Specialties _specialties { get;  set; }

    #region public methods
    /// <summary>
    /// Adds a language skill using bitwise OR.
    /// </summary>
    /// <param name="language">The language to add.</param>
    public void AddLanguage(Languages language)
    {
        _languages |= language;
    }

    /// <summary>
    /// Adds a framework or engine skill using bitwise OR.
    /// </summary>
    /// <param name="framework">The framework or engine to add.</param>
    public void AddFramework(FrameworksAndEngines framework)
    {
        _frameworksAndEngines |= framework;
    }

    /// <summary>
    /// Adds a tool or platform skill using bitwise OR.
    /// </summary>
    /// <param name="tool">The tool or platform to add.</param>
    public void AddTool(ToolsAndPlatforms tool)
    {
        _toolsAndPlatforms |= tool;
    }

    /// <summary>
    /// Adds a core concept or methodology skill using bitwise OR.
    /// </summary>
    /// <param name="concept">The concept or methodology to add.</param>
    public void AddConcept(ConceptsAndMethodologies concept)
    {
        _concepts |= concept;
    }

    /// <summary>
    /// Adds a specialization skill using bitwise OR.
    /// </summary>
    /// <param name="specialty">The specialty to add.</param>
    public void AddSpecialty(Specialties specialty)
    {
        _specialties |= specialty;
    }
    #endregion

    

    #region Enum Flags
    /// <summary>
    /// Represents the programming languages.
    /// </summary>
    [Flags]
    public enum Languages
    {
        None = 0,
        CSharp = 1,
        CPlusPlus = 2,
        Python = 4,
        XML = 8,
        JSON = 16
    }

    /// <summary>
    /// Represents frameworks and game engines.
    /// </summary>
    [Flags]
    public enum FrameworksAndEngines
    {
        None = 0,
        DOT_NET = 1,
        UnityEngine = 2,
        UnityNetcode = 4,
        UnityDOTS = 8
    }

    /// <summary>
    /// Represents tools and platforms.
    /// </summary>
    [Flags]
    public enum ToolsAndPlatforms
    {
        None = 0,
        VisualStudio = 1,
        Jira = 2,
        GitHub = 4,
        GitHubActions = 8,
        GitLFS = 16
    }

    /// <summary>
    /// Represents core programming concepts and methodologies.
    /// </summary>
    [Flags]
    public enum ConceptsAndMethodologies
    {
        None = 0,
        ObjectOrientedProgramming = 1,
        AgileScrum = 2,
        DevOps = 4
    }

    /// <summary>
    /// Represents specific specializations.
    /// </summary>
    [Flags]
    public enum Specialties
    {
        None = 0,
        VR = 1,
        VRDevelopment = 2
    }
    #endregion
}


//objectives for this API
/* - Have a get HTTP request for the skills
 * - have a get request for the images?
 * - have a get request for the info?
 * - probably should have it all added together
 * - basically, we want this API to be able to supply info about my projects to my portfolio
 * in a manner that allows me to update it without needing a full redo and commit
 * 
 * Part 1 : data storage and retrieval
 * - categorize data about my showcase stuff
 * - be able to send that data in the appriate http chunks
 * 
 * Part 2 : adding new data to the site :)
 * 
 * 
 * 
 * 
 */
