using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ZippingSlicedFiles
{

    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "../sliceMe.mp4";
            string destination = "";
            int parts = 5;

            Zip(sourceFile,destination,parts);
           

            var zippedFiles = new List<string>
            {
                "Part-0.mp4.gz",
                "Part-1.mp4.gz",
                "Part-2.mp4.gz",
                "Part-3.mp4.gz",
                "Part-4.mp4.gz"
            };


            UnZip(zippedFiles,destination);
        }

       

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);



                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    destinationDirectory = destinationDirectory == string.Empty ? "./" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";


                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        

        

        private static void UnZip(List<string> files, string destinationDirectory)
        {
            var lastIndexOfDot = files[0].LastIndexOf('.');
            var extension = Path.GetExtension(files[0].Substring(0, lastIndexOfDot));
            var outputFile = Path.Combine(destinationDirectory, $"Assembled {DateTime.Now:dd-MM-yyyy - hh-mm}{extension}");

            try
            {
                using (var writer = new FileStream(outputFile, FileMode.CreateNew))
                {
                    foreach (var file in files)
                    {
                        if (Path.GetExtension(file) != ".gz")
                        {
                            Console.WriteLine("The following file is nog GZip and the operation cannot be completed.");
                            return;
                        }

                        try
                        {
                            using (var reader = new FileStream(file, FileMode.Open))
                            {
                                using (var decompressionStram = new GZipStream(reader, CompressionMode.Decompress, false))
                                {
                                    var buffer = new byte[4096];
                                    var readBytesCount = decompressionStram.Read(buffer, 0, buffer.Length);

                                    while (readBytesCount != 0)
                                    {
                                        writer.Write(buffer, 0, readBytesCount);
                                        readBytesCount = decompressionStram.Read(buffer, 0, buffer.Length);
                                    }
                                }
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine($"File {file} cannot be found.{Environment.NewLine}The Assemble will be completed without this file.");
                        }
                    }
                }
            }
            catch (IOException)
            {
                destinationDirectory = Path.Combine(destinationDirectory, "Assemble");
                Assemble(files, destinationDirectory);
            }
        }
    }
}

