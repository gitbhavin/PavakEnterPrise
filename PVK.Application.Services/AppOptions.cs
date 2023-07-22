
namespace PVK.Application.Services
{
    public class AppOptions
    {
        public bool UseSpa { get; set; } = true;
        public bool UseProxyToSpa { get; set; }
        public string AuthService { get; set; }
    }
}
