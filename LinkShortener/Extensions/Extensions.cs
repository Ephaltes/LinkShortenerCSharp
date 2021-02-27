using LinkShortener.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Extensions
{
    public static class Extensions
    {
        public static IActionResult ToResponse(this CustomResponse response)
        {
            if (!response.IsSuccess)
                return new ObjectResult(new { response.ErrorMessage }) { StatusCode = response.StatusCode };

            if (response.HasData)
                return new ObjectResult(new { Data = response.GetData() }) { StatusCode = response.StatusCode };

            return new StatusCodeResult(response.StatusCode);
        }
    }
}