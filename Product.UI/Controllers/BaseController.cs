using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace Product.UI.Controllers
{
    public class BaseController : Controller
    {
        public string? CurrentUserID 
        {
            get
            {
                return HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .Select(i => i.Value).SingleOrDefault();
            }
        }
    }
}
