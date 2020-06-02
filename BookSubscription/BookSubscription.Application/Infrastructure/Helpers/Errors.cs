using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookSubscription.Application.Infrastructure.Helpers
{
    public static class Errors
    {
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, 
                                                                    ModelStateDictionary modelState)
        {
            foreach(var err in identityResult.Errors)
            {
                modelState.TryAddModelError(err.Code, err.Description);
            }

            return modelState;
        }

        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);

            return modelState;
        }
    }
}
