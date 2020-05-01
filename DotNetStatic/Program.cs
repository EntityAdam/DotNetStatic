using DotNetStatic;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace DotNetStaticReference
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                App.Start(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
                throw;
            }
        }
    }
}