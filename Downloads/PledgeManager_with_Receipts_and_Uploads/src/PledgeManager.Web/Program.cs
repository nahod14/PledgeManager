
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PledgeManager.Infrastructure;
using PledgeManager.Web;

var builder = WebApplication.CreateBuilder(args);

// Db (SQLite for quick start)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Identity (minimal endpoints)
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

// Blazor (SSR + interactive server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

builder.Services.AddAuthorization();

// Storage & services
builder.Services.Configure<PledgeManager.Infrastructure.StorageOptions>(builder.Configuration.GetSection("Storage"));
builder.Services.AddScoped<PledgeManager.Infrastructure.IReceiptService, PledgeManager.Infrastructure.ReceiptService>();
builder.Services.AddScoped<PledgeManager.Infrastructure.IFileStorage, PledgeManager.Infrastructure.LocalFileStorage>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapIdentityApi<IdentityUser>();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/healthz", () => Results.Ok("ok"));

// await SeedData.InitAsync(app.Services); // DB + seed - disabled for now

app.Run();
