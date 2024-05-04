namespace DuasFilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuInput = 0, queueOption = 0;
            bool exitMenu = false;

            IntQueue queue1 = new();
            IntQueue queue2 = new();
            IntQueue auxiliarQueue = new();

            PopulateQueue(queue1, 10);
            PopulateQueue(queue2, 10);

            do
            {
                Console.Clear();
                Console.WriteLine($"Fila 1 -> {queue1}");
                Console.WriteLine($"Fila 2 -> {queue2}");
                Console.WriteLine($"Fila Auxiliar -> {auxiliarQueue}\n");

                menuInput = Menu();
                switch (menuInput)
                {
                    case 0:
                        exitMenu = true;
                        break;
                    case 1:
                        IntQueue? longestStack = FindLongest(queue1, queue2);
                        if (longestStack == null)
                        {
                            Console.WriteLine("As filas possuem o mesmo tamanho");
                        }
                        else if (longestStack == queue1)
                        {
                            Console.WriteLine($"A filas possuem tamanhos diferentes, a fila 1 é maior com {queue1.Size()} números");
                        }
                        else
                        {
                            Console.WriteLine($"A filas possuem tamanhos diferentes, a fila 2 é maior com {queue2.Size()} números");
                        }
                        break;
                    case 2:
                        Console.WriteLine(queue1.IsEmpty() ? "A fila 1 está vazia..." :
                            $"Pilha 1: O maior e menor valor são {queue1.Max()} e {queue1.Min()}, e a média entre os itens é {queue1.Average()}\n"
                        );
                        Console.WriteLine(queue2.IsEmpty() ? "A fila 2 está vazia..." :
                            $"Pilha 2: O maior e menor valor são {queue2.Max()} e {queue2.Min()}, e a média entre os itens é {queue2.Average()}\n"
                        );
                        break;
                    case 3:
                        do
                        {
                            Console.Write("\nQual fila deseja mover? (1 ou 2): ");
                            queueOption = int.Parse(Console.ReadLine());

                            Console.WriteLine("\nIntes transferidos para a fila auxiliar...\n");
                            if (queueOption == 1)
                            {
                                auxiliarQueue = MoveIntStack(queue1);
                            }
                            else if (queueOption == 2)
                            {
                                auxiliarQueue = MoveIntStack(queue2);
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida, tente novamente.\n");
                            }
                        }
                        while (queueOption < 1 || queueOption > 2);

                        break;
                    case 4:
                        do
                        {
                            Console.Write("\nPara qual fila deseja mover o auxiliar? (1 ou 2): ");
                            queueOption = int.Parse(Console.ReadLine());

                            Console.WriteLine("\nIntes transferidos para a fila selecionada...\n");
                            if (queueOption == 1)
                            {
                                queue1 = MoveIntStack(auxiliarQueue);
                            }
                            else if (queueOption == 2)
                            {
                                queue2 = MoveIntStack(auxiliarQueue);
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida, tente novamente.\n");
                            }
                        }
                        while (queueOption < 1 || queueOption > 2);

                        break;
                    case 5:
                        Console.WriteLine($"Valores pares da fila 1: {queue1.OnlyEvens()}\n");
                        Console.WriteLine($"Valores pares da fila 2: {queue2.OnlyEvens()}\n");
                        break;
                    case 6:
                        Console.WriteLine($"Valores impares da fila 1: {queue1.OnlyOdds()}\n");
                        Console.WriteLine($"Valores impares da fila 2: {queue2.OnlyOdds()}\n");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.\n");
                        break;
                }

                if (menuInput != 0)
                {
                    Console.Write("\n\n-> Aperte qualquer tecla para voltar ao menu <-");
                }
                Console.ReadKey();
            }
            while (!exitMenu);
        }

        static int Menu()
        {
            /*
               A) Uma função para testar se as duas filas são iguais em tamanho, caso não forem informe qual é a maior.
               B) Uma função que forneça o maior, o menor e  a média aritmérica dos elementos das filas.
               C) Uma função para transferir os elementos da fila que eu informar para uma fila Auxiliar.
               D) Uma função para informar os elementos impares das filas e a quantidade.
               E) Uma função para informar os elementos pares das filas e a quantidade.
             */
            int input = 0;

            Console.WriteLine("Menu\n");
            Console.WriteLine("(1) - Verificar se as filas são iguais em tamanho");
            Console.WriteLine("(2) - Verificar valores maiores e menores e sua média");
            Console.WriteLine("(3) - Mover itens para a fila auxiliar");
            Console.WriteLine("(4) - Mover da fila auxiliar para uma desejada");
            Console.WriteLine("(5) - Encontrar valores pares das filas");
            Console.WriteLine("(6) - Encontrar valores impares das filas");
            Console.WriteLine("(0) - Sair");
            Console.Write("\nInsira sua opção: ");
            input = int.Parse(Console.ReadLine());

            return input;
        }

        static void PopulateQueue(IntQueue queue, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                queue.Push(new Random().Next(0, 100));
            }
        }

        static IntQueue? FindLongest(IntQueue queue1, IntQueue queue2)
        {
            if (queue1.Size() > queue2.Size())
            {
                return queue1;
            }

            if (queue1.Size() < queue2.Size())
            {
                return queue2;
            }

            return null;
        }

        static IntQueue MoveIntStack(IntQueue queue, bool reversed = false)
        {
            IntQueue tempStack = new();

            while (!queue.IsEmpty())
            {
                tempStack.Push((int)queue.Pop());
            }

            if (reversed)
            {
                return tempStack;
            }

            return MoveIntStack(tempStack, true);
        }

    }
}
