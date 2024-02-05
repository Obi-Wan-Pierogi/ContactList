using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContactList.Server.Data;
using ContactList.Server.Areas.Identity.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ContactListServerContextConnection") ?? throw new InvalidOperationException("Connection string 'ContactListServerContextConnection' not found.");

builder.Services.AddDbContext<ContactListServerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ServerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContactListServerContext>();

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
