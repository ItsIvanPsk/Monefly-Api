using Microsoft.AspNetCore.Mvc;

namespace MonefyWeb.DistributedServices.WebApi.Contracts
{
    public interface ICategoryController
    {
        IActionResult GetCategoriesByUserId([FromRoute] string version, long AccountId);
        IActionResult GetCategories([FromRoute] string version);
    }
}