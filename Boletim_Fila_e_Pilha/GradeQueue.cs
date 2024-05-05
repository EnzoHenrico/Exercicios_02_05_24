using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class GradeQueue
    {
        Grade? head;
        Grade? tail;
        int size;

        public GradeQueue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public override string ToString()
        {
            string result = string.Empty;
            Grade? temp = this.head;

            while (temp != null)
            {
                result += temp + "\n";
                temp = temp.GetNext();
            }

            return result;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Push(Grade newGrade)
        {
            if (IsEmpty())
            {
                head = tail = newGrade;
            }
            else
            {
                tail?.SetNext(newGrade);
                tail = newGrade;
            }

            size++;
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                head = head?.GetNext();
            }

            size--;
        }

        public float GetGradeAverageByStudent(int studentNumber)
        {
            if (IsEmpty())
            {
                return 0;
            }

            Grade? temp = this.head;
            float acc = 0;

            while (temp != null)
            {
                if (studentNumber == temp.GetStudentNumber())
                {
                    acc += temp.GetValue();
                }
                temp = temp.GetNext();
            }

            return acc / this.size;
        }
    }
}
