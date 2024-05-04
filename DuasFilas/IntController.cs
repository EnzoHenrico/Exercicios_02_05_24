using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuasFilas
{
    internal class IntController
    {
        int value;
        IntController? next;

        public IntController(int value)
        {
            this.value = value;
            this.next = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void SetNext(IntController? next)
        {
            this.next = next;
        }

        public IntController? GetNext()
        {
            return this.next;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
