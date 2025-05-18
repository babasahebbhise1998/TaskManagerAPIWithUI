using Microsoft.EntityFrameworkCore;
using TaskMangerWebAPI.DataContext;
using TaskMangerWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseInMemoryDatabase("TaskDb"));
// Add services to the container.
builder.Services.AddScoped<TaskService>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultFiles(); // Enables index.html to be served by default
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
