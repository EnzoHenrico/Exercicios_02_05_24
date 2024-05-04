using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuasFilas
{
    internal class IntQueue
    {
        IntController? head;
        IntController? tail;
        int size;

        public IntQueue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public override string ToString()
        {
            string result = string.Empty;
            IntController? temp = this.head;

            while (temp != null)
            {
                result += temp.ToString();
                temp = temp.GetNext();

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

            if (this.IsEmpty())
            {
                this.head = this.tail = current;
            }
            else
            {
                this.tail?.SetNext(current);
                this.tail= current;
            }
            this.size++;
        }

        public int? Pop()
        {
            int? value = null;
            
            if (!IsEmpty())
            {
                value = this.head?.GetValue();
                this.head = this.head?.GetNext();
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

            IntController? temp = this.head;
            int acc = 0;

            while (temp != null)
            {
                acc += temp.GetValue();
                temp = temp.GetNext();
            }

            return acc / this.size;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

        public int? Max()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntController? temp = this.head;
            int? maxValue = this.head?.GetValue();

            while (temp != null)
            {
                if (maxValue > temp.GetValue())
                {
                    maxValue = temp.GetValue();
                }
                temp = temp.GetNext();
            }
            return maxValue;
        }

        public int? Min()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntController? temp = this.head;
            int? minValue = this.head?.GetValue();

            while (temp != null)
            {
                if (minValue < temp.GetValue())
                {
                    minValue = temp.GetValue();
                }
                temp = temp.GetNext();
            }
            return minValue;
        }

        public IntQueue OnlyOdds()
        {
            IntQueue evensQueue = new();
            IntController? temp = this.head;

            while (temp != null)
            {
                int currentValue = temp.GetValue();
                if (currentValue % 2 != 0)
                {
                    evensQueue.Push(currentValue);
                }

                temp = temp.GetNext();
            }

            return evensQueue;
        }

        public IntQueue OnlyEvens()
        {
            IntQueue oddsQueue = new();
            IntController? temp = this.head;

            while (temp != null)
            {
                int currentValue = temp.GetValue();
                if (currentValue % 2 == 0)
                {
                    oddsQueue.Push(currentValue);
                }

                temp = temp.GetNext();
            }

            return oddsQueue;
        }
    }
}
