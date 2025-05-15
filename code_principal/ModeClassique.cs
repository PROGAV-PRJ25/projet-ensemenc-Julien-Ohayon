using System.Security.Cryptography.X509Certificates;

public class ModeClassique : Simulation 
{
    public string Meteo {get;set;}
    public int Temperature {get;set;}
    public int Precipitation {get;set;}
    public int tours = 1;
    private static int toursSuivant = 1;
    public string Date {get;set;}
    public enum Mois
    {
        Janvier=1, Fevrier=2, Mars=3, Avril=4, Mai=5, Juin=6, Juillet=7, Aout=8, Septembre=9, Octobre=10, Novembre=11, Decembre=12
    }
    public enum Actions {semer=1, arroser=2, recolter=3 }
    
    public ModeClassique ()
    {
        tours = toursSuivant;
        toursSuivant++;
        this.Meteo=Meteo;
        this.Temperature=Temperature;
        this.Precipitation=Precipitation;
        ChangerMeteo();
    }

    /*public Terrain TrouverTerrain(int nbCible)      //faire pareil pour les plantes
    {
        foreach (Terrain elem in Terrains)
        {
            if (elem.Numero==nbCible)
            {
                return elem;
            }
            
        }
        return null;
    }
    */

    public void ChangerMeteo()  //on change la méteo, les température et les précipitations en fonction des mois
    {
        int dateNum = tours/12;
        Date = (Mois)dateNum;
        if (Date=="Janvier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
        if (Date=="Fevrier")
        {
            Meteo="";
            Temperature=10;
            Precipitation=5;
        }
    }

    public void Arroser(Terrain terrain)
    {
        Console.WriteLine($"Le terrain {terrain} a été arrosé");
        terrain.EauTerrain += 5;
    }

    public void AfficherAction()    //le joueur peut faire 2 actions max, à vérifier dans la simulation sauf si le résultat de la 1e est 0
    {
        
        bool nombreOk = false;
        string stringNombre;
        int action;
        bool validation = true;

        Console.WriteLine("Indiquez le numéro de l'action que vous souahitez effectuer :");
        Console.WriteLine("0 : pas d'action");
        Console.WriteLine("1 : semer");
        Console.WriteLine("2 : arroser");
        Console.WriteLine("3 : récolter");
        
        do  //test si le nombre est compris entre les valeurs souhaitées
        {
            do  //test si l'utilisateur entre un entier
            {
            if (validation == false)
            {
                Console.WriteLine("Erreur : réessayez");
            } 
            stringNombre = Console.ReadLine()!;
            nombreOk = int.TryParse(stringNombre, out int numericValue);
            validation = false;
            } while (nombreOk == false);

        action = Convert.ToInt32(stringNombre);

        } while (action<1 || action>3);

        if(action==0)   //on ne fait rien
        {

        }
        
        if(action==1)   //on sème une plante sur un terrain
        {
            bool terrainOk = false;
            string strNumTerrain;
            int numTerrain;
            bool trouve = true;
            Terrain choisi;

            //afficher quelle plante peut être plantée où
            //si on fait d'autres plantes, demander laquelle planter, puis adapter les override de semer
            Console.WriteLine("Choisissez le numéro du terrain sur lequel vous souhaitez semer :"); //à afficher, correspond au Numéro du terrain

            do  //test si le nombre est compris entre les valeurs souhaitées
            {
                do  //test si l'utilisateur entre un entier
                {
                    if (trouve == false)
                    {
                        Console.WriteLine("Erreur : réessayez");
                    }

                    strNumTerrain = Console.ReadLine()!;
                    terrainOk = int.TryParse(strNumTerrain, out int numericValue);
                    trouve = false;

                } while (terrainOk == false);

                numTerrain = Convert.ToInt32(strNumTerrain);

            } while (numTerrain<1 || numTerrain>3 );     //adapter les chiffres selon la taille de nos terrains
            
            foreach (Terrain elem in Terrains)      //grâce aux vérifications ci-dessus, un terrain correspondra forcément et il sera unique
            {
                if (elem.Numero==numTerrain)
                {
                    choisi = elem;
                    choisi.Semer();
                }            
            }
        }


        if(action==2)   //on arrose tout un terrain (pour taux d'humidité), dans terrain
        {

        }
        
        if (action==3)  //on récolte une seule plante, dans plante
        {

        }
        //afficher l'action choisie, et l'appeler 
    }



    public override string ToString()
    {
        string message = $"\nMode Classique \n Mois : {Date}, Météo : {Meteo}, Température : {Temperature}°C, Préipitation : {Precipitation}cm";
        
        return message;
    }
}