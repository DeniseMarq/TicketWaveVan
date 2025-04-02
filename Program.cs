using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketWave.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting;
using TicketWave.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TicketWaveContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TicketWaveContext") ?? throw new InvalidOperationException("Connection string 'TicketWaveContext' not found.")));
// use SQLite in development and SQLServer in production
// if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContext<TicketWaveContext>(options =>
//        options.UseSqlite(builder.Configuration.GetConnectionString("TicketWaveContext")));
//}
// else
//{
//    builder.Services.AddDbContext<TicketWaveContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionTicketWaveContext")));
//}
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ✅ Call SeedData to ensure test data is inserted
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
