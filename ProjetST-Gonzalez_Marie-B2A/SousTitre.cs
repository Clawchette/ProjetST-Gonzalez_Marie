using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetST_Gonzalez_Marie_B2A
{
    class SousTitre
    {
        public int StartSub;
        public int EndSub;
        public string SubText;

        public SousTitre(int Start, int End, string Text)
        {
            StartSub = Start;
            EndSub = End;
            SubText = Text;
        }
    }
}
