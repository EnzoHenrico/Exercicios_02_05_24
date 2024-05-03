using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuasPilhas
{
    internal class IntController
    {
        int value;
        IntController? previous;

        public IntController(int value)
        {
            this.value = value;
            this.previous = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void SetPrevious(IntController? previous)
        {
            this.previous = previous;
        }

        public IntController? GetPrevious()
        {
            return this.previous;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
