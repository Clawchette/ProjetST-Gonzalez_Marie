using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetST_Gonzalez_Marie_B2A
{
    class RecupSousTitres
    {
        string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Sous-Titres\";    //Chemin du fichier

        int StartTime = 0;      //Moment du début d'affichage en millisecondes
        int EndTime = 0;        //Moment de fin d'affichage en millisecondes
        string LineText = "";   //Contenu du sous-titre

        public string RecuperationFichier()
        {

            Console.WriteLine("Le fichier de sous-titrage doit se trouver dans le dossier 'Sous-Titres' sur le bureau.");
            Console.WriteLine("Entrez le nom exact du fichier à lire (sans l'extension) :");
            FilePath += Console.ReadLine() + ".srt";
            Console.Clear();
            return FilePath;

        }

        public List<Srt> RecuperationSousTitres()
        {

            FilePath = RecuperationFichier();

            List<Srt> soustitres = new List<Srt>();
            int NbLine = 1;

            using (StreamReader sr = new StreamReader(FilePath))
            {

                string l = "";
                RecupSousTitres s = new RecupSousTitres();

                while ((l = sr.ReadLine()) != null) //Lit le fichier ligne par ligne jusqu'à sa fin
                {

                    if(l == "")             //Si le paragraphe est fini (== il y a un saut de ligne)...
                    {
                        NbLine = 0;
                    }

                    else if(NbLine == 1 && l != "1")
                    {

                        s.LineText = LineText;          //Ajoute LineText à la liste...  
                        soustitres.Add(new Srt(StartTime, EndTime, LineText));              //Ajoute le sous-titre à la liste
                        LineText = "";                  //...puis le vide de son contenu 
                        
                    }
                    
                    else if(NbLine == 2)    //La deuxième ligne contient le moment de début et de fin d'affichage du sous-titre
                    {
                        string[] moments = new string[2];
                        moments = l.Split(" --> ");    //Sépare la ligne pour récupérer un string correspondant au moment de début d'affichage du sous-titre et un autre string pour le moment de fin

                        StartTime = ConversionMillisecondes(moments[0]); //Converti le string correspondant au moment de début d'affichage du sous-titre en millisecondes
                        EndTime = ConversionMillisecondes(moments[1]);  //Converti le string correspondant au moment de fin en millisecondes
                        
                        s.StartTime = StartTime;         //Ajoute StartTime à la liste
                        s.EndTime = EndTime;           //Ajoute EndTime à la liste

                    }

                    else if(NbLine == 3 || NbLine == 4)  //La troisième et éventuelle quatrième ligne contiennent le contenu du sous-titre
                    {
                        
                        LineText += l + " ";            //Ajoute l et un espace au cas où il faudra encore ajouter du texte

                    }

                    NbLine += 1;

                }

                s.LineText = LineText;                  //Ajoute le dernier LineText à la liste  
                soustitres.Add(new Srt(StartTime, EndTime, LineText));              //Ajoute le dernier sous-titre à la liste

                return soustitres;

            }

        }

        public int ConversionMillisecondes(string moment)
        {
            //format HH:MM:SS,sss

            int heures;
            int minutes;
            int secondes;
            int millisecondes;
            int totalms;

            string[] t = moment.Split(":"); //Sépare les heures, les minutes et les secondes+millisecondes
            string[] s = t[2].Split(",");   //Sépare les secondes et les millisecondes

            heures = int.Parse(t[0]);       //Transforment les string en int pour le calcul;
            minutes = int.Parse(t[1]);
            secondes = int.Parse(s[0]);
            millisecondes = int.Parse(s[1]);

            totalms = millisecondes + 1000 * (secondes + 60 * (minutes + 60 * heures)); //Converti le temps en millisecondes

            return totalms;  //Renvoie le nombre de millisecondes
        
        }
    }
}
