using System;
using Practical_Exam_DMAWS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Practical_Exam_DMAWS;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<OrderSystemContext>();
        services.AddControllers();
    }
}