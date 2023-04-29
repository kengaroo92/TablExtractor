namespace TablExtractor
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Create the web application builder
            var builder = WebApplication.CreateBuilder(args);

            // -------------------------
            // Configure services
            // -------------------------

            // Add Razor pages services
            builder.Services.AddRazorPages();

            // Build the web application
            var app = builder.Build();

            // -------------------------
            // Configure middleware
            // -------------------------

            // Use error handling middleware for non-development environments
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); // Enable HSTS (HTTP Strict Transport Security)
            }

            // Use HTTPS redirection and serve static files
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Configure routing and authorization
            app.UseRouting();
            app.UseAuthorization();

            // Map Razor pages
            app.MapRazorPages();

            // Run the web application
            app.Run();
        }
    }
}