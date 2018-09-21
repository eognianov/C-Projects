using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RequestParser
{
    class Program
    {
        static void Main()
        {
            var endPointsByHttpMethod = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine().ToLower();

            while (input!="end")
            {
                var splitInput = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                var httpMethod = splitInput[1];
                var endPoint = splitInput[0];

                if (!endPointsByHttpMethod.ContainsKey(httpMethod))
                {
                    endPointsByHttpMethod.Add(httpMethod, new HashSet<string>());
                }

                endPointsByHttpMethod[httpMethod].Add(endPoint);


                input = Console.ReadLine().ToLower();
            }

            var requestString = Console.ReadLine().ToLower();

            var requstStringSplit = requestString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var requestHttpMethod = requstStringSplit[0];
            var requestEndPoint = requstStringSplit[1].Trim('/');
            var requestHttpProtocol = requstStringSplit[2].ToUpper();

            if (endPointsByHttpMethod.ContainsKey(requestHttpMethod))
            {
                var endPoint = endPointsByHttpMethod[requestHttpMethod].FirstOrDefault(e => e == requestEndPoint);
                if (endPoint!=null)
                {
                    var successHttpResponseString = $"{requestHttpProtocol} {(int)HttpStatusCode.OK} {HttpStatusCode.OK}" +
                        $"{Environment.NewLine}"+
                        $"Content - Length: {HttpStatusCode.OK.ToString().Length}"+
                        $"{Environment.NewLine}"+
                        $"Content-TypeL text/plain"+
                        $"{Environment.NewLine}"+
                        $"{Environment.NewLine}"+
                        $"{HttpStatusCode.OK}";

                    Console.WriteLine(successHttpResponseString);
                    return;
                }
            }

                var errorHttpResponseString = $"{requestHttpProtocol} {(int)HttpStatusCode.NotFound} {HttpStatusCode.NotFound}" +
                                         $"{Environment.NewLine}" +
                                         $"Content - Length: {HttpStatusCode.NotFound.ToString().Length}" +
                                         $"{Environment.NewLine}" +
                                         $"Content-TypeL text/plain" +
                                         $"{Environment.NewLine}" +
                                         $"{Environment.NewLine}" +
                                         $"{HttpStatusCode.NotFound}";

                Console.WriteLine(errorHttpResponseString);
            
        }
    }
}
