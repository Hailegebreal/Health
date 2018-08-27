using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.LeprosyModel;
using AspNetCoreProject.LeprosyModelInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using AspNetCoreProject.LeprosyMappers;
using GraphQL.Types;
using AspNetCoreProject.GQLeprosyModel;
using AspNetCoreProject.Repositories;
using GraphQL;
using GraphQL.Http;
using AspNetCoreProject.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IPatientService, PatientService>();

            services.AddTransient<IPatientService, PatientService>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<BookQuery>();
            services.AddSingleton<LeprosyMutation>();
            services.AddAutoMapper(xmz => xmz.AddProfile(new ContactMappingEntity()));
           // services.AddSingleton<ISchema , LeprosySchema>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new LeprosySchema(new FuncDependencyResolver(type => sp.GetService(type))));
            //services.AddDbContext<SchoolDBContext>(optx => optx.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


         

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsEnvironment("Production"))
            {
                app.UseExceptionHandler(subApp =>
                {

                    subApp.Run(async context =>
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync("CRAP!");
                    });

                });
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware 1");
            //    await next();
            //    await context.Response.WriteAsync("Middleware 3");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware 2");
               
            //});

            //app.UseStatusCodePages(subApp =>
            //{

            //    subApp.Run(async context =>
            //    {
            //        context.Response.ContentType = "text/html";
            //        await context.Response.WriteAsync("<strong> Hamlet </strong>");

            //    });

            //});
            //app.Use(async (context, next) =>
            //{
            //    await next();

            //    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api", StringComparison.CurrentCulture))

            //    {
            //        context.Request.Path = "/Index.html";
            //        context.Response.StatusCode = 200;

            //        await next();
            //    }

            //});

            //app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

           // app.UseFileServer();

           // app.UseGraphiQl();

           // app.MyLeprosyGraphQLMiddleWare();


            //app.UseAuthentication();


            //app.UseStaticFiles(new StaticFileOptions
            //{
             //   FileProvider = new PhysicalFileProvider(
             //       Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
             //   RequestPath = "/StaticFiles"
             //});

           // app.UseDeveloperExceptionPage();

            //app.UseWelcomePage();

          
          //  app.UseStatusCodePages();



            //app.Map("/map1", Map1);

            //app.Map("/map2", Map2);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello Non_Map");
            //});



          



            //app.Run((context) =>
            //{
            //    context.Response.StatusCode = 404;
            //    return Task.FromResult(0);
            //    //throw new InvalidOperationException("Exception Middleware")
            //});
              
            //app.MyMiddleWare();

            app.UseMvc();

            //app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{}"
            //    );
            
            //});
        }

        private static void Map1(IApplicationBuilder app){

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map 1");
            });
        }

        private static void Map2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map 2");
            });

        }







    }

    class MyMiddleWare {

        private const string myKey = "hagaf";
        private RequestDelegate next;

        public MyMiddleWare(RequestDelegate next){

            this.next = next;
        }

        public async Task Invoke(HttpContext context){

            bool validkey = false;

            var checkkey = context.Request.Headers.ContainsKey("hagafKey");

            if(checkkey){
                if(context.Request.Headers["hagafKey"].Equals(myKey)){

                    validkey = true;
                }

            }
            if(!validkey){

                context.Response.StatusCode = (int)StatusCodes.Status200OK;
                await context.Response.WriteAsync("Poor hagaf");
            }
            else {

                await next.Invoke(context);
            }

           
        }

    }



    public static class MyHandlerExtensions{

        public static IApplicationBuilder MyMiddleWare(this IApplicationBuilder builder){

            return builder.UseMiddleware<MyMiddleWare>();
        }

    }



    public static class MyLeprosyGraphQLMiddleWareExtensions
    {

        public static IApplicationBuilder MyLeprosyGraphQLMiddleWare(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MyLeprosyGraphQLMiddleWare>();
        }

    }




    class MyLeprosyGraphQLMiddleWare
    {

        private const string myKey = "MyLeprosyGraphQL";

        private RequestDelegate next;
        private readonly IBookRepository _bookRepository;

        public MyLeprosyGraphQLMiddleWare(RequestDelegate next,IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            bool sent = false;

            if( context.Request.Path.StartsWithSegments("/graph")){

                using(var sr = new StreamReader(context.Request.Body)){

                    var query = await sr.ReadToEndAsync();



                    if(!string.IsNullOrWhiteSpace(query)){

                        var schema = new Schema {
                            Query = new BookQuery(_bookRepository)
                        
                        };

                        var result = await new DocumentExecuter()
                            .ExecuteAsync(Options =>
                        {
                            Options.Schema = schema;
                            Options.Query = query;
                        }).ConfigureAwait(false);

                        await WriteResult(context, result);
                        sent = true;
                    }

                }

               
            }


            if(!sent){
                await next.Invoke(context);   
            }

        }


        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }




    }





}
