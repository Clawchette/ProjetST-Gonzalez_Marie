using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetST_Gonzalez_Marie_B2A
{
    class Srt
    {
        public int StartSub;
        public int EndSub;
        public string SubText;

        public Srt(int Start, int End, string Text)
        {
            StartSub = Start;
            EndSub = End;
            SubText = Text;
        }
    }
}
