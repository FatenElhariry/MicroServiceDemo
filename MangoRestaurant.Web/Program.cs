using MangoRestaurant.Web.Extensions;

namespace MangoRestaurant.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            
            // 
            builder.Services.Register(builder.Configuration );

            builder.Services.AddAuthentication(c =>
            {
                c.DefaultChallengeScheme = "oidc";
                c.DefaultScheme = "Cookies";

            }).AddCookie("Cookies", c=> c.ExpireTimeSpan = TimeSpan.FromMinutes(10) )
            .AddOpenIdConnect("oidc", option =>
            {
                option.Authority = builder.Configuration["Services:IdentityServiceUrl"];
                option.GetClaimsFromUserInfoEndpoint = true;
                option.ClientId = "Mango";
                option.ClientSecret = "secret";
                option.ResponseType = "code";
                

                option.TokenValidationParameters.NameClaimType = "Name";
                option.TokenValidationParameters.RoleClaimType = "Role";
                option.Scope.Add("mango");

                option.SaveTokens = true;
            });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}