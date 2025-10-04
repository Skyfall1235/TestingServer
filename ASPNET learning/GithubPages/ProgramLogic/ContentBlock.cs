
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
    /// Optional m_title for a text card.
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

