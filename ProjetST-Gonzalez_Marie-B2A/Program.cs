using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetST_Gonzalez_Marie_B2A
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Lecture logiciel = new Lecture();
            await logiciel.LectureSousTitres();

        }
    }
}
