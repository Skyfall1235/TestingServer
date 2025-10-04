using GithubPages.Data;
using GithubPages.Data.Projects;
using GithubPages.Services;
using Microsoft.AspNetCore.Http.HttpResults;


var builder = WebApplication.CreateBuilder(args);

#region Swagger and general app setup 
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region saving services
builder.Services.AddSingleton<SkillSaverService>();
builder.Services.AddSingleton<ProjectSaverService>();
builder.Services.AddSingleton<AdminAuthorizationService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#endregion

#region Main logic Setup
string ProjectJsonLocalPath = app.Configuration["ProjectJsonLocalPath"] ?? throw new InvalidOperationException("ProjectJsonLocalPath configuration setting is missing or empty.");
string SkillsJsonLocalPath = app.Configuration["SkillsJsonLocalPath"] ?? throw new InvalidOperationException("skillJsonLocation configuration setting is missing or empty.");

//bring our resources in
WebsiteResources resources = new WebsiteResources();

//load all project data in
WebsiteResources.Projects = WebsiteResources.LoadProjectsFromJson(ProjectJsonLocalPath);
List<string> allSkills = WebsiteResources.Projects.SelectMany(p => p.Skills).Distinct().ToList();

#region debug for the skills and stuff for setup since its a few steps
Console.WriteLine("Loading all Skills as Strings");
foreach (var skill in allSkills)
{
    Console.WriteLine("prepped Skill: " + skill.ToString());
}

List<GenericSkill> skills = WebsiteResources.LoadSkillsFromJson(SkillsJsonLocalPath);
WebsiteResources.SkillsAndTech.BatchAddSkills(skills, true);

Console.WriteLine("Loading all Skills from file");
foreach (GenericSkill skill in WebsiteResources.SkillsAndTech.Skills.Values)
{
    Console.WriteLine("Loaded Skill: " + skill.Name + " with category: " + skill.SkillCategory.ToString());
}

//add the sdkilsl to the global thing now :)
WebsiteResources.SkillsAndTech.BatchAddSkills(allSkills);
#endregion

#endregion

//TODO:
/* - add a post and get for up to date resume
 * - fix endpoint groups to match what they need to better organise the api
 * - redo the mapgroups to be better organized
 * - learn how to dynamically pull info from prior site to dynamically load the project onto a full page
 * - redo some of the documentation and logging processes
 * - fix skills per project are unavailable
 * - fix the learn more and github links for each project (embed them into the project class API side and serve them wit the rest of the content
 * -convert all maps to static async methods when possible
 */

#region API endpoints

#region come back to me later to work on saving projects and skills loaded from projects

//load all skills FROM the projects into the json, and then add all the skills to the global list
WebsiteResources.SaveSkillsToJson(WebsiteResources.SkillsAndTech.Skills.Values.ToList(), SkillsJsonLocalPath);
WebsiteResources.SkillsAndTech.BatchAddSkills(WebsiteResources.LoadSkillsFromJson(SkillsJsonLocalPath), true);

//endpoint groups
var portfolio = app.MapGroup("/portfolio");
var projects = portfolio.MapGroup("/projects");

#endregion

#region Gets
portfolio.MapGet("/skills", () =>
{
    var skillsList = WebsiteResources.SkillsAndTech.Skills.Values
        .OrderBy(skill => skill.SkillCategory)
        .Select(skill => new SkillDTO(
        skill.Name,
        skill.ImageSource,
        skill.SkillCategory.ToString() ?? "Unknown"))
        .ToList();

    return skillsList;
});

//mapget for getting all links. is this needed? kinda?
portfolio.MapGet("/Links", () =>
{
    //ill come back to this later :)
    return Results.NoContent;
});

// map get for the my girhub link (if i want to change this in the future)
portfolio.MapGet("/Links/Github", () =>
{
    return WebsiteResources.GithubProfile;
});

projects.MapGet("/", () =>
{
    return WebsiteResources.Projects;
});

//new endpoints for retrieving single items by ID
projects.MapGet("/{id}", GetGetProjectById);

static IResult GetGetProjectById(int id)
{
    var project = WebsiteResources.Projects.FirstOrDefault(p => p.Id == id);

    return project != null ? Results.Ok(project) : Results.NotFound();
}

//new endpoint for retrieving a single project by title
projects.MapGet("/{title}", GetProjectByStringTitle);

static IResult GetProjectByStringTitle(string title)
{
    var project = WebsiteResources.Projects.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    return project != null ? Results.Ok(project) : Results.NotFound();
}


#endregion

//DO NOT LET POSTS OF PATCHES RUN WITHOUT AUTHORIZATION
#region Project Posts and Patches

app.MapPost("/projects", (HttpContext context, Project newProject, AdminAuthorizationService authService, ProjectSaverService projectSaver) =>
{
    //auth first for posts
    var authResult = authService.Authorize(context);
    if (authResult is not Ok) return authResult;

    if (string.IsNullOrWhiteSpace(newProject.Title))
    {
        return Results.BadRequest("Project title is required.");
    }

    //saving the int here so we can insaert it as a value. i do not like longer 1liners than i have to
    int newID = WebsiteResources.Projects.Any() ? WebsiteResources.Projects.Max(p => p.Id) + 1 : 1;
    newProject.SetId(newID);

    WebsiteResources.Projects.Add(newProject);

    projectSaver.OnManualSave();

    return Results.Created($"/projects/{newProject.Id}", newProject);
});

app.MapPatch("/projects/{id}", (HttpContext context, int id, Project projectUpdates, AdminAuthorizationService authService, ProjectSaverService projectSaver) =>
{
    //use my new auth service
    var authResult = authService.Authorize(context);
    if (authResult is not Ok) return authResult;

    //ensure p[roject exists
    var existingProject = WebsiteResources.Projects.FirstOrDefault(p => p.Id == id);
    if (existingProject == null)
    {
        return Results.NotFound($"Project with ID {id} not found.");
    }

    //set new values when applicable
    existingProject.SetValues(projectUpdates.Title, projectUpdates.Description, projectUpdates.TitleCardURL, projectUpdates.Growth, projectUpdates.ProjectOverview);

    if (projectUpdates.Skills != null)
    {
        existingProject.Skills = projectUpdates.Skills;
    }

    //manual save because we dont want to lose the data on a crash
    projectSaver.OnManualSave();

    return Results.Ok(existingProject);
});

#endregion

#region Skill Post

app.MapPost("/skills", (HttpContext context, GenericSkill newSkill, AdminAuthorizationService authService, SkillSaverService skillSaver) =>
{
    //use auth to ensure only admin can mod
    var authResult = authService.Authorize(context);
    if (authResult is not Ok) return authResult;

    //do not allow blank skills in
    if (string.IsNullOrWhiteSpace(newSkill.Name))
    {
        return Results.BadRequest("Skill name is required.");
    }

    //do not allow conflicts
    if (WebsiteResources.SkillsAndTech.Skills.ContainsKey(newSkill.Name))
    {
        return Results.Conflict($"Skill with name '{newSkill.Name}' already exists.");
    }

    WebsiteResources.SkillsAndTech.Skills.Add(newSkill.Name, newSkill);

    return Results.Created($"/skills", newSkill);
});

#endregion

#endregion

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

//objectives for this API
/* - Have a get HTTP request for the skills
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
 * - determine storage technique
 * - load existing data oin start up
 * - unload on shutdown
 * 
 * 
 * 
 *  WEBSITE MODIFICATIONS
 *
 * so we need a way to dynamically load the content that doesnt invole a modificatyion of the site every time
 * what if we have 2 pages, the hero page, and a dynamic page, we can modify the headers and the URL will just be "projects"
 * we direct people to that and hotload the info there. so 1 page for all projects. depening on whatyp roject is hotloaded!
*/
