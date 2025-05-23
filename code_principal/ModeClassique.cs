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


    public void ChangerMeteo(int tours)  //on change la méteo, les température et les précipitations en fonction des mois
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

    public override void Simuler(List<Terrain> terrains)
    {
        Console.WriteLine($"\nMode Classique - Mois : {Date}\n Météo : {Meteo}, Température : {Temperature}°C, Précipitation : {Precipitation}mm");
        AfficherTousTerrains(terrains);
        Console.WriteLine("Vous pouvez effectuer 2 actions");
        for (int i = 0; i < 2; i++)
        {
            Agir(terrains);
            AfficherTousTerrains(terrains);
        }
        ChoisirEvent(terrains);     //choisit les obstacles ou les bonnes fées
        Console.WriteLine($"La bonne fée ou l'obstacle est :  {ObsBFActif}");

    }

    public void Arroser(Terrain terrain)    //action
    {
        terrain.EauTerrain += 5;
        Console.WriteLine($"Le terrain {terrain.Numero} a été arrosé");
    }

    private Terrain ChoisirTerrain(List<Terrain> terrains)     //on laisse l'utilisateur choisir le terrain de son choix 
    {
        bool terrainOk = false;
        string strNumTerrain;
        int numTerrain;
        bool trouve = true;
        Terrain? choisi = null; //le terrain est juste null au tout début de la méthode

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

        } while (numTerrain < 1 || numTerrain > terrains.Count);   //comme on a initialisé le numéro du 1er terrain à 1 et qu'il augmente de 1 pour chaque élément de la liste

        //grâce aux vérifications ci-dessus, un terrain correspondra forcément et il sera unique
        foreach (Terrain elem in Simulation.Terrains)
        {
            if (elem.Numero == numTerrain)
            {
                choisi = elem;
            }
        }
        return choisi!; //on peut mettre ! car un terrain correspond forcément 
    }

    private void Agir(List<Terrain> terrains)    //le joueur peut faire 2 actions max, à vérifier dans la simulation sauf si le résultat de la 1e est 0
    {

        bool nombreOk = false;
        string stringNombre;
        int action;
        bool validation = true;
        
        Console.WriteLine("Indiquez le numéro de l'action que vous souhaitez effectuer :");
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

        //si l'utilisateur a rentré 0, rien ne se passe

        if (action == 1)   //on sème une plante sur un terrain
        {
            //afficher quelle plante peut être plantée où
            Terrain terrainChoisi = ChoisirTerrain(terrains);
            //grâce aux vérifications de ChoisirTerrain, un terrain correspondra forcément et il sera unique
            terrainChoisi.Semer();
        }


        if (action == 2)   //on arrose tout un terrain (pour taux d'humidité), dans terrain
        {
            Terrain terrainChoisi = ChoisirTerrain(terrains);
            Arroser(terrainChoisi);
        }

        if (action == 3)  //on récolte une seule plante, dans plante
        {
            Terrain terrainChoisi = ChoisirTerrain(terrains);
            terrainChoisi.Cueillir();

        }
    }
    
    private void AfficherTousTerrains(List<Terrain> terrains)
    {
        foreach (Terrain t in terrains)
        {
            t.Afficher();
        }
    }
    private void ChoisirEvent(List<Terrain> terrains)   //choisi aléatoirement les bonnes fées et les obstacles
    {
        Terrain terrainTrouve = ChoisirAleaTerrain(terrains);       // choix aléatoire du terrain 
        Console.WriteLine($"Un évènement arrive sur votre terrain n°{terrainTrouve.Numero}");


        int x = rnd.Next(1, 8);      // choisir si c'est une bonne fée, obstacles ou obstacles d'urgence
        if (x <= 3)     // 3/8 chances de tomber sur une bonne fée
        {
            int y = rnd.Next(0, 2);     // on choisit aléatoirement quel évènement va arriver parmi les bonnes fées
            ObsBFActif = (ObsBF)y;
            AgirBonnesFee(ObsBFActif, terrainTrouve);
        }
        else if (x <= 6)    // 3/4 chances de tomber sur une bonne fée
        {
            int y = rnd.Next(2, 4); 
            ObsBFActif = (ObsBF)y;
            AgirObstacles(ObsBFActif, terrainTrouve);
        }
        else    // 1/8 chance de tomber sur un évènement qui déclenche le mode urgence
        {
            int y = rnd.Next(4, 6);     
            ObsBFActif = (ObsBF)y;
            evenementActuel = Evenement.Urgence;    //on va passer en mode urgence 
        }
    }
    
    public void AgirBonnesFee(ObsBF bf, Terrain terrain)  
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

    public void AgirObstacles(ObsBF obs, Terrain terrain)  
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