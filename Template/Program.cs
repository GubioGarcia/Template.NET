using Microsoft.EntityFrameworkCore;
using Template.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// disponibiliza o TemplateContext como conteiner de injeção de dependência
// disponibiliza a ser injetado em outras partes do projeto
builder.Services.AddDbContext<TemplateContext>(options => options.UseSqlServer(
    // puxa a string de conexao do appsettings.json    
    builder.Configuration.GetConnectionString("TemplateDB")
).EnableSensitiveDataLogging()); // ativa dados da app a serem incluídos nas mensagens de exceção

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
