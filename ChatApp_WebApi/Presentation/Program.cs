using BusinessLogic;
using DataAccess;
using Presentation.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configurationManager = builder.Configuration;

// Add services to the container.
services.AddDbContextConfiguration(configurationManager);
services.AddIdentityConfiguration();
services.AddDataAccess();
services.AddBusinessLogic();

// Add configuration for api & related.
services.AddOptionsConfiguration();
services.AddWebApiConfiguration();
services.AddSwaggerConfiguration();

// Add configuration for authentication & authorization.
services.AddAuthenticationConfiguration(configurationManager);
services.AddAuthorizationConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(setupAction: swaggerOptions =>
{
    swaggerOptions.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json",
        name: SwaggerConfiguration.SwaggerDocVersion);

    swaggerOptions.RoutePrefix = string.Empty;

    swaggerOptions.DefaultModelsExpandDepth(depth: -1);
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
