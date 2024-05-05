/*
    (6) -> Faça um programa que apresente o seguinte menu de opções:
     
     1) Cadastrar aluno
     2) Cadastrar nota
     3) Calcular a média do aluno
     4) Listar o nome dos alunos sem nota
     5) Excluir aluno
     6) Excluir nota
     0) Sair
   
   Obs: 
     0) Duas notas por aluno
     1) Cadastre um aluno (nome e numero) de cada vez em uma pilha.
     2) Os números dos alunos devem ser gerados automaticamente a partir do 1.
     3) Cadastre uma nota (número do aluno / nota) de cada vez em uma fila.
     4) Uma nota só pode ser cadastrada se pertencer a um aluno existente na pilha.
     5) Premissa par afunção de média: O usuário deve digitar o número do aluno para calcular a sua média.
     6) Avise o usuário caso não existir o aluno ou a nota.
     7) Um aluno só pode ser excluido se não possuir notas. As notas devem ser excluidas respeitando as regras da fila.
 */

using System.Threading.Channels;

namespace Boletim_Fila_e_Pilha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentNumber, gradeValue; 
            float gradeAverage;
            ClassRoom classRoom = new();

            do
            {
                int option = Menu();
                switch (option)
                {
                    case 1:
                        Console.Write("Digite o nome do novo aluno: ");
                        string newStudentName = Console.ReadLine();
                        classRoom.AddStudent(newStudentName);

                        Console.WriteLine($"O aluno {newStudentName} foi adicionado a sala! \n");
                        break;
                    case 2:
                        Console.Write("Digite o número do aluno para cadastrar nota: ");
                        studentNumber = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor da nota a ser cadastrada: ");
                        gradeValue = int.Parse(Console.ReadLine());

                        classRoom.AddGradeByStudentNumber(gradeValue, studentNumber);

                        Console.WriteLine($"Nota do aluno adicionada! \n");
                        break;
                    case 3:
                        Console.Write("Digite o número do aluno calcular a média: ");
                        studentNumber = int.Parse(Console.ReadLine());

                        gradeAverage = classRoom.GetStudentGradeAverage(studentNumber);
                        Console.WriteLine($"A média do aluno é {gradeAverage}");
                        break;
                    case 4:
                        break;
                }

                Console.WriteLine(classRoom.GetStudentsList());
                Console.ReadKey();
            } while (true);
        }

        static int Menu()
        {
            Console.WriteLine("1) Cadastrar aluno\r\n" +
                              "2) Cadastrar nota\r\n" +
                              "3) Calcular a média do aluno\r\n" +
                              "4) Listar o nome dos alunos sem nota\r\n" +
                              "5) Excluir aluno\r\n" +
                              "6) Excluir nota\r\n" +
                              "0) Sair");

            return int.Parse(Console.ReadLine());
        }
    }
}
