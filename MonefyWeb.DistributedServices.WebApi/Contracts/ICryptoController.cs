using Microsoft.AspNetCore.Mvc;

namespace MonefyWeb.DistributedServices.WebApi.Contracts
{
    public interface ICryptoController
    {
        IActionResult GetCryptoValues();
    }
}