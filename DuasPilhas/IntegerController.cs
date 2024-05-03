using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuasPilhas
{
    internal class IntegerController
    {
        int value;
        IntegerController? previous;

        public IntegerController(int value)
        {
            this.value = value;
            this.previous = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public void SetPrevious(IntegerController? previous)
        {
            this.previous = previous;
        }

        public IntegerController? GetPrevious()
        {
            return this.previous;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }
    }
}
