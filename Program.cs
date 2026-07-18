using System;
using System.Security.Cryptography;
class Program{
class Student{
        public string name {get;set;}

        public List<string> courses = new List<string>();
        public int age{get;set;}
}
static void Main(string[] args)
{
    List<Student> students = new List<Student>();
    
    Student s1 = new Student();
    s1.name = "Hala";
    s1.courses.Add("Math");
    s1.courses.Add("Reading");
    s1.courses.Add("Science");
    s1.courses.Add("Phonix");
    s1.courses.Add("Health");
    s1.courses.Add("Writing");
    s1.age = 8;

    Student s2 = new Student();
    s2.name = "Farouq";
    s2.courses.Add("Math");
    s2.courses.Add("PE");
    s2.courses.Add("Science");
    s2.age = 9;

    Student s3 = new Student();
    s3.name = "Haya";
    s3.courses.Add("Math");
    s3.courses.Add("English");
    s3.courses.Add("Art");
    s3.courses.Add("Math");
    s3.age = 11;

    students.Add(s1);
    students.Add(s2);
    students.Add(s3);
    for(int i =0; i < students.Count; i++)
        {
            Console.WriteLine($"My name is {students[i].name}, my age is {students[i].age} and my cources is {string.Join(", ",students[i].courses)}");
        }
    
}
}