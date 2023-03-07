using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Razor_IdentityDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("AuthDbConnection");
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

// S�g att v�r user �r IdentityUser, l�gg till Identity i DI container och L�gg till alla kolumner som h�nger ihop med Identity i databasen.
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
