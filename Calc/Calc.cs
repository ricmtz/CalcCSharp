using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Calc
    {

        private static Calc _instance;
        private static object _lock = new Object();

        private Stack<double> values;
        private Stack<string> operators;

        private Calc(){
            values = new Stack<double>();
            operators = new Stack<string>();
        }

        public static Calc GetInstance()
        {
            lock (_lock)
            {
                return _instance ?? ( _instance = new Calc() );
            }
        }

        private void Pow()
        {
            double _base, number, result;
            _base = values.Pop();
            number = values.Pop();
            result = Math.Pow(number, _base);
            values.Push(result);
            //operators.Pop();
        }

        private void MulDiv(String oper)
        {
            double num1, num2, result;
            num2 = values.Pop();
            num1 = values.Pop();
            if(oper == "*"){
                result = num1 * num2;
            }else{
                result = num1 / num2;
            }
            values.Push(result);
        }

        private void SumSub(String oper)
        {
            double num1, num2, result;
            num2 = values.Pop();
            num1 = values.Pop();
            if (oper == "+") {
                result = num1 + num2;
            } else {
                result = num1 - num2;
            }
            values.Push(result);
        }

        public double EvaluateExpresion(List<String> expresion) {
            Console.WriteLine("--------");
            foreach(String token in expresion) {
                Console.WriteLine(token);
                bool isDigit = Double.TryParse(token, out double number);
                if (isDigit){
                    values.Push(number);
                }
                else{
                    operators.Push(token);
                }
            }
            Console.WriteLine("--------");
            String oper;
            while (operators.Count > 0) {
                oper = operators.Pop();
                if (oper == "^"){
                    Pow();
                } else if (oper == "*" || oper == "/") {
                    MulDiv(oper);
                } else if (oper == "+" || oper == "-") {
                    SumSub(oper);
                }
            }
            double res = values.Pop();
            values.Clear();
            return res;
        }
    }
}
