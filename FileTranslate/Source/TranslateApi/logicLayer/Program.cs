using IronPython.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslateApi;

namespace logicLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pathPy = "print.py";
            ScriptRuntime py = Python.CreateRuntime();
            dynamic pyProgram = py.UseFile(pathPy);
            pyProgram.holaConNombre("Translate");

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://*:5024");
                });
    }
}
