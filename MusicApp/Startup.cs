using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using AutoMapper;
using API.MappingProfiles;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Security;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using API.Identity;
using BLL.Models.Configurations;
using API.Interfaces;
using API.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using SpotifyAPI.Web;
using static SpotifyAPI.Web.Scopes;
using API;
namespace MusicApp
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(SpotifyClientConfig.CreateDefault());
            services.AddScoped<SpotifyClientBuilder>();
            services.Configure<SpotifySettings>(Configuration.GetSection("SpotifySettings"));
            services.Configure<CloudinarySetting>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<LastFmSetting>(Configuration.GetSection("LastFmSettings"));
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"), b => b.MigrationsAssembly("API"));
            });

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToResource());
                mc.AddProfile(new ResourceToModel());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddSingleton(mapper);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMineService, MineService>();
            services.AddScoped<IGenresService, GenreService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ISearchTrackService, SearchTrackService>();
            var tokenOptionsSection = Configuration.GetSection("TokenOptions");
            services.Configure<AppSettings>(tokenOptionsSection);
            var tokenOptions = tokenOptionsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);

            services.AddIdentity<User, IdentityRole>(option => {
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = false;
                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddUserManager<MyManager>();

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            
            services.AddHttpClient("LastFm",c=>
            {
                c.BaseAddress = new Uri("https://www.last.fm/api");

                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            services.AddHttpClient("Spotify", c =>
             {
                 c.BaseAddress = new Uri("https://api.spotify.com/v1");
                 
             });

            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options=>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
            
        }
    }
}
