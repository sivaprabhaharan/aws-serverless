using static Function.Controllers.ValuesController;

namespace Function;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.Use(async (context, next) =>
        {
            if (context.Request.Path != "/hello")
            {
                var response = new LambdaResponse
                {
                    statusCode = 400,
                    message = $"Bad request syntax or unsupported method. Request path: {context.Request.Path}. HTTP method: {context.Request.Method}"
                };
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(response);
                return;
            }
            await next(context);
        });

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}