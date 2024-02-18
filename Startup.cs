// Startup.cs
using Gestion_des_entreprises_dans_la_registre_de_commerce_de_Suisse;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpClient();

        // Charger les configurations nécessaires
        services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
        services.Configure<ApiCredentials>(Configuration.GetSection("ApiCredentials"));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Liste des entreprises dans le registre de commerce Suisse", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Liste des entreprises dans le registre de commerce Suisse"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
