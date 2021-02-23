using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1OOP
{
    interface ICalcucator
    {
        double CalcClear();
        string SavedNumber { get; set; }
		string CalcExtract();
		string GetResult(string exp);

	}
    class Calculator : ICalcucator
    {
		public string SavedNumber { get; set; } = "";
		public int AccuracyMode { get; set; }
		Queue<double> numbers; 
          readonly char SmthNull = 'N'; 
          readonly char End = 'E'; 
          readonly char Number = 'n'; 
          readonly char Plus = '+'; 
          readonly char Minus = '-'; 
          readonly char Star = '*'; 
          readonly char Dirslash = '/'; 
          readonly char Left = '('; 
          readonly char Right = ')'; 
          readonly char Cos = 'c'; 
          readonly char Sin = 's'; 
          readonly char Tg = 't';
          readonly char Ctg = 'g';
          readonly char Root2 = '$'; 
          readonly char Root3 = '%'; 
          readonly char Pow2 = '^'; 
          readonly char Pow3 = '!';
		public string SinStr { get; } = "sin";
		public string CosStr { get; } = "cos";
		public string TgStr { get; } = "tg";
		public string CtgStr { get; } = "ctg";
		public string Pow2Str { get; } = "pow2";
		public string Pow3Str { get; } = "pow3";
		public string Root2Str { get; } = "root2";
		public string Root3Str { get; } = "root3";
        public  Calculator()
        {
			numbers = new Queue<double>();
			AccuracyMode = 4;
		}
          double CalcSin(double temp)
        {
            return Math.Sin(temp);
        }
          double CalcCos(double temp){ return Math.Cos(temp); }
          double CalcTg(double temp){ return Math.Tan(temp); }
          double CalcCtg(double temp){ return 1/Math.Tan(temp); }
          double CalcRoot2(double temp){ return Math.Sqrt(temp); }
          double CalcRoot3(double temp){ return Math.Pow(temp, 1.0/3.0); }
          double CalcPow2(double temp){ return Math.Pow(temp, 2); }
          double CalcPow3(double temp){ return Math.Pow(temp, 3); }
		  char CheckFunc(string temp)
        {
			if(temp.Equals(CosStr))
            {
				return Cos;
            }
			else if (temp.Equals(SinStr))
			{
				return Sin;
			}
			else if (temp.Equals(TgStr))
			{
				return Tg;
			}
			else if (temp.Equals(CtgStr))
			{
				return Ctg;
			}
			else if (temp.Equals(Root2Str))
			{
				return Root2;
			}
			else if (temp.Equals(Root3Str))
			{
				return Root3;
			}
			else if (temp.Equals(Pow2Str))
			{
				return Pow2;
			}
			else if (temp.Equals(Pow3Str))
			{
				return Pow3;
			}
            else
            {
				return SmthNull;
            }

		}
		  List<char> ParseString(string exp)
        {
			numbers.Clear();
			List<char> outStr = new List<char>();
			int expLength = exp.Length;
			string temp = "";
			for (int i = 0; i < expLength; i++)
            {
				if(exp[i] == ',') 
				{ 
					return null; 
				}
				else if(GetPriority(exp[i]) != -1)
                {
					outStr.Add(exp[i]);
					if (exp[i] == Minus)
                    {
						if(i == 0 || exp[i-1] == Left)
                        {
							outStr.RemoveAt(outStr.Count - 1);
							temp = "-";
						}
					}
                }
                else if('0' <= exp[i] && exp[i] <= '9')
                {
					while(i < expLength && '0' <= exp[i] && exp[i] <= '9')
                    {
						temp += exp[i];
						i++;
                    }
					if (i != expLength)
					{
						if (exp[i] == ',')
						{
							temp += ',';
							i++;
							while (i < expLength && '0' <= exp[i] && exp[i] <= '9')
							{
								temp += exp[i];
								i++;
							}
						}
						if (i != expLength && exp[i] == ',') return null;
					}
					numbers.Enqueue(Convert.ToDouble(temp));
					outStr.Add(Number);
					temp = "";
					i--;
				}
				else if(exp[i] == ' ') { }
				else if('A' <= exp[i] && exp[i] <= 'z')
                {
					string tempFunctionName = "";
					while(i < expLength && exp[i] != '(' )
                    {
						tempFunctionName += exp[i];
						i++;
                    }
					if(i == expLength)
                    {
						return null;
					}
					char funkName;
					funkName = CheckFunc(tempFunctionName);
					if(funkName == SmthNull || exp[i] == 0) return null;
					outStr.Add(funkName);
					i--;
				}
                else
                {
					return null;
                }
			}
			outStr.Add(End);
			return outStr;
        }

		short GetPriority(char lex)
        {
            if (lex == Left || lex == Right) return 0;
			if (lex == Plus || lex == Minus) return 2;
			if (lex == Star || lex == Dirslash) return 3;
            return -1;
        }
		bool IsFunction(char lex)
        {
			return lex == Root2 || lex == Root3 ||
					lex == Pow2 || lex == Pow3 ||
					lex == Sin || lex == Cos ||
					lex == Tg || lex == Ctg;

		}

		double CalcFunction(char lex, double value)
        {
			if (lex == Root2)
			{
				return CalcRoot2(value);
			}
			else if (lex == Root3)
			{
				return CalcRoot3(value);
			}
			else if (lex == Pow2)
			{
				return CalcPow2(value);
			}
			else if (lex == Pow3)
			{
				return CalcPow3(value);
			}
			else if (lex == Sin)
			{
				return CalcSin(value);
			}
			else if (lex == Cos)
			{
				return CalcCos(value);
			}
			else if (lex == Tg)
			{
				return CalcTg(value);
			}
			else if (lex == Ctg)
			{
				return CalcCtg(value);
			}
            else
            {
				throw new Exception("wtf");
            }

		}

		double CalcOperation(char lex, double value2, double value1)
        {
			if(lex == Plus)
            {
				return value1 + value2;
            }
			else if (lex == Minus)
			{
				return value1 - value2;
			}
			else if (lex == Dirslash)
			{
				return value1 / value2;
			}
			else if (lex == Star)
			{
				return value1 * value2;
			}
			else
            {
				throw new Exception("fs");
            }
		}
         List<char> PolishNotation(List<char> exp)
        {
            Stack<char> stack = new Stack<char>();
			List<char> outexp = new List<char>();
			int pos;
			for (pos = 0;
				exp[pos] != End; pos++)
			{
				if (exp[pos] == Number)
				{
					outexp.Add(Number);
				}
				else if (IsFunction(exp[pos]))
				{
					stack.Push(exp[pos]);
				}
				else if (exp[pos] == Plus || exp[pos] == Minus ||
					exp[pos] == Dirslash || exp[pos] == Star)
				{
					if (exp[pos-1] == Plus || exp[pos-1] == Minus ||
					exp[pos-1] == Dirslash || exp[pos-1] == Star ||
						exp[pos - 1] == Left)
						return null;
					else if (stack.Count == 0 || stack.First() == Left) { }
					else if (GetPriority(stack.First()) >= GetPriority(exp[pos]))
					{
						while (stack.Count != 0 && GetPriority(stack.First()) >= GetPriority(exp[pos]))
						{
							outexp.Add(stack.Pop());
						}
					}
					stack.Push(exp[pos]);
				}
				else if (exp[pos] == Left)
				{
					stack.Push(exp[pos]);
				}
				else if (exp[pos] == Right)
				{
					if (exp[pos-1] != Left && !IsFunction(exp[pos-1]))
					{
						while (stack.Count != 0 && stack.First() != Left)
						{
							outexp.Add(stack.Pop());
						}
						if (stack.Count == 0)
							return null;
						stack.Pop();
						if (stack.Count != 0 && IsFunction(stack.First()))
						{
							outexp.Add(stack.Pop());
						}
					}
					else
						return null;
				}
				else
					return null;
			}
			while (stack.Count != 0)
			{
				
				if (stack.First() == Left) return null;
				outexp.Add(stack.Pop());
			}
			return outexp;

		}

		double CalculateExpression(List<char> exp)
        {
			Stack<double> stack = new Stack<double>();
			foreach(char lex in exp)
            {
				if(lex == Number)
                {
					stack.Push(numbers.Dequeue());
                }
				else if (IsFunction(lex))
                {
					stack.Push(CalcFunction(lex, stack.Pop()));
                }
                else
                {
					stack.Push(CalcOperation(lex, stack.Pop(), stack.Pop()));
                }
            }
			if(stack.Count() != 1)
            {
				throw new Exception("dfkmfslm");
            }
			return stack.Pop();
        }
		public double CalcClear()
		{
			return 0;
		}
		

		public string CalcExtract() { return SavedNumber; }
		string GetOutputMode(double result)
        {
			long tempResult = (int)((result - Math.Floor(result)) * Math.Pow(10, AccuracyMode));
			int i = AccuracyMode;
			for (; i > 0; i--)
            {
				if(tempResult - tempResult / 10 * 10 != 0)
                {
					break;
                }
				tempResult /= 10;
			}
			return $"F{i}";
        }
		public string GetResult(string exp)
        {

			List<char> expression = ParseString(exp);
			if(expression == null) {
				return "Err";
			}
			expression = PolishNotation(expression);
			if (expression == null)
			{
				return "Err";
			}
			double tempResult = CalculateExpression(expression);

			return tempResult.ToString(GetOutputMode(tempResult));
        }
    }
}
