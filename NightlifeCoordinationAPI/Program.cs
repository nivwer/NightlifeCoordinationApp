using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NightlifeCoordinationAPI.Data;
using NightlifeCoordinationAPI.FrontEndClient.settings;
using NightlifeCoordinationAPI.Services.YelpAPIService;
using NightlifeCoordinationAPI.YelpAPI.settings;

var builder = WebApplication.CreateBuilder(args);

// DB Context (SqLite)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

// Identity Endpoints
builder
    .Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// YelpAPI HttpClient
var YelpAPIConfig = builder.Configuration.GetSection("YelpAPI").Get<YelpAPISettings>()!;
builder.Services.AddHttpClient(
    "YelpAPI",
    client =>
    {
        client.BaseAddress = new Uri(YelpAPIConfig.BaseUrl);
        client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", YelpAPIConfig.Key);
    }
);

// CORS (Cross-origin resource sharing)
var AllowSpecificOrigins = "AllowSpecificOrigin";

var FrontEndClientConfig = builder
    .Configuration.GetSection("FrontEndClient")
    .Get<FrontEndClientSettings>()!;

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins(FrontEndClientConfig.BaseUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});

// Scopes
builder.Services.AddScoped<IYelpAPIService, YelpAPIService>();

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// BUILD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();
