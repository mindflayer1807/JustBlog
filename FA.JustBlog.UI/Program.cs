using FA.JustBlog.Core;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.category;
using FA.JustBlog.Service.comment;
using FA.JustBlog.Service.mapper_config;
using FA.JustBlog.Service.post;
using FA.JustBlog.Service.tag;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JustBlogContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapperConfig));


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseStatusCodePages(appError =>
{
    appError.Run(async context =>
    {
        var respone = context.Response;
        var code = respone.StatusCode;

        var content = @$"
            <html>
                <head>
                    <meta charset='UTF-8'/>
                    <title> Lỗi {code} </title>
                </head>
                <body>
                    <p style='color:red; font-size:30px'>Có lỗi xảy ra: {code} - {(HttpStatusCode)code} </p>
                </body>
            </html>";

        await respone.WriteAsync(content);
    });
}
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
        areaName: "Admin",
        name: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();

