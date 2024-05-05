using System.Xml.Serialization;

namespace PilhaFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0, prev = 0, current = 1, next = 0;
            IntStack stack = new();

            Console.Write("Quantos números da sequencia fibonacci deseja receber?  ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                stack.Push(prev);
                next = current + prev;
                prev = current;
                current = next;
            }

            Console.WriteLine("\n" + stack);
        }
    }

    internal class IntStack
    {
        IntControl? top;

        public IntStack()
        {
            this.top = null;
        }

        public override string ToString()
        {
            string result = "";
            IntControl? temp = this.top;

            while (temp != null)
            {
                result += temp + "\n";
                temp = temp.GetPrevious();
            }
            return result;
        }

        public void Push(int value)
        {
            IntControl current = new(value);

            current.SetPrevious(this.top);
            this.top = current;
        }
    }

    internal class IntControl
    {
        int value;
        IntControl? previous;

        public IntControl(int value)
        {
            this.value = value;
            this.previous = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void SetPrevious(IntControl? previous)
        {
            this.previous = previous;
        }

        public IntControl? GetPrevious()
        {
            return this.previous;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
