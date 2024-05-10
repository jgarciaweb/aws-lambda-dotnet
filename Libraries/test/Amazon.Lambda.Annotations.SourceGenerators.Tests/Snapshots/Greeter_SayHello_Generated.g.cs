// <auto-generated/>

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Amazon.Lambda.Core;

namespace TestServerlessApp
{
    public class Greeter_SayHello_Generated
    {
        private readonly Greeter greeter;
        private readonly Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer serializer;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Greeter_SayHello_Generated()
        {
            SetExecutionEnvironment();
            greeter = new Greeter();
            serializer = new Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer();
        }

        /// <summary>
        /// The generated Lambda function handler for <see cref="SayHello(System.Collections.Generic.IEnumerable<string>, Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest, Amazon.Lambda.Core.ILambdaContext)"/>
        /// </summary>
        /// <param name="__request__">The API Gateway request object that will be processed by the Lambda function handler.</param>
        /// <param name="__context__">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns>Result of the Lambda function execution</returns>
        public Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse SayHello(Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest __request__, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            var validationErrors = new List<string>();

            var firstNames = default(System.Collections.Generic.IEnumerable<string>);
            if (__request__.MultiValueQueryStringParameters?.ContainsKey("names") == true)
            {
                firstNames = __request__.MultiValueQueryStringParameters["names"]
                    .Select(q =>
                    {
                        try
                        {
                            return (string)Convert.ChangeType(q, typeof(string));
                        }
                        catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException || e is ArgumentException)
                        {
                            validationErrors.Add($"Value {q} at 'names' failed to satisfy constraint: {e.Message}");
                            return default;
                        }
                    })
                    .ToList();
            }

            // return 400 Bad Request if there exists a validation error
            if (validationErrors.Any())
            {
                var errorResult = new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
                {
                    Body = @$"{{""message"": ""{validationErrors.Count} validation error(s) detected: {string.Join(",", validationErrors)}""}}",
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json"},
                        {"x-amzn-ErrorType", "ValidationException"}
                    },
                    StatusCode = 400
                };
                return errorResult;
            }

            greeter.SayHello(firstNames, __request__, __context__);

            return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
            {
                StatusCode = 200
            };
        }

        private static void SetExecutionEnvironment()
        {
            const string envName = "AWS_EXECUTION_ENV";

            var envValue = new StringBuilder();

            // If there is an existing execution environment variable add the annotations package as a suffix.
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(envName)))
            {
                envValue.Append($"{Environment.GetEnvironmentVariable(envName)}_");
            }

            envValue.Append("lib/amazon-lambda-annotations#1.3.1.0");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}