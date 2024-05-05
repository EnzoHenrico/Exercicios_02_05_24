using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Boletim_Fila_e_Pilha
{
    internal class StudentStack
    {
        Student? top;
        int length;

        public StudentStack()
        {
            top = null;
            length = 0;
        }

        public override string ToString()
        {
            Student? temp = top;
            string text = "";

            while (temp != null)
            {
                text += $"{temp}\n";
                temp = temp.GetPrevious();
            }
            return text;
        }

        public Student? FindStudentByNumber(int studentNumber)
        {
            Student? temp = top;

            while (temp.GetNumber() != studentNumber)
            {
                temp = temp.GetPrevious();
            }

            return temp;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public int Length()
        {
            return length;
        }

        public void Push(Student newStudent)
        {
            Student? temp = top;
            newStudent.SetPrevious(temp);
            top = newStudent;
            length++;
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                top = top.GetPrevious();
            }
        }
    }
}
