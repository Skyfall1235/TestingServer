using GithubPages.Data.Skills;

namespace GithubPages.Data.Projects
{
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
}


