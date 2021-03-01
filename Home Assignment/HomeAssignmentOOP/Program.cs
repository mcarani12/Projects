using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignmentOOP
{
    class Program
    {
        static List<Person> persons = new List<Person>();
        static bool SHOW_ANSWER;

        static void Main(string[] args)
        {
            //SHOW_ANSWER = false;
            PopulatePersons();
            MainMenu();
            Console.ReadKey();
        }

        static void PopulatePersons()
        {
            Person bill = new Person("Bill", false, "brown", 'm');
            Person eric = new Person("Eric", true, "brown", 'm');
            Person robert = new Person("Robert", false, "blue", 'm');
            Person george = new Person("George", true, "brown", 'm');
            Person herman = new Person("Herman", false, "green", 'm');
            Person anita = new Person("Anita", false, "blue", 'f');
            Person maria = new Person("Maria", true, "green", 'f');
            Person susan = new Person("Susan", false, "brown", 'f');
            Person claire = new Person("Claire", true, "brown", 'f');
            Person anne = new Person("Anne", false, "brown", 'f');

            persons.Add(bill);
            persons.Add(eric);
            persons.Add(robert);
            persons.Add(george);
            persons.Add(herman);
            persons.Add(anita);
            persons.Add(maria);
            persons.Add(susan);
            persons.Add(claire);
            persons.Add(anne);
        }

        static void ViewPartcipants()
        {
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Description());
            }
            Console.WriteLine("\n" +
                "Press any key to go back to the main menu");
            Console.ReadKey();
            Console.Clear();
        }

        static Person GetRandomPerson()
        {
            Random r = new Random();
            int randomPersonInt = r.Next(0, persons.Count);
            Person randomPerson = persons[randomPersonInt];
            //SHOW_ANSWER = true;
            //if(SHOW_ANSWER == true)
            //{
            //    Console.WriteLine(randomPerson.Description());
            //}
            return randomPerson;
        }

        static int MainMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Guess Who!\n" +
                "This is the main menu.\n" +
                "Please select an option.\n" +
                "------------------------\n" +
                "1 - The Simple Guessing Game\n" +
                "2 - The Random Hint Game\n" +
                "3 - View all our participants\n" +
                "4 - Exit\n" +
                "------------------------");
                Console.Write("Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        HandleOption1();
                        break;
                    case 2:
                        Console.Clear();
                        HandleOption2();
                        break;
                    case 3:
                        Console.Clear();
                        ViewPartcipants();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Press any button to exit\n" +
                            "Bye!!!");
                        break;
                    default:                        
                        Console.WriteLine("Wrong Input!!!\n" +
                            "Press any key to choose again");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (choice != 4);
            return choice;
        }

        static void HandleOption1()
        {
            SimpleGuessingGame sgg = new SimpleGuessingGame(GetRandomPerson());
            sgg.Play();
        }

        static void HandleOption2()
        {
            RandomHintGame rhg = new RandomHintGame(GetRandomPerson());            
            rhg.Play();
        }
    }
}                       