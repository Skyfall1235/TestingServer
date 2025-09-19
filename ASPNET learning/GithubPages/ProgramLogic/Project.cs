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
        public string Title => title;
        private string description;
        public string Description => description;
        private string titleCardURL;
        public string TitleCardURL => titleCardURL;
        private string growth;
        public string Growth => growth;
        private string projectOverview;
        public string ProjectOverview => projectOverview;

        /// <summary>
        /// Gets or sets the list of m_skills and technologies associated with the project.
        /// </summary>
        public SkillsAndTech SkillList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="skillList">The list of m_skills for the project.</param>
        /// <param name="blocks">The initial list of info blocks for the project.</param>
        /// <param name="title">The title of the project.</param>
        /// <param name="description">The description of the project.</param>
        /// <param name="titleCardURL">The URL for the project's title card image.</param>
        /// <param name="growth">The text describing professional growth from the project.</param>
        /// <param name="projectOverview">The text providing a general overview of the project.</param>
        public Project(SkillsAndTech skillList, string title, string description, string titleCardURL, string growth, string projectOverview)
        {
            SkillList = skillList;
            this.title = title;
            this.description = description;
            this.titleCardURL = titleCardURL;
            this.growth = growth;
            this.projectOverview = projectOverview;
        }
    }
}


