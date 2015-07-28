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
                DeleteFilesAndDirectories(Console.ReadLine());
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
            // For file
            /*string[] files = Directory.GetFiles(Path);

            foreach (var f in files)
            {
                File.Delete(f);
            }*/

            var dir = Directory.EnumerateFileSystemEntries(path);

            foreach (var d in dir)
            {
                Directory.Delete(path, true);
            }
        }
    }
}
