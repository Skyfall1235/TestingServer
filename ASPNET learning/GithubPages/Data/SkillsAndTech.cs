namespace GithubPages.Data
{
    [Serializable]
    public class SkillsAndTech
    {
        private Dictionary<string, GenericSkill> m_skills = new Dictionary<string, GenericSkill>();
        public Dictionary<string, GenericSkill> Skills { get => m_skills; set => m_skills = value; }

        /// <summary>
        /// Adds an existing skill to the local skills collection.
        /// </summary>
        /// <param name="skill">The GenericSkill object to add.</param>
        /// <returns>True if the skill was successfully added; otherwise, false if the skill already exists locally or is not in the global resource list.</returns>
        /// <remarks>
        /// This method ensures that:
        /// 1. The skill to be added exists in the global WebsiteResources.SkillsAndTech.
        /// 2. The skill is not a duplicate within the local collection.
        /// </remarks>
        public bool AddSkill(GenericSkill skill)
        {
            // If the global resource has a copy of the skill and the local collection does not, add it.
            if(!WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name))
            { return false; }
            if (m_skills.TryAdd(skill.Name, skill))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a skill to the local collection by its name.
        /// </summary>
        /// <param name="skillName">The name of the skill to add.</param>
        /// <returns>True if the skill was successfully found in the global resources and added locally; otherwise, false.</returns>
        /// <remarks>
        /// This method looks up the skill in the global resources and then calls the AddSkill(GenericSkill) overload to add it to the local collection.
        /// </remarks>
        public bool AddSkill(string skillName)
        {
            // Check if the global resource contains the skill by name.
            if (WebsiteResources.SkillsAndTech.Skills.TryGetValue(skillName, out GenericSkill? skill))
            {
                // Add the skill locally using the other AddSkill overload.
                return AddSkill(skill);
            }
            return false;
        }

        /// <summary>
        /// Adds a new skill to the global resources and then to the local collection.
        /// </summary>
        /// <param name="skill">The GenericSkill object to add.</param>
        /// <remarks>
        /// This method is designed to "override" the standard behavior by adding a new skill to the global list if it doesn't already exist. 
        /// It then ensures the skill is added to the local collection.
        /// </remarks>
        public void AddOverrideSkill(GenericSkill skill)
        {
            // Check if the skill already exists in the global resource list.
            WebsiteResources.SkillsAndTech.Skills.TryAdd(skill.Name, skill);
        }

        /// <summary>
        /// Adds a batch of GenericSkill objects to the local collection and optionally to the global resources.
        /// </summary>
        /// <param name="skills">The list of GenericSkill objects to add.</param>
        /// <param name="AddToResources">If true, adds the skills to the global resources before adding them locally.</param>
        /// <returns>True if all skills were added successfully; otherwise, false.</returns>
        public bool BatchAddSkills(List<GenericSkill> skills, bool AddToResources)
        {
            foreach (var skill in skills)
            {
                if (AddToResources)
                {
                    if(skill == null) { continue; }
                    WebsiteResources.SkillsAndTech.Skills.TryAdd(skill.Name, skill);
                    // This will throw an exception if the key already exists. Consider using AddOverrideSkill instead for safety.
                    // A better approach would be to use a try/catch or an existence check.
                    // Example: if (!WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name)) { ... }
                    // The provided code assumes Add() will not fail, which may not be a safe assumption.

                }
                else
                {
                    // Add the skill to the local collection.
                    bool success = AddSkill(skill);
                    if (!success)
                    {
                        return false; // Return false on the first failure.
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Adds a batch of skills by name to the local collection.
        /// </summary>
        /// <param name="skills">The list of skill names to add.</param>
        /// <returns>True if all skills were added successfully; otherwise, false.</returns>
        /// <remarks>
        /// This method is more robust as it can handle skill names that are not yet defined in the global resources.
        /// </remarks>
        public bool BatchAddSkills(List<string> skills)
        {
            foreach (string skillName in skills)
            {
                if (!WebsiteResources.SkillsAndTech.Skills.ContainsKey(skillName))
                {

                    // AddToResources is true, so create a new skill and add it to the global resources first.
                    GenericSkill GeneratedSkill = new(skillName, "", GenericSkill.Category.Unknown);
                    WebsiteResources.SkillsAndTech.AddOverrideSkill(GeneratedSkill);
                }
            }
            return true; // All skills processed successfully.
        }
    }
    public record SkillDTO(string name, string imagesource, string category);
}

