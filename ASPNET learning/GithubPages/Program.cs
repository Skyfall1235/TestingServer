using GithubPages.Data;
using GithubPages.Services;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//saving services
builder.Services.AddSingleton<SkillSaverService>();
builder.Services.AddSingleton<ProjectSaverService>();
RateLimiterOptions options = new();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//beyond here is where we can map gets and posts
//for now, lets design a get and post for infgormation, and what info is needed.

//we can also design a resource for all the relevent m_skills i have used!

WebsiteResources resources = new WebsiteResources(); //so we can modify it at runtime if need be :)
//load all project data in
WebsiteResources.Projects = WebsiteResources.LoadProjectsFromJson("wwwroot/projects.json");
List<GenericSkill> allSkills = WebsiteResources.PullSkillsFromOpenProjects(WebsiteResources.Projects);
//load all skills FROM the projects into the json, and then add al lthe skills to the global list
WebsiteResources.SaveSkillsToJson(allSkills, "wwwroot/Skills.json");
WebsiteResources.SkillsAndTech.BatchAddSkills(WebsiteResources.LoadSkillsFromJson("wwwroot/Skills.json"), true);

// Create an endpoint group for versioning or better organization
var api = app.MapGroup("/api");

// app.MapGet for the "/skills" endpoint
app.MapGet("/skills", () =>
{
    // Convert the dictionary values into a list of SkillDTOs
    var skillsList = WebsiteResources.SkillsAndTech.Skills.Values
        .OrderBy(skill => skill.SkillCategory)
        .Select(skill => new SkillDTO(
        skill.Name, 
        skill.ImageSource, 
        skill.SkillCategory.ToString() ?? "Unknown"))
        .ToList(); // Convert the result to a List

    return skillsList; // Return the list of SkillDTO objects
});

app.MapGet("/Links", () =>
{
//ill come back to this later :)
    return CommonErrors.NoContent;
});
app.MapGet("/Links/Github", () =>
{
    return WebsiteResources.GithubProfile;
});



#region Project Gets
// app.MapGet for the "/projects" endpoint
app.MapGet("/projects", () =>
{
    return WebsiteResources.Projects;
});

// Add new endpoints for retrieving single items by ID
api.MapGet("/projects/{index}", (int index) =>
{
    // Find a single project by ID.
    // Replace this with a database call or proper data source.
    if(WebsiteResources.Projects.Count > index)
    {
        return Results.NotFound();
    }
    var project = WebsiteResources.Projects[index];
    return project != null ? Results.Ok(project) : Results.NotFound();
});
// Add a new endpoint for retrieving a single project by title
api.MapGet("/projects/by-title/{title}", (string title) =>
{
    // Find a single project by title, using case-insensitive comparison.
    var project = WebsiteResources.Projects.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    return project != null ? Results.Ok(project) : Results.NotFound();
});
#endregion

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

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
 * - build an API key for secure access
 * - use API key to allow select post requests
 * 
 * part 3 : Saving data as files when the server needs to power down
 * -determine storage technique
 * -load existing data oin start up
 * -unload on shutdown
 * 
 * 
 * 
 */

//WEBSITE MODIFICATIONS
/*
 * so we need a way to dynamically load the content that doesnt invole a modificatyion of the site every time
 * what if we have 2 pages, the hero page, and a dynamic mpage, we can modify the headers and the URL will just be "projects"
 * we direct people to that and hotload the info there. so 1 page for all projects. depening on whatyp roject is hotloaded!
*/
