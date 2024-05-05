namespace FilaFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0, prev = 0, current = 1, next = 0;
            IntQueue queue = new();

            Console.Write("Quantos números da sequencia fibonacci deseja receber?  ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                queue.Push(prev);
                next = current + prev;
                prev = current;
                current = next;
            }

            Console.WriteLine("\n" + queue);
        }
    }

    internal class IntQueue
    {
        IntControl? head;
        IntControl? tail;

        public IntQueue()
        {
            this.head = null;
            this.tail = null;
        }

        public override string ToString()
        {
            string result = string.Empty;
            IntControl? temp = this.head;

            while (temp != null)
            {
                result += temp + "\n";
                temp = temp.GetNext();
            }

            return result;
        }

        public void Push(int value)
        {
            IntControl current = new(value);

            if (this.IsEmpty())
            {
                this.head = this.tail = current;
            }
            else
            {
                this.tail?.SetNext(current);
                this.tail = current;
            }

        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

    }

    internal class IntControl
    {
        int value;
        IntControl? next;

        public IntControl(int value)
        {
            this.value = value;
            this.next = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void SetNext(IntControl? next)
        {
            this.next = next;
        }

        public IntControl? GetNext()
        {
            return this.next;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
