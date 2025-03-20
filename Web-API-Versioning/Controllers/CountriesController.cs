using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.Models.DTOs;

namespace Web_API_Versioning.Controllers // Neutral namespace
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet("get-all"), MapToApiVersion("1.0")]
        public IActionResult GetV1()
        {
            try
            {
                var countriesDomainModel = CountriesData.Get() ?? throw new InvalidOperationException("No countries data available");
                var response = countriesDomainModel.Select(countryDomain => new CountryDtoV1
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get-all"), MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            try
            {
                var countriesDomainModel = CountriesData.Get() ?? throw new InvalidOperationException("No countries data available");
                var response = countriesDomainModel.Select(countryDomain => new CountryDtoV2
                {
                    Id = countryDomain.Id,
                    CountryName = countryDomain.Name,
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}