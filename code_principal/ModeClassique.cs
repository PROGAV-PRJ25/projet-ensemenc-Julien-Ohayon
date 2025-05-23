public class ModeClassique : Mode
{
    public string? Meteo { get; set; }
    public int Temperature { get; set; }
    public int Precipitation { get; set; }
    public string Date = "Janvier";
    private Dictionary<string, (string meteo, int temp, int pluie)> meteoParMois = new()
    {
        {"Janvier", ("Nuage", 4, 65)},
        {"Fevrier", ("Pluie fine", 4, 50)},
        {"Mars",("Nuage",6,50) },
        {"Avril",("Soleil",10,40)},
        {"Mai",("Nuage",13,60)},
        {"Juin",("Nuage",16,65)},
        {"Juillet",("Pluie",18,80)},
        {"Août",("Pluie",18,65)},
        {"Septembre",("Soleil",15,75)},
        {"Octobre",("Nuage",11,70)},
        {"Novembre",("Pluie",7,65)},
        {"Décembre",("Neige",4,70)}
    };

    private List<string> moisOrdre = new List<string>
    {
        "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin","Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"
    };

    public enum Actions { semer = 1, arroser = 2, recolter = 3 }

    public ModeClassique() : base()
    {
        ChangerMeteo(1);
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

    public void ChangerMeteo(int tours)  //? //on change la méteo, les température et les précipitations en fonction des mois
    {

        int dateNum = (tours - 1) % 12;
        Date = moisOrdre[dateNum];
        if (meteoParMois.TryGetValue(Date, out var valeurs))    //change la météo en fonction du dico
        {
            Meteo = valeurs.meteo;
            Temperature = valeurs.temp;
            Precipitation = valeurs.pluie;
        }

    }

    public void Arroser(Terrain terrain)
    {
        Console.WriteLine($"Le terrain {terrain.Numero} a été arrosé");
        terrain.EauTerrain += 5;
    }

    public Terrain ChoisirTerrain()
    {
        bool terrainOk = false;
        string strNumTerrain;
        int numTerrain;
        bool trouve = true;
        Terrain? choisi = null;

        Console.WriteLine("Choisissez le numéro du terrain sur lequel vous souhaitez effectuer l'action :"); //afficher les numéros afficher, correspond au Numéro du terrain

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

        } while (numTerrain < 1 || numTerrain > 3);     //adapter les chiffres selon nos terrains

        //grâce aux vérifications ci-dessus, un terrain correspondra forcément et il sera unique
        foreach (Terrain elem in Simulation.Terrains)
        {
            if (elem.Numero == numTerrain)
            {
                choisi = elem;
            }
        }
        return choisi;
    }

    public void AfficherAction(List<Terrain> terrains)    //le joueur peut faire 2 actions max, à vérifier dans la simulation sauf si le résultat de la 1e est 0
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

        } while (action < 0 || action > 3);

        if (action == 0)   //on ne fait rien
        {

        }

        if (action == 1)   //on sème une plante sur un terrain
        {
            //afficher quelle plante peut être plantée où
            Terrain terrainChoisi = ChoisirTerrain();
            //grâce aux vérifications de ChoisirTerrain, un terrain correspondra forcément et il sera unique
            terrainChoisi.Semer();
        }


        if (action == 2)   //on arrose tout un terrain (pour taux d'humidité), dans terrain
        {

        }

        if (action == 3)  //on récolte une seule plante, dans plante
        {
            Terrain terrainChoisi = ChoisirTerrain();
            terrainChoisi.Cueillir();

        }
    }

    public override void Simuler(List<Terrain> terrains)
    {

        Console.WriteLine($"\nMode Classique - Mois : {Date} \n Météo : {Meteo}, Température : {Temperature}°C, Précipitation : {Precipitation}mm");
        ChoisirEvent(terrains);
        Console.WriteLine($"La bonne fée ou l'obstacle est :  {ObsBFActif}");

        for (int i = 0; i < 2; i++)
        {
            AfficherAction(terrains);
            //AfficherTerrains
        }

    }

     public void ChoisirEvent(List<Terrain> terrains)
    {
        Terrain terrainTrouve = ChoisirAleaTerrain(terrains);
    

        int x = rnd.Next(1, 8);      // choisir si c'est une bonne fée, obstacles ou obstacles d'urgence
        if (x <= 3)
        {
            int y = rnd.Next(0,2);  //sinon mettre avec les (int) et les trucs qui correspondent 
            ObsBFActif = (ObsBF)y;
            AgirBonnesFee(ObsBFActif, terrainTrouve);
        }
        else if (x <= 6)
        {
            int y = rnd.Next(2,4);
            ObsBFActif = (ObsBF)y;
            AgirObstacles(ObsBFActif, terrainTrouve);
        }
        else
        {
            int y = rnd.Next(4,6);
            ObsBFActif = (ObsBF)y;
            evenementActuel = Evenement.Urgence;
        }
    }
    
    public void AgirBonnesFee(ObsBF bf, Terrain terrain)   //si on choisit de le faire sur un terrain particulier
    {
        switch (bf)
        {
            case ObsBF.VerDeTerre:
                terrain.Fertiliser();
                break;
            case ObsBF.Abeille:
                terrain.Fleurir();
                break;
        }
    }

    public void AgirObstacles(ObsBF obs, Terrain terrain)   //si on choisit de le faire sur un terrain particulier
    {
        switch (obs)
        {
            case ObsBF.Pietineur:
                terrain.DetruirePlante();
                break;
            case ObsBF.Oiseaux:
                terrain.MangerGraine();
                break;
        }
    }

}