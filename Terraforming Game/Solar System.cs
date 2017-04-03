using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraforming_Game
{
    class Solar_System
    {
        private string name;
        private int numPlanets;
        private Planet[] planets;

        private String seed;

        public Solar_System(string n, int nP, string[] planetNames, string s)
        {
            //do things
            name = n;
            seed = s;
            numPlanets = nP;
            planets = new Planet[numPlanets];

            int distance = 0;
            Random distRand = new Random(Convert.ToInt32(s.Substring(0, 1))); 
            Random planetLayout = new Random(Convert.ToInt32(s.Substring(0, 2)));

            for (int i = 0; i < numPlanets; i++)
            {
                distance += distRand.Next(4, 10);
                int template = planetLayout.Next(0,Globals.getNumT());

                planets[i] = new Planet(planetNames[i], distance, template, Convert.ToInt32(s.Substring(2,2)) + i);
            }
        }

        public Solar_System(string n, int nP, string s)
        {
            //do things
            name = n;
            seed = s;
            numPlanets = nP;
            planets = new Planet[numPlanets];

            int distance = 0;
            Random distRand = new Random(Convert.ToInt32(s.Substring(0,2)));
            Random planetLayout = new Random(Convert.ToInt32(s.Substring(0, 2)));

            for (int i = 0; i < numPlanets; i++)
            {
                distance += distRand.Next(4, 10);
                int template = planetLayout.Next(0, Globals.getNumT());

                planets[i] = new Planet(name + " " + i, distance, template, Convert.ToInt32(s.Substring(2, 2)) + i);
            }
        }

        public Planet getPlanet(int index)
        {
            return planets[index];
        }
        public string getName()
        {
            return name;
        }
        public int getSize()
        {
            return numPlanets;
        }
    }
}
