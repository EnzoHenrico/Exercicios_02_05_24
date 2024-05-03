using System.Runtime.InteropServices;

namespace DuasPilhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntStack stack1 = new();
            IntStack stack2 = new();

            int input;
            bool exit = false;
            do
            {
                Console.Clear();
                input = Menu();

                switch (input)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.\n");
                        break;
                }

                Console.Write("\n\n    Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
            }
            while (!exit);
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
            do
            {
                Console.Clear();
                Console.WriteLine("Menu\n");
                Console.WriteLine("(1) - Verificar se as pilhas são iguais em tamanho");                
                Console.WriteLine("(2) - Verificar valores maiores e menores e sua média");                
                Console.WriteLine("(3) - Mover itens para a pilha auxiliar");                
                Console.WriteLine("(4) - Encontrar valores pares das pilhas");                
                Console.WriteLine("(5) - Encontrar valores impares das pilhas");
                Console.WriteLine("(6) - Sair");
                Console.Write("\nInsira sua opção: ");
                input = int.Parse(Console.ReadLine());

                if (input < 1 || input > 6)
                {
                    Console.WriteLine("\nOpção inválida, pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                }
            }
            while (input < 1 || input > 6);

            return input;
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
 