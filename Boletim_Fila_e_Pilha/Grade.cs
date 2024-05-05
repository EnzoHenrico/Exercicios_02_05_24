using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class Grade: GradeQueueControl
    {
        float value;
        int studentNumber;

        public Grade(float value, int studentNumber)
        {
            this.value = value;
            this.studentNumber = studentNumber;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public float GetValue()
        {
            return value;
        }

        public int GetStudentNumber()
        {
            return studentNumber;
        }
    }
}
