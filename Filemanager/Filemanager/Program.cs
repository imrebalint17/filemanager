using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileManager();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            fileManager.SearchDrive();
        }
    }
}
