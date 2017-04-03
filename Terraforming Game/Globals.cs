using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraforming_Game
{
    static class Globals
    {
        private static int numTemplates = 9;

        private static string[] templates = {"Earthlike", "Volcanic", "Ice", "Barren", "Aquatic", "Gas Giant", "Radioactive", "Unstable (earthquakes and shit)", "Timeless"};

        public static int getNumT()
        {
            return numTemplates;
        }

        public static string getTemplate(int index)
        {
            return templates[index];
        }
    }
}
