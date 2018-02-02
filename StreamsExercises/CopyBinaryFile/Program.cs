using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var destination = new FileStream("copyMe-copy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readBytesCount = source.Read(buffer, 0, buffer.Length);
                        if(readBytesCount==0)
                            break;
                        destination.Write(buffer,0,buffer.Length);
                    }
                }
            }
        }
    }
}
