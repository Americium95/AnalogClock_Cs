using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static private float num = 0;
        static private string[,] Bace_sheet;

        static void Main(string[] args)
        {
            int size = 50;
            Bace_sheet = Build_Sheet(size);
            while (true)
            {
                Bace_sheet = Build_Sheet(size);
                Analog_Clock(size);
                Thread.Sleep(80); 
            }
        }

        static void Analog_Clock(int size)
        {
            if (size > 0)
            {

                //string[,] sheet = new string[size,size];
                string[,] sheet = Bace_sheet;

                DateTime Time = DateTime.Now;
                float SecRot = Time.Second / 60f * (float)Math.PI * 2f;
                float MinRot = Time.Minute / 60f * (float)Math.PI * 2f;
                //Console.WriteLine(MinRot);
                float HourRot = (Time.Hour / 12f) * (float)Math.PI * 2f;// (MinRot / 4);
                for (int i = 0; i < size / 2.2; i++)
                {
                    sheet[(int)Math.Floor(size / 2 + i * -Math.Cos(SecRot)), (int)Math.Floor(size / 2 + i * Math.Sin(SecRot))] = "~!";
                }

                for (int i = 0; i < size / 2.5; i++)
                {
                    sheet[(int)Math.Floor(size / 2 + i * -Math.Cos(MinRot)), (int)Math.Floor(size / 2 + i * Math.Sin(MinRot))] = "&@";
                }

                for (int i = 0; i < size / 4; i++)
                {
                    sheet[(int)Math.Floor(size / 2 + i * -Math.Cos(HourRot)), (int)Math.Floor(size / 2 + i * Math.Sin(HourRot))] = "$₩";
                }

                string ClockMap = "";

                string[] mapLine = new string[size];

                for (int i_0 = 0; i_0 < size; i_0++)
                {
                    for (int i_1 = 0; i_1 < size; i_1++)
                    {
                        ClockMap += sheet[i_0, i_1];
                    }
                    mapLine[i_0] = ClockMap;
                    ClockMap = "";
                }
                Console.Clear();
                for (int i = 0; i < size; i++)
                {
                    /*if (mapLine[i].Substring(1) == "_")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    }*/
                    Console.WriteLine(mapLine[i]);
                }
            
                ClockMap = "";
            }
        }


        static string[,] Build_Sheet(int size)
        {
            num+=1f;
            string[,] B_sheet = new string[size, size];
            for (int i_0 = 0; i_0 < size; i_0++)
            {
                if(i_0%8!=num%8)
                   for (int i_1 = 0; i_1 < size; i_1++)
                   {
                        string str = "__";
                        if (i_1 > size)
                        {
                            int num = new Random().Next(0, 100);
                            for (int i_2 = 0; i_2 < size; i_2++)
                            {
                                str += "_";
                            }
                        }
                        B_sheet[i_0, i_1] = str;
                   }
                else
                    for(int i_1 =0;i_1<size/2;i_1++)
                    {
                        
                        string[] RandomList = {"^/","-+","?!","!!"};
                        B_sheet[i_0, i_1] =new Random().Next(1, 10000000).ToString(); //RandomList[new Random().Next(0,3)];
                    }
            }
            for(int i=0;i<360;i+=(360/(size*4)))
            {
                B_sheet[(int)Math.Floor(Math.Floor(size/2f)+Math.Floor(size/2f-2)*Math.Sin(i/360f*(float)Math.PI*2)),(int) Math.Floor(Math.Floor(size/2f)+Math.Floor(size/2f-2)*Math.Cos(i / 360f * (float)Math.PI * 2))] = "&&";
            }
            return B_sheet;
        }
    }
}
