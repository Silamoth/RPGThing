using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Thing
{
    class Quest
    {
        Enemy target;
        int numberToKill;
        int numberLeftToKill;
        int reward;

        Random random = new Random();

        bool completed = false;

        public Quest()
        {
            //Determine what enemy this quest calls for killing

            int number = random.Next(0, 3);

            switch (number)
            {
                case 0:
                    target = new Skeleton();
                    break;
                case 1:
                    target = new Demon();
                    break;
                case 2:
                    target = new Spider();
                    break;
            }

            //Determine how many enemies this quest calls for killing
            numberToKill = random.Next(1, 21);

            //Set the number left to kill to be equal to the total
            numberLeftToKill = numberToKill;

            //Calculate the reward
            reward = target.Reward * numberToKill;
        }

        public void Update()
        {
            if (numberLeftToKill == 0)
                completed = true;
        }

        //Properties

        public int Reward
        {
            get { return reward; }
        }

        public Enemy Target
        {
            get { return target; }
        }

        public int NumberToKill
        {
            get { return numberToKill; }
        }

        public int NumberLeftToKill
        {
            get { return numberLeftToKill; }
            set { numberLeftToKill = value; }
        }

        public bool Completed
        {
            get { return completed; }
        }
    }
}
