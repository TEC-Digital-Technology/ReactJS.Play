using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReactJS.Play.Frontend.Messaging;
using ReactJS.Play.Utils.Enums;
using System;
using TEC.Core.Web.Builder;
using TEC.Core.Web.Logging.Filters;
using TEC.Core.Web.WebApi.Builder;
using ReactJS.Play.Core.Logging;
using TEC.Core.Web.Logging;
using ReactJS.Play.Core.Extensions;
using TEC.Logging.Log4Net.Builder;

namespace ReactJS.Play.Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Microsoft.Extensions.Caching.Memory.MemoryCache memoryCache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCacheOptions()
            {
            });
            services.AddSingleton(typeof(Microsoft.Extensions.Caching.Memory.MemoryCache), memoryCache);
            services
            .AddLog4NetLoggingConfiguration<LoggingScope, LoggingSystemScope, LoggingMessageType, LogState>(LoggingScope.FrontEnd,options=>
            {
                options.LoggerRepositoryCreated = (repo) =>
                 {
                     
                 };
            })
            .AddRequestResponseLoggingOption(options =>
            {
                //建議由另一個類別管理紀錄封裝
                options.LogAspNetActionExecutingAction = (loggerFactory, data) =>
                {
                    loggerFactory.Log(new LogState()
                    {
                        ActivityId = data.ActivityId,
                        ExtendProperties = data.ActionArguments,
                        Exception = null,
                        IPAddress = data.IPAddress,
                        LoggingTriggerType = data.LoggingTriggerType ?? LoggingTriggerType.User,
                        LogLevel = LogLevel.Debug,
                        Message = $"執行請求-{data.ActionDisplayName}",
                        MessageType = LoggingMessageType.WebApiRequest,
                        Resource = data.ActionDisplayName,
                        Scope = LoggingScope.FrontEnd,
                        SystemScope = LoggingSystemScope.Local,
                        TriggerReferenceId = data.TriggerReferenceID
                    });
                };
                //建議由另一個類別管理紀錄封裝
                options.LogAspNetActionExecutedAction = (loggerFactory, data) =>
                {
                    loggerFactory.Log(new LogState
                    {
                        ActivityId = data.ActivityId,
                        ExtendProperties = data.ResponseBodyString,
                        Exception = null,
                        IPAddress = data.IPAddress,
                        LoggingTriggerType = data.LoggingTriggerType ?? LoggingTriggerType.User,
                        LogLevel = LogLevel.Debug,
                        Message = "回應請求",
                        MessageType = LoggingMessageType.WebApiResponse,
                        Resource = String.Empty,
                        Scope = LoggingScope.FrontEnd,
                        SystemScope = LoggingSystemScope.Local,
                        TriggerReferenceId = data.TriggerReferenceID
                    });
                };
                //建議由另一個類別管理紀錄封裝
                options.LogAspNetActionExeceptionAction = (loggerFactory, data) =>
                {
                    loggerFactory.Log(new LogState
                    {
                        ActivityId = data.ActivityId,
                        ExtendProperties = data.ResponseBodyString,
                        Exception = data.Exception,
                        IPAddress = data.IPAddress,
                        LoggingTriggerType = data.LoggingTriggerType ?? LoggingTriggerType.User,
                        LogLevel = LogLevel.Debug,
                        Message = $"執行發生錯誤-{data.Exception.GetType().Name}",
                        MessageType = LoggingMessageType.WebApiResponse,
                        Resource = String.Empty,
                        Scope = LoggingScope.FrontEnd,
                        SystemScope = LoggingSystemScope.Local,
                        TriggerReferenceId = data.TriggerReferenceID
                    });
                };
            })
            .AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(LogExceptionFilter));
                options.Filters.Add(typeof(LogRequestFilter));
                options.Filters.Add(typeof(LogResponseFilter));
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddNewtonsoftJson(options =>
            {
                //options.UseMemberCasing();
            })

            .AddResultCodeConfiguration<ResultCodeSettingEnum>(new ResultDefinition(memoryCache)); ;
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider svp, ILoggerFactory factory)
        {
            #region Logger
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.ConfigureHttpContext()
                .ConfigureLogging(options =>
            {
                options.ActivityIdHeaderKey = "ActivityId";
                options.LoggingTriggerTypeHeaderKey = "LoggingTriggerType";
                options.TriggerReferenceIdHeaderKey = "TriggerReferenceId";
                //建議由另一個類別管理紀錄封裝
                options.RequestParsedAction = (loggerFactory, data) =>
                {
                    loggerFactory.Log(new LogState()
                    {
                        ActivityId = data.ActivityId,
                        ExtendProperties = data.BodyString,
                        Exception = null,
                        IPAddress = data.IPAddress,
                        LoggingTriggerType = data.LoggingTriggerType ?? LoggingTriggerType.User,
                        LogLevel = LogLevel.Debug,
                        Message = "接收請求",
                        MessageType = LoggingMessageType.WebApiResponse,
                        Resource = data.Path,
                        Scope = LoggingScope.FrontEnd,
                        SystemScope = LoggingSystemScope.Local,
                        TriggerReferenceId = data.TriggerReferenceID
                    });
                };
                //建議由另一個類別管理紀錄封裝
                options.ResponseParsedAction = (loggerFactory, data) =>
                {
                    loggerFactory.Log(new LogState()
                    {
                        ActivityId = data.ActivityId,
                        ExtendProperties = data.BodyString,
                        Exception = null,
                        IPAddress = data.IPAddress,
                        LoggingTriggerType = data.LoggingTriggerType ?? LoggingTriggerType.User,
                        LogLevel = LogLevel.Debug,
                        Message = "回應請求",
                        MessageType = LoggingMessageType.WebApiResponse,
                        Resource = String.Empty,
                        Scope = LoggingScope.FrontEnd,
                        SystemScope = LoggingSystemScope.Local,
                        TriggerReferenceId = data.TriggerReferenceID
                    });
                };
            });
            string apiRouteTemplate = "{controller}/{action=Index}/{id?}";
            app.UseTecApiMechanism<ResultCodeSettingEnum>(apiRouteTemplate, env.IsDevelopment());
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: apiRouteTemplate);
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
