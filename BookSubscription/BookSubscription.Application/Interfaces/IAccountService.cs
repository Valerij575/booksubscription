using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace BookSubscription.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ObjectResult> CreateAsync(RegistrationViewModel model, ModelStateDictionary modelState);
    }
}
