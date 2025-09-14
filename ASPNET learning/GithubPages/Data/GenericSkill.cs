namespace GithubPage.Data.Skills
{
    [System.Serializable]
    public class GenericSkill
    {
        public GenericSkill(string name, string imgSrc, Category? skillCategory)
        {
            Name = name;
            ImageSource = imgSrc;
            SkillCategory = skillCategory;

        }

        public string Name { get; }
        public string ImageSource { get; }
        public Category? SkillCategory { get; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not GenericSkill other)
            {
                return false;
            }

            // We only care for the name, as the image source will likely be unique
            return Name == other.Name;
        }
        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            // Combine the hash codes of the unique properties to create a unique hash code for the object.
            return HashCode.Combine(Name, ImageSource, SkillCategory);
        }

        public enum Category
        {
            Languages,
            FrameworkAndEngine,
            ToolsAndPlatforms,
            ConceptsAndMethodologies,
            Specialties
        }
    }

    #region this is not good but it helps predefine the common skill types

    [System.Serializable]
    public sealed class SkillLanguage : GenericSkill
    { public SkillLanguage(string name, string imgSrc) : base(name, imgSrc, Category.Languages) { } }
    [System.Serializable]
    public sealed class SkillFrameWorkAndEngine : GenericSkill
    { public SkillFrameWorkAndEngine(string name, string imgSrc) : base(name, imgSrc, Category.FrameworkAndEngine) { } }
    [System.Serializable]
    public sealed class SkillToolsAndPlatforms : GenericSkill
    { public SkillToolsAndPlatforms(string name, string imgSrc) : base(name, imgSrc, Category.ToolsAndPlatforms) { } }
    [System.Serializable]
    public sealed class SkillConceptsAndMethodologies : GenericSkill
    { public SkillConceptsAndMethodologies(string name, string imgSrc) : base(name, imgSrc, Category.ConceptsAndMethodologies) { } }
    [System.Serializable]
    public sealed class SkillSpecialties : GenericSkill
    { public SkillSpecialties(string name, string imgSrc) : base(name, imgSrc, Category.Specialties) { } }

    #endregion
}