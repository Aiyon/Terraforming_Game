using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraforming_Game
{
    class Planet
    {
        private Hazard[] hazards;
        private string name;
        private int distance;
        private int type;

        public Planet(string pName, int dist, int template, int seed)
        {
            name = pName;
            type = template;
            distance = dist;
            //do things

            Random hazardSeed = new Random(seed);
            int numHazards = hazardSeed.Next(0,12);
            hazards = new Hazard[numHazards];
            for(int i = 0; i < numHazards; i++)
            {
                hazards[i] = new Hazard(type);
            }
        }

        public string getName()
        {
            return name;
        }

        public int getType()
        {
            return type;
        }

        public int getDistance()
        {
            return distance;
        }
    }
}
