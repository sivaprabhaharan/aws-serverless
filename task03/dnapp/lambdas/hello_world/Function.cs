using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Net;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleLambdaFunction;

public class Function
{
    public Dictionary<string, object> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var response = new Dictionary<string, object>
        {
            { "statusCode", (int)HttpStatusCode.OK },
            { "message", "Hello from Lambda" },
        };
        return response;
    }
}
