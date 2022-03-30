using System;
using System.Collections.Generic;
using System.Text;

namespace Static_Extensions
{
    class Student // bura okey
    {
        private static int _id;

        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Point { get; set; }


        public Student(string name, string surname, int point)
        {
            Name = name;
            Surname = surname;
            Point = point;
            _id++;
            ID = _id;
        }
        public override string ToString()
        {
            return StudentInfo();
        }
        public string StudentInfo()
        {
            return ($"Student ID: {ID}\n" +
                $"Student Name: {Name}\n" +
                $"Student Surname: {Surname}\n" +
                $"Student Point: {Point}\n" +
                $"=========================");

        }




    }
}
