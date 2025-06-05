using CC_API.Domain.ModelViews.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CC_API.Controllers.HomeController;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    /// <summary>
    /// Returns basic information about the API or its status.
    /// </summary>
    /// <remarks>
    /// This endpoint can be used to verify that the API is running and accessible.
    /// </remarks>
    /// <returns>
    /// Returns a <see cref="Home"/> object with basic API information.
    /// </returns>
    [HttpGet]
    [AllowAnonymous]
    [Tags("Home")]
    public IActionResult Index() => Ok(new Home());
}