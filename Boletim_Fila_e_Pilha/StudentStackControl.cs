using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class StudentStackControl
    {
        Student? previous;

        public StudentStackControl()
        {
            previous = null;
        }

        public Student? GetPrevious()
        {
            return previous;
        }

        public void SetPrevious(Student? student)
        {
            previous = student;
        }
    }
}
