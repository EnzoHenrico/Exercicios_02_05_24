using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletim_Fila_e_Pilha
{
    internal class ClassRoom
    {
        StudentStack students;
        GradeQueue grades;
        int studentsCount;

        public ClassRoom()
        {
                students = new StudentStack();
                grades = new GradeQueue();
                studentsCount = 0;
        }

        public void AddStudent(string name)
        {
            studentsCount++;
            students.Push(new Student(name, studentsCount));
        }

        public void AddGradeByStudentNumber(int gradeValue, int studentNumber)
        {
            Student? student = students.FindStudentByNumber(studentNumber);

            if (student == null)
            {
                return;
            }

            grades.Push(new Grade(gradeValue, studentNumber));
        }

        public float GetStudentGradeAverage(int studentNumber)
        {
            Student? student = students.FindStudentByNumber(studentNumber);
            return grades.GetGradeAverageByStudent(studentNumber);
        }

        public string GetStudentsList()
        {
            return students.ToString();
        }
    }
}
