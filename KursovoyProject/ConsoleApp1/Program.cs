using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Подготовка данных
            List<int> numbersx = new List<int> { 5, 77, 9, 33, 8 };
            List<int> numbersy = new List<int> { 10, -2, 0, 7, 2 };
            List<string> operations = new List<string> { "+", "*", "/", "^", "√" };
            List<string> expected = new List<string> { "15", "-154", "∞", "42618442977", "1,09050773266526" };
            string exp = "";
            foreach (var i in numbersx)
            {
                exp = $"{numbersx[i]}{operations[i]}{numbersy[i]}";
                string res = KursovoyProject.Src.Windows.CalcW.StringToFormula.Eval(exp, null).ToString();
                Console.WriteLine("res");

            }
        }
    }
}
