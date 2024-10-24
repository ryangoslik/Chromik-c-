using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj dzielną");
            string dana1 = Console.ReadLine();
            bool status = false;
            for (int i = 0; i < dana1.Length; i++)
            {
                char c = dana1[i];
                int intc = (int)c;
                if (intc < 48 || intc > 57)
                {
                    status = true;
                }
            }

            if (status == true)
            {
                Console.WriteLine("Podales złe dane");
            }

            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj dzielnik");
            int b = Convert.ToInt32(Console.ReadLine());

            if (b == 0)
            {
                Console.WriteLine("Nie mozna dzielic przez zero");
                Console.ReadKey();
            }
            else if (b > 0)
            {
                wyslij_email(a, b);
            }
        }

        static void wyslij_email(int a, int b)
        {
            try
            {
                //Try{miejsce na kod wykonywany}
                Console.WriteLine(@"Wynik dzielenia a\b=" + (a / b).ToString());
                Console.ReadKey();
            }
            catch(Exception e) {
            Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
            
        }

        static void TestTrycatch()
        {
            try
            {
                int a = 12;
                int b = 0;
                int c = b / a;

                DataTable tablica = new DataTable();
                tablica.Rows.Add("Item");

                string text = "ABCD";
                string letter = "";
                for (int i = 0; i <= text.Length; i++)
                {
                    letter = text.Substring(i);
                }

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Dzielenie pzez zero jest zabronione");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index poza zakresem");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index poza zakresem");
            }
            catch (Exception e)
            {

            }
            finally {
                //
            }
        }
    }
}
