using DATA.Interface;
using DATA.Models;
using DATA.Services;
using LOGIC.Implementation;
using LOGIC.Interface;
using LOGIC.Model;
using portfolioapi;

Helper.SetEbConfig();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICandidateInterface, CandidateService>();
builder.Services.AddScoped<ICandidateOperations, CandidateOperations>();
builder.Services.AddScoped<ILocationOperations, LocationOperations>();

builder.Services.AddScoped<ILocationInterface, LocationServices>();
builder.Services.AddScoped<IHttpOperations, HttpOperations>();

builder.Services.AddScoped<IListingOperations, ListingOperations>();
builder.Services.AddScoped<IListingInterface, ListingService>();


builder.Services.AddScoped(typeof(ICommonInterface<,>), typeof(CommonService<,>));


/*builder.Logging.ClearProviders();
builder.Logging.AddConsole();*/

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
    options => options.WithOrigins("http://localhost:3000/").AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
