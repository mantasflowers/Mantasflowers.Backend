using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantasflowers.Persistence;
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

        [HttpGet("alive")]
        public IActionResult Alive()
        {
            return Ok(
                new {
                    Meme = "Funny"
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
                    Description = product.Description,
                    Price = product?.ProductInfo.Price
                }
            );
        }
    }
}
