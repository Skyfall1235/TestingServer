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
            if (WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name) && !m_skills.ContainsKey(skill.Name))
            {
                m_skills.Add(skill.Name, skill);
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
            if (WebsiteResources.SkillsAndTech.Skills.ContainsKey(skillName))
            {
                // Retrieve the GenericSkill object from the global resources.
                GenericSkill skill = WebsiteResources.SkillsAndTech.Skills[skillName];

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
            if (!WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name))
            {
                // If it doesn't exist, add it to the global list.
                WebsiteResources.SkillsAndTech.Skills.Add(skill.Name, skill);
            }
            // Now, regardless of whether it was added or already existed, add it to the local list.
            // This handles cases where the skill was just added or was already there but not in the local list.
            AddSkill(skill);
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
                    // This will throw an exception if the key already exists. Consider using AddOverrideSkill instead for safety.
                    // A better approach would be to use a try/catch or an existence check.
                    // Example: if (!WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name)) { ... }
                    // The provided code assumes Add() will not fail, which may not be a safe assumption.
                    WebsiteResources.SkillsAndTech.Skills.Add(skill.Name, skill);
                }
                // Add the skill to the local collection.
                bool success = AddSkill(skill);
                if (!success)
                {
                    return false; // Return false on the first failure.
                }
            }
            return true;
        }

        /// <summary>
        /// Adds a batch of skills by name to the local collection.
        /// </summary>
        /// <param name="skills">The list of skill names to add.</param>
        /// <param name="AddToResources">If true, generates a new skill and adds it to the global resources if it doesn't already exist.</param>
        /// <returns>True if all skills were added successfully; otherwise, false.</returns>
        /// <remarks>
        /// This method is more robust as it can handle skill names that are not yet defined in the global resources.
        /// If a skill name does not exist globally:
        /// - If AddToResources is true, a new skill is generated, added to the global resources, and then added locally.
        /// - If AddToResources is false, the method fails and returns false immediately.
        /// </remarks>
        public bool BatchAddSkills(List<string> skills, bool AddToResources)
        {
            foreach (string skillName in skills)
            {
                if (WebsiteResources.SkillsAndTech.Skills.ContainsKey(skillName))
                {
                    // Skill exists globally, so get the object and add it locally.
                    GenericSkill skillObject = WebsiteResources.SkillsAndTech.Skills[skillName];
                    if (!AddSkill(skillObject))
                    {
                        return false; // Failed to add the existing skill.
                    }
                }
                else // Skill does not exist globally.
                {
                    if (!AddToResources)
                    {
                        // AddToResources is false, so we cannot create or add a new skill.
                        return false; // Failed because the skill does not exist and cannot be created.
                    }
                    // AddToResources is true, so create a new skill and add it to the global resources first.
                    GenericSkill GeneratedSkill = new(skillName, "", GenericSkill.Category.Unknown);
                    WebsiteResources.SkillsAndTech.AddOverrideSkill(GeneratedSkill);

                    // Then, add the newly created skill to the local list.
                    if (!AddSkill(GeneratedSkill))
                    {
                        return false; // Failed to add the newly created skill.
                    }
                }
            }
            return true; // All skills processed successfully.
        }
    }
    public record SkillDTO(string name, string imagesource, string category);





    //objectives for this API
    /* - Have a get HTTP request for the m_skills
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
}

