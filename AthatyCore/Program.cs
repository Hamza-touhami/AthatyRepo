using AthatyCore.CustomMiddlewares;
using AthatyCore.Helpers;
using AthatyCore.Repositories;
using AthatyCore.Services;
using AthatyCore.Settings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using AthatyCore.Entities;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

/* Dependencies Injection */
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Setting up MongoDB connection

//Serializing string as string
//BsonSerializer.RegisterSerializer(new stringSerializer(MongoDB.Bson.BsonType.String));

//Serializing DateTimeOffset as string
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));

var mongoDBSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();

//Registering DbContext dependency (Dependency Injection)
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Registering IMongoClient dependency (Dependency Injection)
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDBSettings.ConnectionToken);
});

//Injecting Item Repository used for this API (SqlServerRepository)
builder.Services.AddTransient<ICollectionRepository, SqlServerRepository>();

//Injecting Item Repository used for this API (MongoDBRepository)
//builder.Services.AddSingleton<ICollectionRepository, MongoDbRepository>();




//Authentication services

    //Configure strongly typed AuthenticationSettings
    builder.Services.Configure<AuthenticationSettings>(builder.Configuration.GetSection("AuthenticationSettings"));

    //Inject UserService service for authentication
    builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();


/* Middlewares */
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//TEST
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
//Do not use Authentication & Authorization built-in middlewares, use custom jwt middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
