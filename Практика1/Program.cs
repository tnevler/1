using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика1
{
    class Program
    {
        static int Noc(int a, int b)
        {
            int temp;
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            temp = b;
            int c = temp % a;
            while (temp % a != 0)
            {
                c = temp % a;
                temp += b;
            }
            return temp;
        }

        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("INPUT.TXT");
            string s = f.ReadToEnd();
            f.Close();
            int[] arr = s.Split(' ').Select(m => int.Parse(m)).ToArray();
            int n = arr[0];
            int x = arr[1];
            int y = arr[2];
            int temp1;
            if (x > y)
            {
                temp1 = x;
                x = y;
                y = temp1;
            }
            int time = x;
            int noc = Noc(x, y);
            temp1 = noc / x + noc / y;
            time += ((n - 1) / temp1) * noc;

            n = (n - 1) % temp1;
            temp1 = 0;
            int temp2 = 0;
            while (n > 0)
            {
                temp1++;
                temp2++;
                time++;
                if (temp1 == x)
                {
                    n--;
                    temp1 = 0;
                }
                if (temp2 == y)
                {
                    n--;
                    temp2 = 0;
                }
            }
            StreamWriter d = new StreamWriter("OUTPUT.TXT");
            {
                d.WriteLine(time);
                d.Close();
            }
        }
    }
}
