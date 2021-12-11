using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ReQuests.Api.Auth;
using ReQuests.Data;
using System.Text.Json.Serialization;

namespace ReQuests.Api;

public static class Startup
{
	// Add services to the container.
	public static void ConfigureServices( WebApplicationBuilder builder )
	{
		//_ = builder.Logging.ClearProviders();
		_ = builder.Logging.AddSimpleConsole();

		_ = builder.Services.AddControllers()
			.AddXmlSerializerFormatters()
			.AddJsonOptions( options =>
			{
				options.JsonSerializerOptions.Converters.Add( new JsonStringEnumConverter() );
			} );

		_ = builder.Services.AddEndpointsApiExplorer();
		_ = builder.Services.AddSwaggerGen( c =>
		  {
			  c.SwaggerDoc( "v1", new OpenApiInfo { Title = "ReQuests.Api", Version = "v1" } );

			  var securityScheme = new OpenApiSecurityScheme
			  {
				  Scheme = Constants.Auth.BearerSheme,
				  Name = "Authorization",
				  In = ParameterLocation.Header,
				  Type = SecuritySchemeType.Http,
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

			  c.MapType<TimeSpan>( () => new OpenApiSchema() { Title = "ISO_8601_Duration", Type = "string", Example = new OpenApiString( "P3DT12H30M" ) } );
		  } );

		_ = builder.Services.AddAuthentication( options =>
		{
			options.DefaultScheme = Constants.Auth.DefaultSheme;
			options.DefaultAuthenticateScheme = Constants.Auth.DefaultSheme;
			options.DefaultChallengeScheme = Constants.Auth.DefaultSheme;
		} )
			.AddScheme<TokenOptions, TokenAuthHandler>( Constants.Auth.BearerSheme, options => { } );

		_ = builder.Services.AddNpgsql<AppDbContext>(
			 GetConnectionString( builder ),
			 pgob => pgob.MigrationsAssembly( "ReQuests.Migrations.Pg" ),
			 ob => ob.UseLoggerFactory( LoggerFactory.Create( factoryBuilder => factoryBuilder.AddConsole() ) )
			 );

		builder.Services.TryAddSingleton<ISystemClock, SystemClock>();
		_ = builder.Services.AddScoped<IUsersService, UsersService>();
		_ = builder.Services.AddScoped<IRolesService, RolesService>();
		_ = builder.Services.AddScoped<IAuthService, AuthService>();
		_ = builder.Services.AddScoped<IQuestsService, QuestsService>();
	}

	// Configure the HTTP request pipeline.
	public static void Configure( WebApplication app )
	{
		_ = app.UseCors( builder => builder
				.SetIsOriginAllowed( origin => true )
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
			   );

		//if ( app.Environment.IsDevelopment() )
		//{
		_ = app.UseSwagger();
		_ = app.UseSwaggerUI();
		//}

		var isHeroku = Environment.GetEnvironmentVariable( "HOST" ) == "HEROKU";
		if ( isHeroku )
		{
			_ = app.Use( HerokuRedirect );
		}
		else
		{
			_ = app.UseHttpsRedirection();
		}

		_ = app.UseAuthentication();
		_ = app.UseAuthorization();

		_ = app.Map( "/", ( HttpContext context ) => context.Response.Redirect( "swagger/index.html" ) );
		_ = app.MapControllers();

		if ( isHeroku )
		{
			var port = Environment.GetEnvironmentVariable( "PORT" ) ?? throw new NullReferenceException( "port not specified" );
			app.Urls.Add( $"http://*:{port}" );
		}
	}


	static string GetConnectionString( WebApplicationBuilder builder )
	{
		string? url = Environment.GetEnvironmentVariable( "DATABASE_URL" );
		if ( string.IsNullOrEmpty( url ) )
		{
			string str = builder!.Configuration.GetConnectionString( "postgresConnection" );
			if ( string.IsNullOrEmpty( str ) )
			{
				throw new NullReferenceException( "connection string not specified" );
			}

			return str;
		}

		Uri uri = new( url );

		var host = uri.Host;
		var database = uri.Segments[1].Trim( '/' );

		var userinfo = uri.UserInfo.Split( ':' );
		var username = userinfo[0];
		var password = userinfo[1];

		return $"Host={host};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";
	}

	static Task HerokuRedirect( HttpContext context, RequestDelegate _next )
	{
		if ( context.Request.Headers["x-forwarded-proto"] != "https" )
		{
			context.Response.StatusCode = 307;
			var request = context.Request;
			var host = request.Host;
			var redirectUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(
				"https",
				host,
				request.PathBase,
				request.Path,
				request.QueryString );
			context.Response.Redirect( redirectUrl, false, true );
			return Task.CompletedTask;
		}
		return _next( context );
	}

}
