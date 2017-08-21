using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TestLib.Tools;
using TestLib.Extensions;

namespace TestLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Application.Root);
            //Console.ReadLine();
            //LogManager log = new LogManager(null, "_TestLibTest");

            //log.WriteLine("[Begin Processing]------");
            //for (int i = 0; i < 10; i++)
            //{
            //    log.WriteLine("Processing: " + i);
            //    // Do
            //    Thread.Sleep(500);
            //    log.WriteLine("Done: " + i);
            //}
            //log.WriteLine("[End Processing]------");

            LogManager log = new LogManager();

            //log.Write("test");
            //log.WriteConsole("test");

            //string temp = "1";
            //string temp = "test";
            string temp = "2017-06-01 11:20:33.33344564754578678968968";
            //int temp = 0;
            
            Console.WriteLine(":IsNumeric : " + temp.IsNumeric());
            Console.WriteLine(":IsDatetime : " + temp.IsDateTime());
            
            Console.ReadLine();


        }
       
    }
    //public static class ExtensionTest
    //{
    //    public static void WriteConsole(this LogManager log, string data)
    //    {
    //        log.Write(data);
    //        Console.Write(data);
    //        Console.ReadLine();
    //    }

    //}
}
