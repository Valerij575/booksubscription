using System.Threading.Tasks;
using BookSubscription.Application;
using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookSubscription.Web.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _accountService.CreateAsync(model, ModelState);
        }
    }
}