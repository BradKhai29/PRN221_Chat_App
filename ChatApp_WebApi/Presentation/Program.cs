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

services.AddWebApiConfiguration();
services.AddSwaggerConfiguration();
services.AddAuthenticationConfiguration(configurationManager);
services.AddAuthorizationConfiguration(configurationManager);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(setupAction: options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: SwaggerConfiguration.SwaggerDocVersion);
    options.RoutePrefix = string.Empty;
    options.DefaultModelsExpandDepth(depth: -1);
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();