using System;

namespace Static_Extensions
{
    enum UserChoices { Show_Info = 1, Create_New_Group, Show_All_Groups };
    enum StudentChoices { Show_All_Atudents = 1, Get_Student_by_ID, Add_Student, Quit };


    class Program
    {
        static void Main(string[] args)
        {
            Group[] group = new Group[0];
            #region User creation


            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();

            User user1 = new User(email, password);
            user1.Name = name;
            user1.Surname = surname;
            Console.Clear();

            #endregion

            #region Menu
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n1) Show user info");
                Console.WriteLine("2) Create new group");
                Console.WriteLine("3) All of Groups and Students");
                int input = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (input)
                {
                    case (int)UserChoices.Show_Info:
                        Console.Clear();
                        user1.ShowInfo();
                        break;

                    case (int)UserChoices.Create_New_Group:
                        Console.Clear();
                        Console.Write("\nPlease write the name of group: ");
                        string groupName = Console.ReadLine();
                        Console.Write($"Please enter the limit for the {groupName}: ");
                        int studentlimit = int.Parse(Console.ReadLine());
                        Group group_1 = new Group(groupName, studentlimit);

                        if (group_1.StudentLimit != 0 && group_1.GroupNo != null)
                        {
                            Array.Resize(ref group, group.Length + 1);
                            group[group.Length - 1] = group_1;
                            Console.WriteLine($"{group_1.GroupNo} created !");
                        }
                        if (group.Length > 0)
                        {
                            int input2;
                            do
                            {
                                Console.WriteLine("\n1) Show all students");
                                Console.WriteLine("\n2) Get student by id");
                                Console.WriteLine("\n3) Add student");
                                Console.WriteLine("\n0) Back to Main Menu");

                                input2 = int.Parse(Console.ReadLine());
                                switch (input2)
                                {
                                    case (int)StudentChoices.Show_All_Atudents:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        group_1.GetAllStudents();
                                        Console.ResetColor();
                                        break;

                                    case (int)StudentChoices.Get_Student_by_ID:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Please enter the student ID: ");
                                        int id = int.Parse(Console.ReadLine());
                                        group_1.GetStudent(id);
                                        Console.ResetColor();
                                        break;

                                    case (int)StudentChoices.Add_Student:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("Enter student name: ");
                                        string stname = Console.ReadLine();
                                        Console.Write("Enter student surname: ");
                                        string stsurname = Console.ReadLine();
                                        Console.Write("Enter the point: ");
                                        int point = int.Parse(Console.ReadLine());

                                        Student student1 = new Student(stname, stsurname, point);
                                        group_1.AddStudent(student1);
                                        Console.ResetColor();
                                        break;

                                    case (int)StudentChoices.Quit:
                                        break;

                                }
                            } while (input2 != 0);
                        }
                        break;

                    case (int)UserChoices.Show_All_Groups:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (group.Length > 0)
                        {
                            foreach (Group groups in group)
                            {
                                Console.WriteLine(groups);
                                groups.GetAllStudents();
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You dont registered any group yet");
                            Console.ResetColor();
                        }

                        break;

                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);



            #endregion
        }

    }
}
