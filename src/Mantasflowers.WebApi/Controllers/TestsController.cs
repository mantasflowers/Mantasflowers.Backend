using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantasflowers.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/tests")]
    // TODO: this is temporary controller used for testing endpoints in the cloud. Delete later.
    public class TestsController : ControllerBase
    {
        private readonly ILogger _logger = Log.ForContext<TestsController>();

        private readonly DatabaseContext _dbContext;

        private readonly IConfiguration _config;

        public TestsController(DatabaseContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        /// <summary>
        /// This endpoint is documented.
        /// </summary>
        /// <param name="number">number to echo back</param>
        [HttpGet("swaggerdocumented")]
        [ProducesResponseType(typeof(int), Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        public IActionResult SwaggerDocumented([FromQuery] int? number)
        {
            return Ok(
                new {
                    number = number ?? 666
                }
            );
        }

        [HttpGet("variables")]
        public IActionResult Variables()
        {
            string isInMemory = _config["Database:IsInMemory"] ?? "NOT FOUND";

            return Ok(
                new {
                    IsInMemory = isInMemory
                }
            );
        }

        [HttpGet("githash")]
        public IActionResult Githash()
        {
            string githash = _config["Githash"] ?? "NOT FOUND";
            
            return Ok(
                new {
                    GitHash = githash
                }
            );
        }

        [HttpGet("database")]
        public IActionResult Database()
        {
            var product = _dbContext.Products
                .Include(x => x.ProductInfo)
                .FirstOrDefault();

            if (product == null)
            {
                return Ok("NOT FOUND");
            }

            return Ok(
                new {
                    ProductId = product.Id,
                    Name = product.Name,
                    Description = product?.ProductInfo.Description,
                    Price = product.Price
                }
            );
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult Auth()
        {
            var result = new
            {
                Authenticated = User.Identity.IsAuthenticated
            };

            return Ok(result);
        }
    }
}
