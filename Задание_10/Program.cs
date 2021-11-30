using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_10
{
    class Program
    {
        //Угол задан с помощью целочисленных значений gradus - градусов, min - угловых минут, sec - угловых секунд. Реализовать класс, в котором указанные значения представлены в виде свойств.
        //Для свойств предусмотреть проверку корректности данных. Класс должен содержать конструктор для установки начальных значений, а также метод ToRadians для перевода угла в радианы.
        //Создать объект на основе разработанного класса. Осуществить использование объекта в программе.
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычисляет высоту дерева по углу падения солнечных лучей к поверхности земли и длине тени от дерева.");
            Console.WriteLine("Введите угол падения солнечных лучей к поверхности земли целыми числами в формате: 00{0} 00\' 00\"", (char)176);
            int N1 = Convert.ToInt32(Console.ReadLine());
            int N2 = Convert.ToInt32(Console.ReadLine());
            int N3 = Convert.ToInt32(Console.ReadLine());
            Angle angle = new Angle(N1, N2, N3);
            angle.WriteAngle();
            Console.WriteLine("Угол в радианах: {0:f3}", angle.ToRadians());

            Console.WriteLine("Введите длину тени от дерева в метрах:");
            double shadowLenght = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Высота дерева равна: {0:f2} м", angle.TreeHeigth(shadowLenght));
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
    class Angle
    {
        int grad;
        public int Grad
        {
            set
            {
                if (value >= 0 && value <= 90)
                {
                    grad = value;
                }
                else
                {
                    Console.WriteLine("Значение градуса угла должно быть в диапазоне от 0 до 90.");
                }
            }
            get
            {
                return grad;
            }
        }
        int min;
        public int Min
        {
            set
            {
                if (value >= 0 && value <= 60)
                {
                    min = value;
                }
                else
                {
                    Console.WriteLine("Значение минут угла должно быть в диапазоне от 0 до 60.");
                }
            }
            get
            {
                return min;
            }
        }
        int sec;
        public int Sec
        {
            set
            {
                if (value >= 0 && value <= 60)
                {
                    sec = value;
                }
                else
                {
                    Console.WriteLine("Значение секунд угла должно быть в диапазоне от 0 до 60.");
                }
            }
            get
            {
                return sec;
            }
        }
        public Angle(int gradus, int minute, int second)
        {
            Grad = gradus;
            Min = minute;
            Sec = second;
        }
        public void WriteAngle()
        {
            Console.WriteLine("Введенный угол: {0}{1} {2}\' {3}\"", grad, (char)176, min, sec);
        }       
        public double ToRadians()
        {
            double ang = grad + min / 60 + sec / 3600;
            double rad = ang * Math.PI / 180;
            return rad;
        }
        public double TreeHeigth(double shadowLength)
        {
            double treeHeight = shadowLength * Math.Tan(ToRadians());
            return treeHeight;
        }
    }
}
