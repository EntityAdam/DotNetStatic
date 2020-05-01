using DotNetStatic.Resources;
using DotNetStaticReference;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace DotNetStatic
{
    public static class App
    {
        public static void Start(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = AppStrings.AppName,
                Description = AppStrings.AppDesc,
                ExtendedHelpText = AppStrings.AppHelp,
            };

            app.HelpOption("-?|-h|--help");

            app.VersionOption("-v|--version", () =>
            {
                return string.Format("Version {0}", Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
            });

            app.Command("start", (command) =>
            {
                int port = 8080;
                string directory = Directory.GetCurrentDirectory();

                command.Description = AppStrings.CommandStartDesc;
                command.ExtendedHelpText = AppStrings.CommandStartHelp;
                command.HelpOption("-?|-h|--help");
                var portoption = command.Option("-p|--port <port>", "Set port number [default: 8080]", CommandOptionType.SingleValue);
                var directoryoption = command.Option("-d|--directory <path>", "Set content path", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    if (portoption.HasValue())
                    {
                        if (int.TryParse(portoption.Value(), out int p))
                        {
                            port = p;
                        }
                    }

                    if (directoryoption.HasValue())
                    {
                        if (!Directory.Exists(directoryoption.Value()))
                        {
                            throw new DirectoryNotFoundException($"Specified directory not found: {directoryoption.Value()}");
                        }
                        directory = directoryoption.Value();
                    }

                    StartAspNetCore(port, directory);

                    return 0;
                });
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });

            app.Execute(args);
        }

        private static void StartAspNetCore(int port, string directory)
        {
            new HostBuilder()
                .ConfigureWebHost(config =>
                {
                    config.UseContentRoot(directory);
                    config.UseWebRoot(directory);
                    config.UseKestrel(options =>
                    {
                        options.ListenAnyIP(port);
                    });
                    config.UseStartup<Startup>();
                })
                .ConfigureLogging(config =>
                {
                    config.AddConsole();
                })
                .Build().Run();
        }
    }
}