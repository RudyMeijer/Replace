using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Replace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Replace(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Replace(string[] args)
        {
            if (args.Length < 3) { Console.WriteLine("Syntax: Replace src dst infile [outfile]"); return; }

            var src = args[0];
            var dst = args[1];
            var infile = args[2];
            var outfile = args.Length < 4 ? infile : args[3];
            Console.WriteLine(Replace(src, dst, infile, outfile));
        }

        internal static string Replace(string src, string dst, string infile, string outfile)
        {
            if (src == String.Empty) return "Please enter tekst to replace.";

            if (!File.Exists(infile)) return $"input file {infile} does't exist.";
            if (outfile == string.Empty) outfile = infile;
            // Open infile.
            using (StreamReader sr = new StreamReader(infile))
            {
                string input = sr.ReadToEnd();
                if (!input.Contains(src)) return $"File {infile} doesn't contain {src}.";
                var output = input.Replace(src, dst);
                sr.Close();
                using (StreamWriter sw = new StreamWriter(outfile)) { sw.WriteLine(output); }
            }

            return $"{src} succesfully replaced by {dst} in {outfile}.";
        }
    }
}
