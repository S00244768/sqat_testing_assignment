namespace InsuranceService.Web
{
    public class Runner
    {
        public static void Run(string url, string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            {
                WebRootPath = "../../../../InsuranceService.Web/wwwroot",
                ContentRootPath = "../../../../InsuranceService.Web/Pages",
                Args = args
            });

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.RunAsync(url);
        }
    }
}
