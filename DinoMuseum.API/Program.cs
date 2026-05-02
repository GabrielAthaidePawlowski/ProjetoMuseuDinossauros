using DinoMuseum.API.Data;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") 
                      ?? builder.Configuration.GetSection("MongoDbSettings:ConnectionString").Value;

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string not found.");
}


builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll"); 
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();