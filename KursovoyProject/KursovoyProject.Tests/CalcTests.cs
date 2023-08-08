using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static KursovoyProject.Src.Windows.CalcW;

namespace KursovoyProject.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void simpleEquations()
        {
            //Подготовка данных
            List<int> numbersx = new List<int> {5, 77, 9, 33, 8};
            List<int> numbersy = new List<int> {10, -2, 0, 7, 2};
            List<string> operations = new List<string> { "+", "*", "/", "^", "√" };
            List<string> expected = new List<string> {"15", "-154", "∞", "42618442977", "1,09050773266526" };
            string exp = "";
            foreach (var i in numbersx)
            {
                exp = $"{numbersx[i]}{operations[i]}{numbersy[i]}";
                string res = StringToFormula.Eval(exp, null).ToString();
                Console.WriteLine("res");

            }
            

            //Действие
            /*foreach (var i in numbersx)
            {
                exp = $"{numbersx[i]}{operations[i]}{numbersy[i]}";
                string res = StringToFormula.Eval(exp, null).ToString();

                Assert.AreEqual(expected, res);
            }*/


            //Проверка

        }
    }
}
