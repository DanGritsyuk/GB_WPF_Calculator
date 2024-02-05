using System;
using System.Collections.Generic;

namespace GB_WPF_Calculator
{
    internal class Calculator
    {
        public event EventHandler<CalculatorArgs> Result;

        public int result { get; private set; } = 0;
        Stack<int> results = new Stack<int> ();

        public void Add(int value)
        {
            results.Push (result);
            result += value;
            Calculation();
        }

        public void Sub(int value)
        {
            results.Push(result);
            result -= value;
            Calculation();
        }

        public void Mul(int value) 
        {
            results.Push(result);
            result *= value;
            Calculation();
        }

        public void Div(int value)
        {
            results.Push(result);
            result /= value;
            Calculation();
        }

        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                Calculation();
            }
        }

        private void Calculation()
        {
            if (Result != null)
            {
                Result.Invoke(this, new CalculatorArgs { answer = result});
            }
        }
    }
}