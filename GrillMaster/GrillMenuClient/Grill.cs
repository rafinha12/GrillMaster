using System;
using System.Collections.Generic;
using System.Text;

namespace GrillClass
{
    class Grill
    {

        public String[,] grill;
        private int grillWidth;
        private int grillLength;
        public string empty = "----";
        public Grill(int grillWidth, int grillLength)
        {
            this.grillWidth = grillWidth;
            this.grillLength = grillLength;
            this.grill = InitializeGrill();
        }

        private string[,] InitializeGrill()
        {
            String[,] grill = new String[this.grillWidth, this.grillLength];
            for (int i = 0; i < this.grillLength; i++)
            {
                for (int j = 0; j < this.grillWidth; j++)
                {

                    grill[j, i] = empty;
                }
            }
            return grill;

        }
        public void PrintGrill(Grill g)
        {
            for (int l = 0; l < grillLength; l++)
            {
                for (int w = 0; w < grillWidth; w++)
                {
                    Console.Write(g.grill[w, l] + "  ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

        }

    }
}

