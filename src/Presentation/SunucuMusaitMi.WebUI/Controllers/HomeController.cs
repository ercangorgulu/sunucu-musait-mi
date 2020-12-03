using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SunucuMusaitMi.Core.ViewModels;
using SunucuMusaitMi.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunucuMusaitMi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ServerConfiguration> _options;

        public HomeController(IOptions<ServerConfiguration> options)
        {
            _options = options;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _options.Value.ApiUrl
                .AppendPathSegment("ServerAvailability")
                .PostJsonAsync(new
                {
                    Token = _options.Value.AuthToken
                })
                .ReceiveJson<List<ServerViewModel>>();
            return View(result);
        }
    }
}
