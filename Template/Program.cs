using Microsoft.EntityFrameworkCore;
using Template.Application.AutoMapper;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Data.Context;
using Template.Swagger;
using Template.IoC;
using System.Text;
using Template.Auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IUserService and UserService
builder.Services.AddScoped<IUserService, UserService>();

// disponibiliza o TemplateContext como conteiner de inje��o de depend�ncia
// disponibiliza a ser injetado em outras partes do projeto
builder.Services.AddDbContext<TemplateContext>(options => options.UseSqlServer(
    // puxa a string de conexao do appsettings.json    
    builder.Configuration.GetConnectionString("TemplateDB")
).EnableSensitiveDataLogging()); // ativa dados da app a serem inclu�dos nas mensagens de exce��o

// Register application services
NativeInjector.RegisterServices(builder.Services);

// Identifica��o de onde o AutoMapper pegar� as informa��es
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Authentication

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{   // configura��o objeto JwtBearer
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion


app.UseSwaggerConfigure();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// possibilita a aplica��o reconhercer e gerenciar as chaves privadas e publicas
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
