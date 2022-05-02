using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //File.Copy(@"\\" + tbx_ip.Text + "\\resources\\centroMedico.mdf", "C:\\centroMedico.mdf", true);
            //string startFolder = @"c:\prueba\";
            //string destinationFolder = @"c:\prueba\test";
            string startFolder = @"\\192.168.0.6\\c\\prueba\\";
            string destinationFolder = @"\\192.168.0.6\\c\\prueba\\test";


            Console.WriteLine("========================= Copy Logs - ITB =========================");
            Console.WriteLine("\n");

            Console.WriteLine("Fecha Inicial: ");
            string startDate =  Console.ReadLine();

            Console.WriteLine("Fecha Final: ");
            string endDate = Console.ReadLine();

            Directory.CreateDirectory(destinationFolder);
            DirectoryInfo dir = new DirectoryInfo(startFolder);
            var listOfFiles = dir.GetFiles("*.*", SearchOption.AllDirectories)  
                                    .Where(file => file.LastWriteTime.Date >= Convert.ToDateTime(startDate) && file.LastWriteTime.Date <= Convert.ToDateTime(endDate));
            foreach (var file in listOfFiles)
            {
                File.Copy(file.FullName, Path.Combine(destinationFolder, file.Name), true);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Copia completa!!");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
