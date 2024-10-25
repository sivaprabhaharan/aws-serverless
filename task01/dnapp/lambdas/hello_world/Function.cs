using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleLambdaFunction;

public class Function
{
    public LambdaResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        return new LambdaResponse
        {
            statusCode = 200,
            message = "Hello from Lambda"
        };
    }
}
