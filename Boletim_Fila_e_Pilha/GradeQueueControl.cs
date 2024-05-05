using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class GradeQueueControl
    {
        Grade? next;

        public GradeQueueControl()
        {
            next = null;
        }

        public Grade? GetNext()
        {
            return next;
        }

        public void SetNext(Grade? next)
        {
            this.next = next;
        }
    }
}
