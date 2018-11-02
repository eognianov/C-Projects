using System;
using SIS.MvcFramework;

namespace Chuska
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
