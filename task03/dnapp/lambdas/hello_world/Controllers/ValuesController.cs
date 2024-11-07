using Microsoft.AspNetCore.Mvc;

namespace Function.Controllers
{
    [Route("hello")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public LambdaResponse Get()
        {
            return new LambdaResponse
            {
                statusCode = 200,
                message = "Hello from Lambda"
            };
        }

        public class LambdaResponse
        {
            public int statusCode { get; set; }
            public required string message { get; set; }
        }
    }
}