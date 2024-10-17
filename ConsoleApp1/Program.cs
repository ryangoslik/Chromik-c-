using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - utworz parametr, 2 - usun parametr, 3 - odczytaj parametr");
                int i = 0;
                i = Convert.ToInt32(Console.ReadLine());

                string parametr;
                string nazwa_sekcji;
                string wartosc;

                switch (i){
                    case 1:
                        ConfigFile ini1 = new ConfigFile(@".\Config.ini");
                        parametr = Console.ReadLine();
                        nazwa_sekcji = Console.ReadLine();
                        wartosc = Console.ReadLine();
                        if(!string.IsNullOrEmpty(parametr) && !string.IsNullOrEmpty(nazwa_sekcji) && !string.IsNullOrEmpty(wartosc))
                        {
                            ini1.Write(parametr, wartosc, nazwa_sekcji);
                        }
                        else
                        {
                            Console.WriteLine("Blad");
                        }
                        

                     break;
                    case 2:
                        ConfigFile ini2 = new ConfigFile(@".\Config.ini");
                        parametr = Console.ReadLine();
                        nazwa_sekcji = Console.ReadLine();
                        if (!string.IsNullOrEmpty(parametr) && !string.IsNullOrEmpty(nazwa_sekcji))
                        {
                            ini2.DeleteKey(parametr, nazwa_sekcji);
                        }
                        else
                        {
                            Console.WriteLine("Blad");
                            
                        }



                        break;
                    case 3:
                        ConfigFile ini3 = new ConfigFile(@".\Config.ini");
                        parametr = Console.ReadLine();
                        nazwa_sekcji = Console.ReadLine();
                        if (!string.IsNullOrEmpty(parametr) && !string.IsNullOrEmpty(nazwa_sekcji))
                        {
                            Console.WriteLine(parametr + " " + ini3.Read(parametr, nazwa_sekcji));
                            
                            
                        }
                        else
                        {
                            Console.WriteLine("Blad");
                        }


                        break;
                    
                }
            }


        }

    }
    class ConfigFile
    {



        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern long GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);


        public string Read(string Key, string Section = null)      //odczytywanie parametru
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)     //tworzenie parametru
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)    //usuwanie parametru
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)    //usuwanie sekcji
        {
            Write(null, null, Section ?? EXE);
        }


        public ConfigFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }
    }
}
