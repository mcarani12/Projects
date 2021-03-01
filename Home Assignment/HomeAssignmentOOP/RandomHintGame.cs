using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAssignmentOOP
{
    //public is used for testing
    public class RandomHintGame : Game
    {
        static string randomHint;

        public RandomHintGame(Person person) : base(person)
        {
            Random r = new Random();
            int randomHintInt = r.Next(0, 3);

            if (person.Hat == true && randomHintInt == 0)
            {
                randomHint = "The person has a hat.";
            }
            else if (person.Hat == false && randomHintInt == 0)
            {
                randomHint = "The person does not have a hat.";
            }
            else if (person.EyeColour == "blue" && randomHintInt == 1)
            {
                randomHint = "The person has blue eyes.";
            }
            else if (person.EyeColour == "brown" && randomHintInt == 1)
            {
                randomHint = "The person has brown eyes.";
            }
            else if(person.EyeColour == "green" && randomHintInt == 1)
            {
                randomHint = "The person has green eyes.";
            }
            else if (person.Gender == 'f' && randomHintInt == 2)
            {
                randomHint = "The person is a female";
            }
            else if (person.Gender == 'm' && randomHintInt == 2)
            {
                randomHint = "The person is a male";
            }
        }
        public bool Play()
        {
            bool guessed = false;

            Console.WriteLine(randomHint);
            Console.WriteLine("Enter the name of who do you think it is: ");
            string guess = Console.ReadLine();
            if (Person.Name == guess)
            {
                guessed = true;
                Console.WriteLine("You win\n" +
                    "Press any key to go back to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                guessed = false;
                Console.WriteLine("You lost the answer was - " + Person.Name + "\n" +
                    "Press any key to go back to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
            return guessed;
        }
    }
}
