using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    public static class Action
    {
        private class Student
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }

        private static void ShowName(Student student)
        {
            Console.WriteLine("Name = " + student.Name);
        }

        private static void ShowID(Student student)
        {
            Console.WriteLine("ID = " + student.ID);
        }

        private static void CallAction(Action<Student> action)
        {
            Console.WriteLine(action.Method.Name.ToString());
        }

        public static void Test1()
        {
            Action<string> myAction = Console.WriteLine;
            myAction("Hello!");
        }

        public static void Test2()
        {
            var student = new Student() { Name = "Thomas", ID = "001" };
            Action<Student> action = ShowName;
            action(student);
            CallAction(action);
            action = ShowID;
            action(student);
            CallAction(action);

        }
    }
}
