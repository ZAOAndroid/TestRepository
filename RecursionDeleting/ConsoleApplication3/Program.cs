using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionDeleting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите путь для удаления");
                string path = Console.ReadLine();
                DeleteFilesAndDirectories(path);
                Console.WriteLine("Deleted");
            }
            catch (Exception)
            {
                Console.WriteLine("Can't delete it");
                throw;
            }

            Console.ReadLine();
        }

        public static void DeleteFilesAndDirectories(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var d in Directory.GetFileSystemEntries(path))
                {
                    DeleteFilesAndDirectories(d);
                }
                Directory.Delete(path);
            }
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
