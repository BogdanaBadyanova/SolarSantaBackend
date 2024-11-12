using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using SecretSanta.Domain;
using SecretSanta.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SecretSantaContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("SecretSantaContext") ?? throw new InvalidOperationException("Connection string 'SecretSantaContext' not found.")));
// builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//   .AddEntityFrameworkStores<SecretSantaContext>()
//   .AddDefaultTokenProviders();
// builder.Services.AddAuthentication(options =>
//   {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//   })
//   .AddJwtBearer(options =>
//   {
//     options.SaveToken = true;
//     options.RequireHttpsMetadata = false;
//     options.TokenValidationParameters = new TokenValidationParameters()
//     {
//       ValidateIssuer = true,
//       ValidateAudience = true,
//       ValidAudience = builder.Configuration["JWT:ValidAudience"],
//       ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
//     };
//   });

// builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();

builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
  });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
  option.SwaggerDoc("v1", new OpenApiInfo { Title = "SecretSanta API", Version = "v1" });
  // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  // option.IncludeXmlComments(xmlPath);
  option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  option.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
      new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference
        {
          Type=ReferenceType.SecurityScheme,
          Id="Bearer"
        }
      },
      new string[]{}
    }
  });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  // var serviceProvider = scope.ServiceProvider;
  // var context = serviceProvider.GetRequiredService<SecretSantaContext>();

  // context.Database.Migrate();
}
 
app.UseCors(builder =>
{
  builder.WithOrigins("https://solar-santa.vercel.app", "http://localhost:4200")
    .AllowAnyHeader()
    .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
    .AllowCredentials();
});

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
  app.UseSwagger();
  app.UseSwaggerUI();
// }

  app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
