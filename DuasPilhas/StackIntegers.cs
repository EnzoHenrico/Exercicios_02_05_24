using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuasPilhas
{
    internal class StackIntegers
    {
        IntegerController? top;

        public StackIntegers() 
        {
            this.top = null;
        }

        public void Push(int value)
        {
            IntegerController current = new(value);

            current.SetPrevious(this.top);
            this.top = current;
        }

        public void Pop()
        {
            if (!IsEmpty()) 
            {
                this.top = this.top?.GetPrevious();
            }
        }

        public bool IsEmpty()
        {
            return this.top == null;
        }

    }
}
