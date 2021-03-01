using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAssignmentOOP
{
    //public is used for testing
    public class Game
    {
        Person person;

        public Person Person{ get{ return person; } set{ person = value; } }

        public Game(Person pPerson)
        {
            person = pPerson;
        }
    }
}
