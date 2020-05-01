namespace DotNetStatic.Resources
{
    public static class AppStrings
    {
        public const string AppName = "DotNetStatic";
        public const string AppDesc = "Starts a local web server to serve static files";

        public const string AppHelp = @"
This application will start a web server and serve files from the executing directory.

By default it will serve:
  index.htm
  index.html
  default.htm
  default.html

Install this application as a global tool using the following command:

  dotnet tool install --global --add-source ./nupkg dotnetstaticreference";

        public const string CommandStartDesc = "Starts the web server";

        public const string CommandStartHelp = @"
Creates a web server which will listen on any IP on the specified port, default is port 8080.
It will serve files from the directory it was executed, unless otherwise specified.";
    }
}