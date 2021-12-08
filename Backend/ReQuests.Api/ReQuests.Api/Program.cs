global using ReQuests.Api.Services;
global using ReQuests.Api.Exceptions;
using ReQuests.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ReQuests.Api.Auth;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using ReQuests.Api;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
	c.SwaggerDoc( "v1", new OpenApiInfo { Title = "ReQuests.Api", Version = "v1" } );

	var securityScheme = new OpenApiSecurityScheme
	{
		Scheme = Constants.Auth.BearerSheme,
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Description = "Authorization header. Example: 'Authorization: Bearer {token}'",

		Reference = new OpenApiReference
		{
			Id = Constants.Auth.BearerSheme,
			Type = ReferenceType.SecurityScheme
		}
	};

	c.AddSecurityDefinition( Constants.Auth.BearerSheme, securityScheme );
	c.AddSecurityRequirement( new OpenApiSecurityRequirement()
	{
		{ securityScheme, Array.Empty<string>() }
	} );

	c.MapType<TimeSpan>( () => new OpenApiSchema() { Title= "ISO_8601_Duration", Type = "string", Example = new OpenApiString( "P3DT12H30M" ) } );
} );

builder.Services.AddAuthentication( options =>
	{
		options.DefaultScheme = Constants.Auth.DefaultSheme;
		options.DefaultAuthenticateScheme = Constants.Auth.DefaultSheme;
		options.DefaultChallengeScheme = Constants.Auth.DefaultSheme;
	} )
	.AddScheme<TokenOptions, TokenAuthHandler>( Constants.Auth.BearerSheme, options => { } );

builder.Services.AddNpgsql<AppDbContext>(
	builder.Configuration.GetConnectionString( "postgresConnection" ),
	 pgob => pgob.MigrationsAssembly( "ReQuests.Migrations.Pg" ),
	 ob => ob.UseLoggerFactory( LoggerFactory.Create( factoryBuilder => factoryBuilder.AddConsole() ) )
	 );

builder.Services.TryAddSingleton<ISystemClock, SystemClock>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IQuestsService, QuestsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
	_ = app.UseSwagger();
	_ = app.UseSwaggerUI();
}

_ = app.UseHttpsRedirection();

_ = app.UseAuthentication();
_ = app.UseAuthorization();

_ = app.MapControllers();

app.Run();
