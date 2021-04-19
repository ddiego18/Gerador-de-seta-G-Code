using System;
using System.Globalization;

namespace GeradorSetaGCode
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 =0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, y5 = 0;
            double altTriangulo, comprimento, lado;
            Console.WriteLine("Entre com as coordenadas do primeiro ponto da seta (mesma linha e separado por espaço):");
            string[] vet1 = Console.ReadLine().Split(' ');
            x1 = double.Parse(vet1[0]);
            y1 = double.Parse(vet1[1]);

            Console.WriteLine("Entre com as coordenadas da ponta ou extremidade da seta (mesma linha e separado por espaço):");
            string[] vet2 = Console.ReadLine().Split(' ');
            x2 = double.Parse(vet2[0]);
            y2 = double.Parse(vet2[1]);


            if (x1 == x2)
            {
                comprimento = Math.Abs(y2 - y1);
            }else if (y1 == y2)
            {
                comprimento = Math.Abs(x2 - x1);
            }
            else
            {
                comprimento = Math.Sqrt((Math.Pow((Math.Abs(x2 - x1)), 2.0) + Math.Pow((Math.Abs(y2 - y1)), 2.0)));
            }

            altTriangulo = comprimento * 0.15;
            lado = (2 * altTriangulo) / Math.Sqrt(3);

           
            if (x1 == x2)
            {
                x3 = x1;
                y3 = y2 - altTriangulo;
                x4 = x3 - (Math.Tan(30 * Math.PI/180)) * altTriangulo;
                x5 = x3 + (Math.Tan(30 * Math.PI / 180)) * altTriangulo;
                y4 = y3;
                y5 = y3;
            }else if (y1 == y2)
            {
                y3 = y1;
                x3 = x2 - altTriangulo;
                y4 = y3 - (Math.Tan(30 * Math.PI / 180)) * altTriangulo;
                y5 = y3 + (Math.Tan(30 * Math.PI / 180)) * altTriangulo;
                x4 = x3;
                x5 = x3;
            }else if (x2 > x1 && y2 > y1)
            {
                x3 = x2 - (((Math.Abs(x2 - x1)) * altTriangulo) / comprimento);
                y3 = y2 - Math.Sqrt(Math.Pow(altTriangulo, 2) - Math.Pow((Math.Abs(x2 - x3)), 2));
                x4 = x3 - ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                x5 = x3 + ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                y4 = y3 + ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
                y5 = y3 - ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
            }else if (x2 < x1 && y2 > y1)
            {
                x3 = x2 + (((Math.Abs(x2 - x1)) * altTriangulo) / comprimento);
                y3 = y2 - Math.Sqrt(Math.Pow(altTriangulo, 2) - Math.Pow((Math.Abs(x2 - x3)), 2));
                x4 = x3 + ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                x5 = x3 - ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                y4 = y3 + ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
                y5 = y3 - ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
            }else if(x2 < x1 && y2 < y1)
            {
                x3 = x2 + (((Math.Abs(x2 - x1)) * altTriangulo) / comprimento);
                y3 = y2 + Math.Sqrt(Math.Pow(altTriangulo, 2) - Math.Pow((Math.Abs(x2 - x3)), 2));
                x4 = x3 + ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                x5 = x3 - ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                y4 = y3 - ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
                y5 = y3 + ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
            }
            else
            {
                x3 = x2 - (((Math.Abs(x2 - x1)) * altTriangulo) / comprimento);
                y3 = y2 + Math.Sqrt(Math.Pow(altTriangulo, 2) - Math.Pow((Math.Abs(x2 - x3)), 2));
                x4 = x3 - ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                x5 = x3 + ((Math.Cos(50 * Math.PI / 180) * lado) / 2);
                y4 = y3 - ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
                y5 = y3 + ((Math.Sin(50 * Math.PI / 180) * lado) / 2);
            }

            Console.WriteLine("G0 " + "X" + x1.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y1.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("G1 " + "X" + x3.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y3.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("G1 " + "X" + x4.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y4.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("G1 " + "X" + x2.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y2.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("G1 " + "X" + x5.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y5.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("G1 " + "X" + x3.ToString("F2", CultureInfo.InvariantCulture) + " Y" + y3.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
