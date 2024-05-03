 using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DuasPilhas
{
    internal class IntStack
    {
        IntController? top;
        int size;

        public IntStack() 
        {
            this.top = null;
            this.size = 0;
        }

        public override string ToString()
        {
            string result = "";
            IntController? temp = this.top;

            while (temp != null)
            {
                result += temp.ToString();
                temp = temp.GetPrevious();

                if (temp != null)
                {
                    result += ", ";
                }
            }
            return result;
        }

        public void Push(int value)
        {
            IntController current = new(value);

            current.SetPrevious(this.top);
            this.top = current;
            this.size++;
        }

        public int? Pop()
        {
            int? value = null;
            if (!IsEmpty())
            {
                value = this.top.GetValue();
                this.top = this.top?.GetPrevious();
                this.size--;
            }

            return value;
        }

        public int Size()
        {
            return this.size;
        }

        public float Average()
        {
            if (IsEmpty())
            {
                return 0;
            }

            IntController temp = this.top;
            int acc = 0;

            while (temp != null)
            {
                acc++;
                temp = temp.GetPrevious();
            }

            return acc / this.size;
        }
         
        public bool IsEmpty()
        {
            return this.top == null;
        }

        public int? Max()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntController? temp = this.top;
            int? maxValue = this.top?.GetValue();

            while (temp != null)
            {
                if (maxValue > temp.GetValue())
                {
                    maxValue = temp.GetValue();
                }
                temp = temp.GetPrevious();
            }
            return maxValue;
        }

        public int? Min()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntController? temp = this.top;
            int? minValue = this.top?.GetValue();

            while (temp != null)
            {
                if (minValue < temp.GetValue())
                {
                    minValue = temp.GetValue();
                }
                temp = temp.GetPrevious();
            }
            return minValue;
        }

        public IntStack OnlyEvens(IntStack stack)
        {
            IntStack evensStack = new();
            IntController? temp = this.top;

            while (temp != null)
            {
                int currentValue = temp.GetValue();
                if (currentValue % 2 != 0)
                {
                    evensStack.Push(currentValue);
                }

                temp = temp.GetPrevious();
            }

            return evensStack;
        }

        public IntStack OnlyOdds(IntStack stack)
        {
            IntStack oddsStack = new();
            IntController? temp = this.top;

            while (temp != null)
            {
                int currentValue = temp.GetValue();
                if (currentValue % 2 == 0)
                {
                    oddsStack.Push(currentValue);
                }

                temp = temp.GetPrevious();
            }

            return oddsStack;
        }
    }
}
