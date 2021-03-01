using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAssignmentOOP
{
    //public is used for testing
    public class SimpleGuessingGame : Game
    {
        public SimpleGuessingGame(Person pPerson) : base(pPerson)
        {

        }

        public bool Play()
        {
            bool guessed = false;
            int count = 0;

            do
            {
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
                else if(Person.Name != guess && count < 1)
                {
                    Console.WriteLine("Wrong you get another chance");
                    guessed = false;
                    count++;
                }
                else
                {
                    guessed = false;
                    count++;
                    
                    Console.WriteLine("You lost the answer was - " + Person.Name + "\n" +
                        "Press any key to go back to the main menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (count < 2 && guessed == false);
            return guessed;
        }
    }
}
