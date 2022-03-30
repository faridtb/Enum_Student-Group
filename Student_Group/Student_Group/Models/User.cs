using System;
using System.Collections.Generic;
using System.Text;

namespace Static_Extensions
{
    class User : IAccount
    {
        private string _password;
        private static int _id;
        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get { return _password; }
            set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                    return;
                }
                Console.WriteLine("Your Password doesnt correct !");
            } 
        }



        public User(string email,string password)
        {
            Email = email;
            Password = password;
            if (Password !=null)
            {
                _id++;
                ID = _id;
            }

        }

        public bool PasswordChecker(string password)
        {
            bool isCap = false;
            bool isLet = false;
            bool isDig = false;
            bool result = false;

            if (password.Length>=8)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (isCap!=Char.IsUpper(password[i]))
                    {
                        isCap = true;
                    }
                    if (isLet != Char.IsLetter(password[i]))
                    {
                        isLet = true;
                    }
                    if (isDig != Char.IsDigit(password[i]))
                    {
                        isDig = true;
                    }
                }
                if (isCap == true && isLet == true && isDig == true)
                {
                    result = true;
                }
            }
            return result;
        }

        public void ShowInfo()
        {
            if (Password != null )
            {
                Console.WriteLine($"ID: {ID}\n" +
                $"Fullname: {Name} {Surname}\n" +
                $"Email: {Email}");
            }
            else 
            {
                Console.WriteLine("Try Again");
            } 

        }
    }



    interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();

    }
}
