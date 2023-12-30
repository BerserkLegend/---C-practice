using System;
using static Homework12._10._23.Student;

namespace Homework12._10._23
{



    



    delegate void ExamDelegate(string msg);


    class Student
    {

       public class Name
        {
           public string name;
           public string surname;
           public DateTime BirthDate;
            public Name()
            {
                name = "";
                surname = "";
                BirthDate = new DateTime(0, 0, 0);
            }
            public Name(string name,string surname,DateTime birth)
            {
                this.name = name;
                this.surname = surname;
                BirthDate = birth;
            }
            public override string ToString()
            {
                
                return String.Format("name:{0},surname:{1},Birthdate:{2}",name,surname,BirthDate.ToShortDateString());
            }
            
        }
       public Name name;
        public void Exam(string msg)
        {
            Console.WriteLine(name);

        }
    }

    class Teacher
    {
       public event ExamDelegate ExamEvent;

     public void ExamStudent()
        {
            ExamEvent("something happen");

        }

    }
    internal class Program
    {




        static void Main(string[] args)
        {
            


            //3
            /*Student student = new Student()
            {
                name = new Student.Name("ssss", "dddds", new DateTime(2006, 08, 13))
            };
            Console.WriteLine(student.name);*/



            Student[] students = new Student[3]{
            new Student { name = new Student.Name("ssssss", "ddefefdd", new DateTime(2000, 6, 1)) },
            new Student { name = new Student.Name("ssgggs", "ggggg", new DateTime(2000, 6, 1)) },
            new Student { name = new Student.Name("shhhss", "fffff", new DateTime(2000, 6, 1)) }
            };

            Teacher teacher = new Teacher();
            students[0].Exam("start1 exam");
            students[1].Exam("start2 exam");
            students[2].Exam("start3 exam");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("who starting Exam:");
            teacher.ExamEvent += students[0].Exam;
            teacher.ExamEvent += students[1].Exam;
            teacher.ExamEvent += students[2].Exam;
            teacher.ExamStudent();
            teacher.ExamEvent -= students[0].Exam;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Updating info:");
            teacher.ExamStudent();

        }
    }
}
