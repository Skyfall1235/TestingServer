using GithubPage.Data.Skills;

public class SkillsAndTech
{
    private List<GenericSkill> m_skills = new List<GenericSkill>();

    public List<GenericSkill> Skills => m_skills;

    /// <summary>
    /// Adds a skill the skills and tech, allowing only priorexisting skills to be added, while ensuring no duplicates.
    /// </summary>
    /// <param name="skill"></param>
    /// <returns></returns>
    //this needed custom logic because it cannot allow duplicates and the item must exist in the predefined m_skills and tech *or its modifications*
    public bool AddSkill(GenericSkill skill)
    {
        if (WebsiteResources.SkillsAndTech.Contains(skill) && !m_skills.Contains(skill))
        {
            return false;
        }
        m_skills.Add(skill);
        return true;
    }
}





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
