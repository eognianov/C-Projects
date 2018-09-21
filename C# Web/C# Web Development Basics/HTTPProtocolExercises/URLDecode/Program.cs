using System;
using System.Net;

namespace URLDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            var urlDecoded = WebUtility.UrlDecode(inputString);
            Console.WriteLine(urlDecoded);
        }
    }
}
