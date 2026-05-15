using CoreLTToeic.Application.Mapping;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Helper;
using CoreLTToeic.UI.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Penman.Blazor.Quill;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

var isDev = builder.Environment.IsDevelopment();
builder.Host.UseSerilog((ctx, services, cfg) =>
{
    cfg.ReadFrom.Configuration(ctx.Configuration)
       .ReadFrom.Services(services)
       .Enrich.FromLogContext()
       .WriteTo.Console()
       .WriteTo.File(
           path: Path.Combine(ctx.HostingEnvironment.ContentRootPath, "logs", "app-.log"),
           rollingInterval: RollingInterval.Day,
           retainedFileCountLimit: 7,
           outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}"
       )
       .MinimumLevel.Is(isDev ? LogEventLevel.Information : LogEventLevel.Warning)
       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
       .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAntDesign();
builder.Services.AddPenmanQuill();

builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddRepository();
builder.Services.AddService();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

var contentRoot = builder.Environment.ContentRootPath;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<CoreLTToeic.Infrastructure.Data.Seeders.ToeicTestSeeder>();
    await seeder.SeedAsync(Path.Combine(contentRoot, "SeedData", "toeic_test_1.json"));
}

app.Run();
