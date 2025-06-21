using LINQTut04.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTut04.SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunExample01();
            RunExample02();
            Console.ReadKey();
        }

        private static void RunExample01()
        {
            string[] sentences = {
                "I love asp.net core",
                "I like sql server also",
                "in general i love programming"
            };

            var words = sentences.SelectMany(x => x.Split(' '));
            foreach (var word in words)
                Console.WriteLine(word);
        }

        private static void RunExample02()
        {
            var employees = Repository.LoadEmployees();

             var skills = employees.SelectMany(x => x.Skills).Distinct();
            
            //Anthor Way To Distinct Items 
            //ISet<string> skills01 = employees.SelectMany(x => x.Skills).ToHashSet();

            var result01 = (from employee in employees
                           from skill in employee.Skills
                           select skill).Distinct();

            foreach (var skill in result01)
                Console.WriteLine(skill);

        }
    }
}
