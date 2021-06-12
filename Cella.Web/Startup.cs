using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Cella.Models;
using MISSystem.Web.Helpers;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using Microsoft.CodeAnalysis.Options;

using System.IO;

using NToastNotify;
using Mindscape.Raygun4Net.AspNetCore;
using Microsoft.AspNetCore.Http;
using SharedResourceLib.Lng;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

using Microsoft.AspNetCore.Identity.UI.Services;

using Newtonsoft.Json.Serialization;

using Newtonsoft;
using AutoMapper;

using Warehouse.Dal;
using Warehouse.Domain;
using WareHouseCrm.Web.Services;
using WareHouseCrm.Web.AutoMapper;
using Cella.Infrastructure;
using Cella.WebHost.Extensions;
using Cella.Infrastructure.Modules;
using Cella.Domain.Interfaces;
using Warehouse.Web.Helpers;
using WarehouseCrm.Web.Helpers;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Cella.BL.Intefaces;
using Cella.BL.Services;
using Cella.Infrastructure.Web;
using Cella.BL;
using Cella.BL.Interfaces;
using Cella.Domain;
using Cella.Infrastructure.Interface.Localization;
using Cella.Infrastructure.Helpers;
using Cella.Infrastructure.Interface;

namespace Warehouse.Web
{
    public class Startup
    {
        private string _crmAPiKey = null;
        private string extensionsPath;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppConfig.WebRootPath = _hostingEnvironment.WebRootPath;
            AppConfig.ContentRootPath = _hostingEnvironment.ContentRootPath;
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            services.AddModules();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            _crmAPiKey = Configuration["CrmApiKey:ServiceApiKey"];
            services.AddSingleton<LocalizationService>();
            services.AddDbContext<CellaDBContext>
        (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddHttpContextAccessor();

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
                config.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                config.User.RequireUniqueEmail = true;

            })
            .AddDefaultUI()
            .AddRoles<IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<CellaDBContext>();
            services.AddControllersWithViews()
        .AddDataAnnotationsLocalization();
            services.Configure<CookiePolicyOptions>(options =>
            {

              
                options.CheckConsentNeeded = context => false; // consent required
                
        options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(opts =>
            {
                opts.Cookie.Path = "/";
                opts.Cookie.HttpOnly = false;
                opts.Cookie.IsEssential = true; // make the session cookie Essential
                
    });

            services.AddRazorPages()
            .AddSessionStateTempDataProvider();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ToastClass = "alert",

            });
            services.AddCustomizedMvc(GlobalConfiguration.Modules);
            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander()); });
            services.AddTransient<IThemeService, ThemeService>();
            services.AddTransient<ILocalizationService, Cella.Infrastructure.Services.Localization.LocalizationService>();
            services.AddTransient<CellaDBContext>();
            services.AddTransient<IWebHelper, WebHelper>();


            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
        new CultureInfo("en"),
        new CultureInfo("fr")
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-GB");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
        {
    new QueryStringRequestCultureProvider(),
    new CookieRequestCultureProvider()
            };
            }).AddControllersWithViews()

                .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
        .AddViewLocalization(options => options.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });
            services.AddMvc()
              .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ToastClass = "alert",

            });
            services.AddControllers(config =>
            {
              //  using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<IdentityOptions>(options =>
            {

        // Default Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;


            });
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Identity/Account/Login/";

            });
            services.AddSingleton<ISharedResource, SharedResource>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
   

            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddAutoMapper
        (typeof(AutoMapperProfile).Assembly);

            foreach (var module in GlobalConfiguration.Modules)
            {
                var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                {
                    var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
                    services.AddSingleton(typeof(IModuleInitializer), moduleInitializer);
                    moduleInitializer.ConfigureServices(services);
                }
            }
            services.AddAuthorization(options =>
        options.AddPolicy("TwoFactorEnabled",
            x => x.RequireClaim("amr", "mfa")));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager,
RoleManager<IdentityRole> roleManager)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
              app.UseRequestLocalization(locOptions.Value);


            //    var supportedCultures = new[]
            //    {
            //new CultureInfo("en-US"),
            //new CultureInfo("en-GB"),
            //new CultureInfo("es"),
            //new CultureInfo("fr")
            //};
            //    app.UseRequestLocalization(new RequestLocalizationOptions()
            //    {
            //        DefaultRequestCulture = new RequestCulture("en-GB"),
            //        SupportedCultures = supportedCultures,
            //        SupportedUICultures = supportedCultures
            //    });

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions() { SourceCodeLineCount = 30 });
                //  app.UseDatabaseErrorPage();
                // app.UseExceptionHandler("/Home/Error");

            }
            else
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions() { SourceCodeLineCount = 30 });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        

            app.UseNToastNotify();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCustomizedStaticFiles(env);

            app.UseAuthentication();
            app.UseAuthorization();


           
            app.UseEndpoints(endpoints =>
            {
                //change currency
                endpoints.MapControllerRoute(name: "ChangeCurrency",
                    pattern: $"en-GB/changecurrency/{{customercurrency:min(0)}}",
                    defaults: new { controller = "Common", action = "SetCurrency" });


                endpoints.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();

            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
        }
    }
}
