using GithubPage.Data.Skills;

[System.Serializable]
public class SkillsAndTech
{
    private Dictionary<string, GenericSkill> m_skills = new Dictionary<string, GenericSkill>();
    public Dictionary<string, GenericSkill> Skills { get => m_skills; set => m_skills = value; }




    /// <summary>
    /// Adds a skill the skills and tech, allowing only prior existing skills to be added, while ensuring no duplicates.
    /// </summary>
    /// <param name="skill"></param>
    /// <returns></returns>
    //this needed custom logic because it cannot allow duplicates and the item must exist in the predefined m_skills and tech *or its modifications*
    public bool AddSkill(GenericSkill skill)
    {
        //if the global one has a copy and we dont, add it
        if (WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name) && !Skills.ContainsKey(skill.Name))
        {
            m_skills.Add(skill.Name, skill);
            return true;
        }
        return false;
    }

    public void AddOverrideSkill(GenericSkill skill)
    {
        var exists = WebsiteResources.SkillsAndTech.Skills.ContainsKey(skill.Name);
        if(!exists)
        {
            m_skills.Add(skill.Name, skill);
        }
    }

    public bool AddSkill(string SkillName)
    {
        //if the global one has a copy and we dont, add it
        var exists = WebsiteResources.SkillsAndTech.Skills.ContainsKey(SkillName);
        var skill = WebsiteResources.SkillsAndTech.Skills[SkillName];
        if (exists && !Skills.ContainsKey(SkillName))
        {
            //add locally
            m_skills.Add(skill.Name, skill);
            return true;
        }
        return false;
    }

    //this should allow us to batch add items in a safe and secure manner that adds them to the global resource
    //before adding them th the local list that may need them
    public bool BatchAddSkills(List<GenericSkill> skills, bool AddToResources)
    {
        //add the skills to the local list, and if the override is on, do it to the global resources too
        foreach (var skill in skills)
        {
            if (AddToResources)
            {
                WebsiteResources.SkillsAndTech.Skills.Add(skill.Name, skill);
            }
            bool success = AddSkill(skill);
            if (!success) return false;
        }
        return true;
    }

}
public record SkillDTO (string name, string imagesource, string category);





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
