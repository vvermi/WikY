using WikY.Middlewares;
using Repositories;
using Repositories.Contracts;
using Business;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(o =>
{
    //o.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WikY_DB;Trusted_Connection = True; ");
    o.UseSqlServer(builder.Configuration.GetConnectionString("WikY_DB"));
});

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleBusiness, ArticleBusiness>();
builder.Services.AddScoped<ICommentaireRepository, CommentaireRepository>();
builder.Services.AddScoped<ICommentaireBusiness, CommentaireBusiness>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var appDbContext = services.GetRequiredService<Context>();
    appDbContext.Database.EnsureDeleted();
    appDbContext.Database.EnsureCreated();
}


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

//app.UseRedirect404();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
