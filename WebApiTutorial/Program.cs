using Microsoft.EntityFrameworkCore;
using WebApiTutorial.Models;

var builder = WebApplication.CreateBuilder(args); //makes tool builder

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(x => { //injecting DbContext into the app; can update with how Dbcontext is modified such as more tables etc
    string ConnectionKey = "Prod";

#if DEBUG //precompiled statement that can change code based on solution config (release vs debug). 
    //happen before the code is compiled.
    ConnectionKey = "Dev";
#endif
    x.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionKey)); //put the actual key value in the GetConnectionString for the first run
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => {
    x.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

//creates a scope for the service provider
using var scope = app.Services
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
//uses scope to setup migration
scope.ServiceProvider
        .GetService<AppDbContext>()!
        .Database.Migrate();
//together these two update the database if there are any updates pending or migrations applied.

app.Run();
