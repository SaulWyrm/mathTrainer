using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace KursovoyProject.Src.Windows
{
	public partial class CalcW : Window
	{
		public CalcW()
		{
			InitializeComponent();

			B0.Click += AddValue;
			B1.Click += AddValue;
			B2.Click += AddValue;
			B3.Click += AddValue;
			B4.Click += AddValue;
			B5.Click += AddValue;
			B6.Click += AddValue;
			B7.Click += AddValue;
			B8.Click += AddValue;
			B9.Click += AddValue;
			Bdiv.Click += AddValue;
			Bmul.Click += AddValue;
			Bsub.Click += AddValue;
			Badd.Click += AddValue;
			Beq.Click += AddValue;
			Bxchg.Click += AddValue;
			Bsqrt.Click += AddValue;
			BCE.Click += AddValue;
			Bxn.Click += AddValue;
			Bcomma.Click += AddValue;
			Bleft.Click += AddValue;
			Bright.Click += AddValue;
		}
		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		// метод проверяет строковое значение кнопки и добавляет в строку выражения
		// если это кнопка "=" или "±", то она делает особое действие
		public void AddValue(object sender, EventArgs e)
		{
			string buttonText = ((Button)sender).Content.ToString();
			switch (buttonText)
			{
				case "0":
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
				case "7":
				case "8":
				case "9":
				case "/":
				case "*":
				case "-":
				case "+":
				case ",":
				case "(":
				case ")":
					Todo.Text += buttonText;
					break;
				case "n√":
					Todo.Text += "√";
					break;
				case "x^n":
					Todo.Text += "^";
					break;
				case "CE":
					Todo.Text = "";
					break;
				case "=":
				case "±":
					string formula = Todo.Text;
					double result;
					if (buttonText == "=")
					{

						Todo.Text = StringToFormula.Eval(formula, Todo).ToString();
						
						
					}
					else if (buttonText == "±")
					{
						result = StringToFormula.Eval(formula, Todo) * -1;
						Todo.Text = result.ToString();
					}
					break;
				default:
					Todo.Text = "Ошибка";
					break;
			}
		}

		// перевод выражения с бинарным опиратором в численное значение
		public static class StringToFormula
		{
            public static string result;
            private static string[] _operators = { "-", "+", "/", "*", "^", "√", "±" };
			private static Func<double, double, double>[] _operations = {
		(a1, a2) => a1 - a2,
		(a1, a2) => a1 + a2,
		(a1, a2) => a1 / a2,
		(a1, a2) => a1 * a2,
		(a1, a2) => Math.Pow(a1, a2),
		(a1, a2) => Math.Pow(a2, 1.0 / a1),
		(a1, a2) => a1 * -1
	};
			// Подсчет конечного введенного выражения с учетом последовательности скобок
			public static double Eval(string expression, TextBox Todo = null)
			{
				List<string> tokens = getTokens(expression);
				Stack<double> operandStack = new Stack<double>();
				Stack<string> operatorStack = new Stack<string>();
				int tokenIndex = 0;
				try
				{


					// проверяем каждый символ выражения на его тип
					while (tokenIndex < tokens.Count)
					{
						string token = tokens[tokenIndex];
						if (token == "(")
						{
							string subExpr = getSubExpression(tokens, ref tokenIndex, Todo);
							operandStack.Push(Eval(subExpr, Todo));
							continue;
						}

						// Если это оператор  
						if (Array.IndexOf(_operators, token) >= 0)
						{
							while (operatorStack.Count > 0 && Array.IndexOf(_operators, token) < Array.IndexOf(_operators, operatorStack.Peek()))
							{
								string op = operatorStack.Pop();
								double arg2 = operandStack.Pop();
								double arg1 = operandStack.Pop();
								operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
							}
							operatorStack.Push(token);
						}
						else
						{
							operandStack.Push(double.Parse(token));
						}
						tokenIndex += 1;
					}


					while (operatorStack.Count > 0)
					{

						string op = operatorStack.Pop();
						double arg2 = operandStack.Pop();
						double arg1 = operandStack.Pop();
						operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));


					}
					return operandStack.Pop();
				}
				catch
                {
					return -1;
                }
                
			}

			// возвращает подстроку в скобках
			private static string getSubExpression(List<string> tokens, ref int index, TextBox Todo)
			{
				StringBuilder subExpr = new StringBuilder();
				int parenlevels = 1;
				index += 1;
				while (index < tokens.Count && parenlevels > 0)
				{
					string token = tokens[index];
					if (tokens[index] == "(")
					{
						parenlevels += 1;
					}

					if (tokens[index] == ")")
					{
						parenlevels -= 1;
					}

					if (parenlevels > 0)
					{
						subExpr.Append(token);
					}

					index += 1;
				}

				if ((parenlevels > 0))
				{
					result = "Конфликт скобок в выражении";
					Todo.Text = "Конфликт скобок в выражении";
				}
				return subExpr.ToString();
			}

			// возвращает строку последовательности операторов
			private static List<string> getTokens(string expression)
			{
				string operators = "()^*/+-√±";
				List<string> tokens = new List<string>();
				StringBuilder sb = new StringBuilder();

				foreach (char c in expression.Replace(" ", string.Empty))
				{
					if (operators.IndexOf(c) >= 0)
					{
						if ((sb.Length > 0))
						{
							tokens.Add(sb.ToString());
							sb.Length = 0;
						}
						tokens.Add(c.ToString());
					}
					else
					{
						sb.Append(c);
					}
				}

				if ((sb.Length > 0))
				{
					tokens.Add(sb.ToString());
				}
				return tokens;
			}
		}
	}
}
