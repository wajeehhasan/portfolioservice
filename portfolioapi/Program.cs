using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using DATA.Interface;
using DATA.Models;
using DATA.Services;
using LOGIC.Implementation;
using LOGIC.Interface;
using LOGIC.Model;
using portfolioapi;
using Amazon.Extensions.NETCore.Setup;

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
builder.Services.AddScoped<IDynamodbUserOperations, DynamodbUserOperations>();
builder.Services.AddScoped<ICandidateOperations, CandidateOperations>();
builder.Services.AddScoped<ILocationOperations, LocationOperations>();
builder.Services.AddScoped<IDynamodbUserOperations, DynamodbUserOperations>();
builder.Services.AddScoped<IDynamoUserInterface, DyUserService>();

builder.Services.AddScoped<ILocationInterface, LocationServices>();
builder.Services.AddScoped<IHttpOperations, HttpOperations>();

builder.Services.AddScoped<IListingOperations, ListingOperations>();
builder.Services.AddScoped<IListingInterface, ListingService>();


builder.Services.AddScoped(typeof(ICommonInterface<,>), typeof(CommonService<,>));


/*builder.Logging.ClearProviders();
builder.Logging.AddConsole();*/

builder.Services.AddHttpClient();

builder.Services.AddDefaultAWSOptions(new AWSOptions
{
    Credentials = new Amazon.Runtime.BasicAWSCredentials(Environment.GetEnvironmentVariable("AWS_USERNAME"), Environment.GetEnvironmentVariable("AWS_PW")),
    Region = Amazon.RegionEndpoint.APSoutheast2 
});
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseHsts();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
