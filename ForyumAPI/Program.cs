using ApplicationCore.Security;
using ForyumAPI.Repositories;
using ForyumAPI.Security;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var key = builder.Configuration.GetValue<string>("JWT:Key");
var issuer = builder.Configuration.GetValue<string>("JWT:Issuer");

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSingleton<IPasswordHelper, PasswordHelper>();
builder.Services.AddSingleton<IJWTHelper>(new JWTHelper(key, issuer));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsBuilder =>
        corsBuilder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup JWT Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidIssuer = key,
            ValidAudience = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

// ----------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
