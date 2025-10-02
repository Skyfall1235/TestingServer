namespace GithubPages.Data.Projects
{
    /// <summary>
    /// Represents a single project for the website.
    /// A project is composed of a m_title, m_description, a list of associated
    /// m_skills, and a collection of content blocks.
    /// </summary>
    [System.Serializable]
    public class Project
    {
        private int id;
        public int Id => id;

        private string m_title;
        public string Title => m_title;

        private string m_description;
        public string Description => m_description;

        private string m_titleCardURL;
        public string TitleCardURL => m_titleCardURL;

        private string m_growth;
        public string Growth => m_growth;

        private string m_projectOverview;
        public string ProjectOverview => m_projectOverview;

        /// <summary>
        /// Gets or sets the list of m_skills and technologies associated with the project.
        /// </summary>
        public List<string> Skills { get; set; }

        public void SetId(int Id)
        {
            id = Id;
        }
        public void SetValues(string title, string description, string titlecardURL, string growth, string projectOverview)
        {
            m_title = title;
            m_description = description;
            m_titleCardURL = titlecardURL;
            m_growth = growth;
            m_projectOverview = projectOverview;
        }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="skills">The list of skills for the project. This parameter name must match the JSON property name.</param>
        /// <param name="title">The m_title of the project.</param>
        /// <param name="description">The m_description of the project.</param>
        /// <param name="titleCardURL">The URL for the project's m_title card image.</param>
        /// <param name="growth">The text describing professional m_growth from the project.</param>
        /// <param name="projectOverview">The text providing a general overview of the project.</param>
        public Project(int id, List<string> skills, string title, string description, string titleCardURL, string growth, string projectOverview)
        {
            this.id = id;
            Skills = skills;
            m_title = title;
            m_description = description;
            m_titleCardURL = titleCardURL;
            m_growth = growth;
            m_projectOverview = projectOverview;
        }
    }
}


