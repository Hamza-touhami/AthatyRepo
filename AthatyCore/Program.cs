using AthatyCore.Repositories;
using AthatyCore.Settings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

/* Dependencies Injection */
// Add services to the container.
builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Setting up MongoDB connection

//Serializing GUID as string
BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));

//Serializing DateTimeOffset as string
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));

var mongoDBSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();

//Registering IMongoClient dependency (Dependency Injection)
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDBSettings.ConnectionToken);
});

//Injecting Item Repository used for this API (MongoDBRepository)

builder.Services.AddSingleton<IItemRepository, MongoDBItemRepository>();
builder.Services.AddSingleton<ICategoryRepository, MongoDBCategoryRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
