using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//we can also design a resource for all the relevent skills i have used!

//we should use app.use to inject middlware (basically to see if the source has an API key or something
//do it above the  resources

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
 * -determine storage technique
 * -load existing data oin start up
 * -unload on shutdown
 * 
 * 
 * 
 */

public class WebsiteResources
{
    //lets store things as big to small

    //to keep this compact, we can send them as 'projects'
    public class Project
    {
        //projects have skills, a title, a subtitle, probably a titlecard
            //since all projects will have these, they can be top level
        //projects also have a text wall, a code wall with text, or a png with text.
            //this should be inheritinace stuff

    }
}
