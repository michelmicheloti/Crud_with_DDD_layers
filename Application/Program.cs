using Application;
using Microsoft.AspNetCore.Builder;

WebApplicationBuilder _ = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();
