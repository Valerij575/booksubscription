using BookSubscription.Application;
using BookSubscription.Application.Infrastructure.Helpers;
using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace BookSubscription.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ObjectResult> CreateAsync(RegistrationViewModel model, ModelStateDictionary modelState)
        {
            var userIdentity = new AppUser
            {
                Email = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName,
                UserName = model.FirstName
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, modelState));
            }

            return new OkObjectResult("Account created");
        }
    }
}
