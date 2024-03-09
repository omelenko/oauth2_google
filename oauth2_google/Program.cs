using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using oauth2_google.Data;
using System;
using MailKit.Net.Smtp;
using MailKit;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
const string defaultCulture = "en-GB";
var supportedCultures = new[]
{
    new CultureInfo(defaultCulture),
    new CultureInfo("uk-UA")
};
builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(); 

var app = builder.Build();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
/*var email = new MimeMessage();

email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));

email.Subject = "Testing out email sending";
email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
{
    Text = "Hello all the way from the land of C#"
};
using (var smtp = new SmtpClient())
{
    smtp.Connect("smtp.gmail.com", 587, false);

    // Note: only needed if the SMTP server requires authentication
    smtp.Authenticate("smtp_username", "smtp_password");

    smtp.Send(email);
    smtp.Disconnect(true);
}*/
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
