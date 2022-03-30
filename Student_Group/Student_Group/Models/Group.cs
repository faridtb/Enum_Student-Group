using System;

namespace Static_Extensions
{
    class Group
    {
        private int _studentLimit;
        private string _groupno;
        public string GroupNo
        {
            get { return _groupno; }
            set
            {
                if (CheckGroupNo(value))
                {
                    _groupno = value;
                    return;
                }
            }
        }
        public int StudentLimit
        {
            get { return _studentLimit; }
            set
            {
                if (value > 1 && value < 19)
                {
                    _studentLimit = value;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You exceeded the limit");
                Console.ResetColor();

            }
        }
        private Student[] students;

        public Group(string groupno, int studentlimit)
        {
            students = new Student[0];
            GroupNo = groupno;
            StudentLimit = studentlimit;

        }
        public bool CheckGroupNo(string groupNo)
        {
            bool result = false;
            bool isCap = false;
            bool isDig = false;
            if (groupNo.Length == 5)
            {
                for (int i = 0; i < groupNo.Length - 3; i++)                 // Herfleri yoxlamaq ucun
                {
                    isCap = false;
                    if (isCap != Char.IsUpper(groupNo[i]))
                    {
                        isCap = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("First two letters must be uppercase !");
                        Console.ResetColor();
                        break;
                    }
                }
                for (int i = 2; i < groupNo.Length; i++)  // Reqemleri yoxlamaq ucun 
                {
                    isDig = false;

                    if (isDig != Char.IsNumber(groupNo[i]))
                    {
                        isDig = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The name of the group must contain 3 numbers !");
                        Console.ResetColor();
                        break;
                    }
                }
                result = isCap && isDig;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The name of the group must consist of 2 Uppercase Letter and 3 numbers");
                Console.ResetColor();
            }
            return result;
        }
        public override string ToString()
        {
            return $"\n{GroupNo}\n" +
                $"";
        }
        public void AddStudent(Student stu)
        {
            if (students.Length < StudentLimit)
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = stu;
                Console.WriteLine($"Student:{stu.Name} has been added to:{GroupNo} group !");
                return;
            }
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"In this:{GroupNo} group, student limit has exceeded");
            Console.ResetColor();


        }
        public void GetStudent(int? id)
        {
            bool exist = false;
            foreach (Student stu in students)
            {
                if (id == stu.ID)
                {
                    Console.WriteLine(stu);
                    exist = true;
                    return;
                }
            }
            if (exist == false)
            {
                Console.WriteLine($"Sorry, no student with:{id} ID was found in this:{GroupNo} group.");
            }
        }
        public void GetAllStudents()
        {
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);            
            }
        }
    }
}
