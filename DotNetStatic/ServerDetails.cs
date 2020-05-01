namespace DotNetStaticReference
{
    internal class ServerDetails
    {
        public ServerDetails()
        {
        }

        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
        public string WebRootPath { get; set; }
    }
}