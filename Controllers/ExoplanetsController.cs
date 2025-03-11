using Microsoft.AspNetCore.Mvc;
using ExoplanetQueryApp.Models;
using ExoplanetQueryApp.Services;

namespace ExoplanetQuery.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExoplanetsController : ControllerBase
{
    private readonly ExoplanetService _service;

    public ExoplanetsController(ExoplanetService service)
    {
        _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Exoplanet>> GetExoplanets(
        [FromQuery] string planetName = null,
        [FromQuery] string hostName = null,
        [FromQuery] string discoveryMethod = null,
        [FromQuery] string discoveryFacility = null,
        [FromQuery] int? discoveryYear = null,
        [FromQuery] double? orbitalPeriod = null,
        [FromQuery] double? planetRadius = null,
        [FromQuery] double? planetMass = null,
        [FromQuery] double? distance = null)
    {
        if (string.IsNullOrEmpty(planetName) && string.IsNullOrEmpty(hostName) &&
            string.IsNullOrEmpty(discoveryMethod) && string.IsNullOrEmpty(discoveryFacility) && !discoveryYear.HasValue &&
            !orbitalPeriod.HasValue && !planetRadius.HasValue &&
            !planetMass.HasValue && !distance.HasValue)
        {
            return BadRequest("At least one query parameter must be provided.");
        }
        var results = _service.QueryExoplanets(planetName, hostName, discoveryMethod, discoveryYear, discoveryFacility,
        orbitalPeriod, planetRadius, planetMass, distance);
        return Ok(results);
    }
}