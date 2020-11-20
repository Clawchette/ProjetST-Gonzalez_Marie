using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetST_Gonzalez_Marie_B2A
{
    class Lecture
    {
        RecupSousTitres st = new RecupSousTitres();     //Récupère la class des sous-titres
        List<Srt> ListST = new List<Srt>(); //Créé une liste d'éléments de class RecupSousTitres
        
        public async Task LectureSousTitres()
        {
            ListST = st.RecuperationSousTitres();   //Récupère la liste des sous-titres du fichier qui sera entré par l'utilisateur
           
            foreach (Srt st in ListST)        //Pour chaque sous-titre...
            {
                await Task.Delay(st.StartSub);      //...attend son temps de début...
                Console.WriteLine(st.SubText);      //...puis l'affiche...
                await Task.Delay(st.EndSub);        //...puis attend son temps de fin...
                Console.Clear();                    //...et l'efface
            }
        }
    }
}
