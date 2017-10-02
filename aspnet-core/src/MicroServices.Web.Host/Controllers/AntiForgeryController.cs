using MicroServices.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace MicroServices.Web.Host.Controllers
{
    public class AntiForgeryController : MicroServicesControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}