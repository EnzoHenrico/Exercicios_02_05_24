using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class Student : StudentStackControl
    {
        string name;
        int number;

        public Student(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        public override string ToString()
        {
            return $"{number} - {name}";
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return number;
        }
    }
}
