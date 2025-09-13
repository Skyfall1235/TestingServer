using System.Drawing;
using System.Xml.Linq;
using static WebsiteResources;
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
 * - build an API key for secure access
 * - use API key to allow select post requests
 * 
 * part 3 : Saving data as files when the server needs to power down
 * -determine storage technique
 * -load existing data oin start up
 * -unload on shutdown
 * 
 * 
 * 
 */

/// <summary>
/// A static class that holds a collection of website projects.
/// This class is designed to be a singleton, ensuring only one
/// instance of the project list exists across the application.
/// </summary>
public class WebsiteResources
{
    /// <summary>
    /// Gets or sets the static list of projects for the website.
    /// The property is static to ensure all parts of the application
    /// access the same list.
    /// </summary>
    public static List<Project> Projects = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="WebsiteResources"/> class.
    /// This constructor ensures that the Projects list is initialized only once.
    /// </summary>
    public WebsiteResources() { }
}

/// <summary>
/// Represents a single project for the website.
/// A project is composed of a title, description, a list of associated
/// skills, and a collection of content blocks.
/// </summary>
public class Project
{
    /// <summary>
    /// Gets or sets the list of skills and technologies associated with the project.
    /// </summary>
    public SkillsAndTech SkillList { get; set; }

    private List<ContentBlock> Blocks = new();

    /// <summary>
    /// Gets a read-only list of informational content blocks for the project.
    /// </summary>
    public IReadOnlyList<ContentBlock> InfoBlocks => Blocks;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <param name="skillList">The list of skills for the project.</param>
    /// <param name="blocks">The initial list of info blocks for the project.</param>
    /// <param name="title">The title of the project.</param>
    /// <param name="description">The description of the project.</param>
    public Project(SkillsAndTech skillList, List<ContentBlock> blocks, string title, string description)
    {
        SkillList = skillList;
        Blocks = blocks;
        this.title = title;
        this.description = description;
    }

    /// <summary>
    /// Adds a new informational content block to the project.
    /// </summary>
    /// <param name="block">The info block to add.</param>
    public void AddInfoblock(ContentBlock block) { Blocks.Add(block); }

    /// <summary>
    /// Removes an informational content block from the project.
    /// </summary>
    /// <param name="block">The info block to remove.</param>
    public void RemoveInfoBlock(ContentBlock block) { Blocks.Remove(block); }
}

/// <summary>
/// An abstract base class for a content block.
/// All specific content blocks (like text or code) should inherit from this class.
/// </summary>
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
public class TextBlock : ContentBlock
{
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

