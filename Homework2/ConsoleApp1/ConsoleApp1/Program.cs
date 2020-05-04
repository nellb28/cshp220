//Nell Brisard
//Assignment 2

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPassword =
            from person in users
            where person.Password == "hello"
            select person;
            var targetUser = helloPassword.ToArray();

            Console.WriteLine("______________users w/password = hello_____________");
            foreach (var person in targetUser) Console.WriteLine(person.Name);

            var modifiedUsers = users.ToList();
            modifiedUsers = deletePassword(modifiedUsers);

            Console.WriteLine("______________deleted users_____________");
            foreach (var person in modifiedUsers) Console.WriteLine(person.Name);


            var deleteMe = users.FirstOrDefault(e => e.Password == "hello");
            modifiedUsers.Remove(deleteMe);

            Console.WriteLine("______________Final Set _____________");
            foreach (var person in modifiedUsers) Console.WriteLine(person.Name);
        }

        //I could definitely refactor this solution to be more modular
        public static List<Models.User> deletePassword(List<Models.User> setOfUsers)
        {
            var modifiedUsers = setOfUsers.ToList();

            foreach (var person in setOfUsers)
            {
                if (person.Password.ToLower() == person.Name.ToLower())
                {
                    modifiedUsers.Remove(person);
                }
            }
            return modifiedUsers;
        }
    }
}
