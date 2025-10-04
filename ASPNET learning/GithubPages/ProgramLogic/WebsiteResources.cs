using GithubPages.Data;
using GithubPages.Data.Projects;
using System.Text.Json;
using System.Text.Json.Serialization;

public class WebsiteResources
{
    public static List<Project> Projects = new();
    public static SkillsAndTech SkillsAndTech = new SkillsAndTech();
    public static string GithubProfile = "https://github.com/Skyfall1235";
    static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Loads a list of Project objects from a JSON file at the specified file path.
    /// </summary>
    /// <param name="filePath">The path to the JSON file.</param>
    /// <returns>A list of Project objects, or an empty list if an error occurs.</returns>
    public static List<Project> LoadProjectsFromJson(string filePath)
    {
        try
        {
            //read all text
            string jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            //deserialize and print it to console as part of the loading process
            var projects = JsonSerializer.Deserialize<List<Project>>(jsonString, options);

            if (projects != null)
            {
                foreach (Project project in projects)
                {
                    Console.WriteLine($"Project Loaded: " + project?.Title);
                }
            }

            return projects ?? new List<Project>();
        }
        //dozens of exceptions to catch the littany of problems that can occur
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        return new List<Project>();
    }

    /// <summary>
    /// Saves a list of Project objects to a JSON file.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    /// <param name="filePath">The path to the JSON file.</param>
    public static void SaveProjectsToJson(List<Project> projects, string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(projects, options);

            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"Successfully saved project data to '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads a list of GenericSkill objects from a JSON file.
    /// </summary>
    /// <param name="filePath">The path to the JSON file.</param>
    /// <returns>A list of GenericSkill objects, or an empty list if the file is not found or an error occurs.</returns>
    public static List<GenericSkill> LoadSkillsFromJson(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found.");
                return new List<GenericSkill>();
            }

            string jsonString = File.ReadAllText(filePath);
            var skills = JsonSerializer.Deserialize<List<GenericSkill>>(jsonString);
            return skills ?? new List<GenericSkill>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON from '{filePath}': {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while reading the file: {ex.Message}");
        }

        return new List<GenericSkill>();
    }

    /// <summary>
    /// Saves a list of GenericSkill objects to a JSON file.
    /// </summary>
    /// <param name="skills">The list of skills to save.</param>
    /// <param name="filePath">The path to the JSON file.</param>
    public static void SaveSkillsToJson(List<GenericSkill> skills, string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(skills, options);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Successfully saved skill data to '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
        }
    }
    public WebsiteResources() { }
}
