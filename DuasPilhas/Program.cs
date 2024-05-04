namespace DuasPilhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuInput = 0, stackOption = 0;
            bool exitMenu = false;

            IntStack stack1 = new();
            IntStack stack2 = new();
            IntStack auxiliarStack = new();

            PopulateStack(stack1, 10);
            PopulateStack(stack2, 10);

            do
            {
                Console.Clear();
                Console.WriteLine($"Pilha 1 -> {stack1}");
                Console.WriteLine($"Pilha 2 -> {stack2}");
                Console.WriteLine($"Pilha Auxiliar -> {auxiliarStack}\n");
                
                menuInput = Menu();
                switch (menuInput)
                {
                    case 0:
                        exitMenu = true;
                        break;
                    case 1:
                        IntStack? longestStack = FindLongest(stack1, stack2);
                        if (longestStack == null)
                        {
                            Console.WriteLine("As pilhas possuem o mesmo tamanho");
                        }
                        else if (longestStack == stack1)
                        {
                            Console.WriteLine($"A pilhas possuem tamanhos diferentes, a pilha 1 é maior com {stack1.Size()} números");
                        }
                        else
                        {
                            Console.WriteLine($"A pilhas possuem tamanhos diferentes, a pilha 2 é maior com {stack2.Size()} números");
                        }
                        break;
                    case 2:
                        Console.WriteLine(stack1.IsEmpty() ? "A pilha 1 está vazia..." :
                            $"Pilha 1: O maior e menor valor são {stack1.Max()} e {stack1.Min()}, e a média entre os itens é {stack1.Average()}\n"
                        );
                        Console.WriteLine(stack2.IsEmpty()? "A pilha 2 está vazia..." :
                            $"Pilha 2: O maior e menor valor são {stack2.Max()} e {stack2.Min()}, e a média entre os itens é {stack2.Average()}\n"
                        );
                        break;
                    case 3:
                        do
                        {
                            Console.Write("\nQual pilha deseja mover? (1 ou 2): ");
                            stackOption = int.Parse(Console.ReadLine());
                            
                            Console.WriteLine("\nIntes transferidos para a pilha auxiliar...\n");
                            if (stackOption == 1)
                            {
                                auxiliarStack = MoveIntStack(stack1);
                            }
                            else if (stackOption == 2)
                            {
                                auxiliarStack = MoveIntStack(stack2);
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida, tente novamente.\n");
                            }
                        }
                        while (stackOption < 1 || stackOption > 2);

                        break;
                    case 4:
                        do
                        {
                            Console.Write("\nPara qual pilha deseja mover o auxiliar? (1 ou 2): ");
                            stackOption = int.Parse(Console.ReadLine());

                            Console.WriteLine("\nIntes transferidos para a pilha selecionada...\n");
                            if (stackOption == 1)
                            {
                                stack1 = MoveIntStack(auxiliarStack);
                            }
                            else if (stackOption == 2)
                            {
                                stack2 = MoveIntStack(auxiliarStack);
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida, tente novamente.\n");
                            }
                        }
                        while (stackOption < 1 || stackOption > 2);

                        break;
                    case 5:
                        Console.WriteLine($"Valores pares da pilha 1: {stack1.OnlyEvens()}\n");
                        Console.WriteLine($"Valores pares da pilha 2: {stack2.OnlyEvens()}\n");
                        break;
                    case 6:
                        Console.WriteLine($"Valores impares da pilha 1: {stack1.OnlyOdds()}\n");
                        Console.WriteLine($"Valores impares da pilha 2: {stack2.OnlyOdds()}\n");
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
               A) Uma função para testar se as duas pilhas são iguais em tamanho, caso não forem informe qual é a maior.
               B) Uma função que forneça o maior, o menor e  a média aritmérica dos elementos das pilhas.
               C) Uma função para transferir os elementos da pilha que eu informar para uma pilha Auxiliar.
               D) Uma função para informar os elementos impares das pilhas e a quantidade.
               E) Uma função para informar os elementos pares das pilhas e a quantidade.
             */
            int input = 0;

            Console.WriteLine("Menu\n");
            Console.WriteLine("(1) - Verificar se as pilhas são iguais em tamanho");                
            Console.WriteLine("(2) - Verificar valores maiores e menores e sua média");                
            Console.WriteLine("(3) - Mover itens para a pilha auxiliar");
            Console.WriteLine("(4) - Mover da pilha auxiliar para uma desejada");                
            Console.WriteLine("(5) - Encontrar valores pares das pilhas");                
            Console.WriteLine("(6) - Encontrar valores impares das pilhas");
            Console.WriteLine("(0) - Sair");
            Console.Write("\nInsira sua opção: ");
            input = int.Parse(Console.ReadLine());

            return input;
        }

        static void PopulateStack(IntStack stack, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                stack.Push(new Random().Next(0, 100));
            }
        }

        static IntStack? FindLongest(IntStack stack1, IntStack stack2)
        {
            if (stack1.Size() > stack2.Size())
            {
                return stack1;
            }

            if (stack1.Size() < stack2.Size())
            {
                return stack2;
            }

            return null;
        }

        static IntStack MoveIntStack(IntStack stack, bool reversed = false)
        {
            IntStack tempStack = new();

            while (!stack.IsEmpty())
            {
                tempStack.Push((int)stack.Pop());
            }

            if (reversed)
            {
                return tempStack;
            }

            return MoveIntStack(tempStack, true);
        }

    }
}
 