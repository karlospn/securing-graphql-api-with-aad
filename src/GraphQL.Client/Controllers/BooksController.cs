using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.WebApi.DTO;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Client.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IGraphQLClient _client;

        public BooksController(
            ILogger<BooksController> logger, 
            IGraphQLClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                var result = await _client.SendQueryAsync<GetBooksData>(Queries.GetBooks.Value);

                if (result.Errors != null && result.Errors.Any())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok(result.Data.Books);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }

        }

        [HttpGet("{author}")]
        public async Task<ActionResult> GetBooksByAuthor(
            [FromRoute]string author)
        {
            try
            {
                var query = new GraphQLRequest
                {
                    Query = Queries.GetBooksByAuthor.Value,
                    Variables = new
                    {
                        author = author
                    }
                };

                var result = await _client.SendQueryAsync<GetBooksByAuthorData>(query);

                if (result.Errors != null && result.Errors.Any())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok(result.Data.Books);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }

        }
    }
}
